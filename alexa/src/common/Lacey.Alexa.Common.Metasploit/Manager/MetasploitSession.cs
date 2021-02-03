using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MsgPack;

namespace Lacey.Alexa.Common.Metasploit.Manager
{
	internal sealed class MetasploitSession : IDisposable
	{
        private readonly string _host;

        private string _token;

        private bool _isAuthenticated;

		public MetasploitSession(string host)
		{
			_host = host;
			_token = null;
        }

		public MetasploitSession(string token, string host)
		{
			_token = token;
			_host = host;
		}
		
		public string Token => _token;

        public async Task Login(string username, string password)
        {
            var response = await Authenticate(username, password);
            _isAuthenticated = !response.ContainsKey("error");

            if (!_isAuthenticated)
                throw new Exception(response["error_message"] as string);

            if (response["result"] as string == "success")
                _token = response["token"] as string;
        }

		public bool IsAuthenticated()
        {
            return _isAuthenticated;
        }

		public async Task<Dictionary<string, object>> Authenticate(string username, string password)
		{
			var response = await this.Execute ("auth.login", username, password);
            _isAuthenticated = !response.ContainsKey("error");
			return response;
        }
		
		public async Task<Dictionary<string, object>> Execute(string method, params object[] args)
		{
			if (string.IsNullOrEmpty (_host))
				throw new Exception ("Host null or empty");
			
			if (method != "auth.login" && string.IsNullOrEmpty (_token))
				throw new Exception ("Not authenticated.");
		
			ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => {return true;}; //dis be bad, no ssl check
			
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (_host);

			request.ContentType = "binary/message-pack";
			request.Method = "POST";
			request.KeepAlive = true;

			Stream requestStream = null;

			try{
				requestStream = request.GetRequestStream();
			} catch (Exception ex) {
				Console.WriteLine (ex);
			}

			var msgpackWriter = Packer.Create(requestStream);
			
			msgpackWriter.PackArrayHeader (args.Length + 1 + (string.IsNullOrEmpty (_token) ? 0 : 1));
			
			msgpackWriter.PackString (method);
			
			if (!string.IsNullOrEmpty (_token) && method != "auth.login")
				msgpackWriter.Pack (_token);
			
			foreach (object arg in args) 
				Pack(msgpackWriter, arg);
			
			requestStream.Close();

			var buffer = new byte[4096];
			var mstream = new MemoryStream();

			try
            {
                using WebResponse response = request.GetResponse ();
                await using Stream rstream = response.GetResponseStream();
                int count = 0;
					    
                do
                {
                    count = rstream.Read(buffer, 0, buffer.Length);
                    mstream.Write(buffer, 0, count);
                } while (count != 0);
            }
			catch (WebException ex) {
				if (ex.Response != null) {
					string res = string.Empty;
					using (StreamReader rdr = new StreamReader(ex.Response.GetResponseStream()))
						res = await rdr.ReadToEndAsync();

					Console.WriteLine(res) ;
				}
			}
			
			mstream.Position = 0;

			var resp = Unpacking.UnpackObject(mstream).AsDictionary();

			var returnDictionary = TypifyDictionary(resp);
			
			return returnDictionary;
		}

		//this is a ridiculous method
		Dictionary<string, object> TypifyDictionary(MessagePackObjectDictionary dict)
		{
			var returnDictionary = new Dictionary<string, object>();
			
			foreach (var (messagePackObject, value) in dict)
			{
				var obj = (MessagePackObject)value;
                string key;
                try
                {
                    key = System.Text.Encoding.ASCII.GetString((byte[])messagePackObject);
                }
				catch (Exception)
                {
                    key = messagePackObject.ToString();
                }

				if (obj.UnderlyingType == null)
					continue;
				
				if (obj.IsRaw) {
					if (obj.UnderlyingType == typeof(string)) {
						if (messagePackObject.IsRaw && messagePackObject.IsTypeOf(typeof(byte[])).Value)
							returnDictionary[key] = obj.AsString ();
						else
							returnDictionary[messagePackObject.ToString ()] = obj.AsString ();
					}
					else if (obj.IsTypeOf(typeof(int)).Value)
						returnDictionary [messagePackObject.ToString ()] = (int)obj.ToObject ();
					else if (obj.IsTypeOf(typeof(byte[])).Value) {
						if (key == "payload") 
							returnDictionary [key] = (byte[])obj;
						else 
							returnDictionary [key] = System.Text.Encoding.ASCII.GetString((byte[])obj.ToObject ());
					} else
						throw new Exception ("I don't know type: " + value.GetType().Name);
				} else if (obj.IsArray) {
					List<object> arr = new List<object>();
					foreach (var o in obj.ToObject() as MessagePackObject[]) {
						if (o.IsDictionary)
							arr.Add (TypifyDictionary (o.AsDictionary()));
						else if (o.IsRaw)
							arr.Add (System.Text.Encoding.ASCII.GetString((byte[])o));
						else if (o.IsArray) {
							var enu = o.AsEnumerable();
							List<object> array = new List<object>();
							foreach (var blah in enu)
								array.Add (blah as object);

							arr.Add (array.ToArray());
						} else if (o.ToObject () is byte) //this is a hack because I don't know what type you are...
							arr.Add (o.ToString());
					}

					if (messagePackObject.IsRaw && messagePackObject.IsTypeOf(typeof(byte[])).Value)
						returnDictionary.Add (key, arr);
					else
						returnDictionary.Add (key, arr);
				} else if (obj.IsDictionary) {
					if (messagePackObject.IsRaw && messagePackObject.IsTypeOf(typeof(byte[])).Value)
						returnDictionary[key] = TypifyDictionary (obj.AsDictionary ());
					else 
						returnDictionary [messagePackObject.ToString()] = TypifyDictionary (obj.AsDictionary ());
				} else if (obj.IsTypeOf (typeof(ushort)).Value) {
					if (messagePackObject.IsRaw && messagePackObject.IsTypeOf(typeof(byte[])).Value)
						returnDictionary[key] = obj.AsUInt16();
					else
						returnDictionary[messagePackObject.ToString()] = obj.AsUInt16 ();
				} else if (obj.IsTypeOf(typeof(uint)).Value) {
					if (messagePackObject.IsRaw && messagePackObject.IsTypeOf(typeof(byte[])).Value)
						returnDictionary[key] = obj.AsUInt32 ();
					else
						returnDictionary[messagePackObject.ToString()] = obj.AsUInt32 ();
				} else if (obj.IsTypeOf(typeof(bool)).Value) {
					if (messagePackObject.IsRaw && messagePackObject.IsTypeOf(typeof(byte[])).Value)
						returnDictionary[key] = obj.AsBoolean();
					else
						returnDictionary[messagePackObject.ToString()] = obj.AsBoolean();
				}
				else 
					throw new Exception("Don't know type: " + obj.ToObject().GetType().Name);
			}
			
			return returnDictionary;
		}
		
		void Pack(Packer packer, object o)
		{
 	 	
			if (o == null) {
				packer.PackNull();
				return;
			}
 	
			if (o is int)
				packer.Pack ((int)o);
			else if (o is uint)
				packer.Pack ((uint)o);
			else if (o is float)
				packer.Pack ((float)o);
			else if (o is double)
				packer.Pack ((double)o);
			else if (o is long)
				packer.Pack ((long)o);
			else if (o is ulong)
				packer.Pack ((ulong)o);
			else if (o is bool)
				packer.Pack ((bool)o);
			else if (o is byte)
				packer.Pack ((byte)o);
			else if (o is sbyte)
				packer.Pack ((sbyte)o);
			else if (o is short)
				packer.Pack ((short)o);
			else if (o is ushort)
				packer.Pack ((ushort)o);
			else if (o is string)
				packer.PackString((string)o, Encoding.ASCII);
			else if (o is Dictionary<string, object>)
			{
				packer.PackMapHeader((o as Dictionary<string, object>).Count);
				
				foreach (var pair in (o as Dictionary<string, object>))
				{
					Pack(packer, pair.Key);
					Pack(packer, pair.Value);
				}
				
			}
			else if (o is string[])
			{
				packer.PackArrayHeader((o as string[]).Length);
				
				foreach (var obj in (o as string[]))
					packer.Pack(obj as string);
			}
			else
				throw new Exception("Cant handle type: " + o.GetType().Name);; 
		
		}
		
		public void Dispose()
		{
            if (IsAuthenticated())
            {
                Execute("auth.logout").Wait();
            }
		}
	}
}


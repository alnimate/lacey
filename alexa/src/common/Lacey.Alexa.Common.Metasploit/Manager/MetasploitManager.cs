using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lacey.Alexa.Common.Metasploit.Manager
{
	internal class MetasploitManager : IDisposable
	{
		private readonly MetasploitSession _session;
		
		public MetasploitManager (MetasploitSession session)
		{
			_session = session;
		}
		
		public async Task<Dictionary<string, object>> GetCoreModuleStats()
		{
			return await _session.Execute("core.module_stats");
		}
		
		public async Task<Dictionary<string, object>> GetCoreVersionInformation()
		{
			return await _session.Execute("core.version");
		}
		
		public async Task<Dictionary<string, object>> AddCoreModulePath(string modulePath)
		{
			return await _session.Execute("core.add_module_path", modulePath);
		}
		
		public async Task<Dictionary<string, object>> ReloadCoreModules()
		{
			return await _session.Execute("core.reload_modules");
		}
		
		public async Task<Dictionary<string, object>> SaveCore()
		{
			return await _session.Execute("core.save");
		}
		
		public async Task<Dictionary<string, object>> SetCoreGlobalVariable(string optionName, string optionValue)
		{
			return await _session.Execute("core.setg", optionName, optionValue);
		}
		
		public async Task<Dictionary<string, object>> UnsetCoreGlobalVariable(string optionName)
		{
			return await _session.Execute("core.unsetg", optionName);
		}
		
		public async Task<Dictionary<string, object>> GetCoreThreadList()
		{
			return await _session.Execute("core.thread_list");
		}
		
		public async Task<Dictionary<string, object>> KillCoreThread(string threadId)
		{
			return await _session.Execute("core.thread_kill", threadId);
		}
		
		public async Task<Dictionary<string, object>> StopCore()
		{
			return await _session.Execute("core.stop");
		}
		
		public async Task<Dictionary<string, object>> CreateConsole()
		{
			return await _session.Execute("console.create");
		}
		
		public async Task<Dictionary<string, object>> DestroyConsole(string consoleId)
		{
			return await _session.Execute("console.destroy", consoleId);
		}
		
		public async Task<Dictionary<string, object>> ListConsoles()
		{
			return await _session.Execute("console.list");
		}
		
		public async Task<Dictionary<string, object>> WriteToConsole(string consoleId, string data)
		{
			return await _session.Execute("console.write", consoleId, data);
		}
		
		public async Task<Dictionary<string, object>> ReadConsole(string consoleId)
		{
			return await _session.Execute("console.read", consoleId);
		}
		
		public async Task<Dictionary<string, object>> DetachSessionFromConsole(string consoleId)
		{
			return await _session.Execute("console.session_detach", consoleId);
		}
		
		public async Task<Dictionary<string, object>> KillSessionFromConsole(string consoleId)
		{
			return await _session.Execute("console.session_kill", consoleId);
		}
		
		public async Task<Dictionary<string, object>> TabConsole(string consoleId, string input)
		{
			return await _session.Execute("console.tabs", consoleId, input);
		}
		
		public async Task<Dictionary<string, object>> ListJobs()
		{
			return await _session.Execute("job.list");
		}
		
		public async Task<Dictionary<string, object>> GetJobInfo(string jobId)
		{
			return await _session.Execute("job.info", jobId);
		}
		
		public async Task<Dictionary<string, object>> StopJob(string jobId)
		{
			return await _session.Execute("job.stop", jobId);
		}
		
		public async Task<Dictionary<string, object>> GetExploitModules()
		{
			return await _session.Execute("module.exploits");
		}
		
		public async Task<Dictionary<string, object>> GetAuxiliaryModules()
		{
			return await _session.Execute("module.auxiliary");
		}
		
		public async Task<Dictionary<string, object>> GetPostModules()
		{
			return await _session.Execute("module.post");
		}
		
		public async Task<Dictionary<string, object>> GetPayloads()
		{
			return await _session.Execute("module.payloads");
		}
		
		public async Task<Dictionary<string, object>> GetEncoders()
		{
			return await _session.Execute("module.encoders");
		}
		
		public async Task<Dictionary<string, object>> GetNops()
		{
			return await _session.Execute("module.nops");
		}
		
		public async Task<Dictionary<string, object>> GetModuleInformation(string moduleType, string moduleName)
		{
			return await _session.Execute("module.info", moduleType, moduleName);
		}
		
		public async Task<Dictionary<string, object>> GetModuleOptions(string moduleType, string moduleName)
		{
			return await _session.Execute("module.options", moduleType,moduleName);
		}
		
		public async Task<Dictionary<string, object>> GetModuleCompatiblePayloads(string moduleName)
		{
			return await _session.Execute("module.compatible_payloads", moduleName);
		}
		
		public async Task<Dictionary<string, object>> GetModuleTargetCompatiblePayloads(string moduleName, int targetIndex)
		{
			return await _session.Execute("module.target_compatible_payloads", moduleName, targetIndex);
		}
		
		public async Task<Dictionary<string, object>> GetModuleCompatibleSessions(string moduleName)
		{
			return await _session.Execute("module.compatible_sessions", moduleName);
		}
		
		public async Task<Dictionary<string, object>> Encode(string data, string encoderModule, Dictionary<string, object> options)
		{
			return await _session.Execute("module.encode", data, encoderModule, options);
		}
		
		public async Task<Dictionary<string, object>> ExecuteModule(string moduleType, string moduleName, Dictionary<string, object> options)
		{
			return await _session.Execute("module.execute", moduleType, moduleName, options);
		}
		
		public async Task<Dictionary<string, object>> LoadPlugin(string pluginName, Dictionary<string, object> options)
		{
			return await _session.Execute("plugin.load", pluginName, options);
		}
		
		public async Task<Dictionary<string, object>> UnloadPlugin(string pluginName)
		{
			return await _session.Execute("plugin.unload", pluginName);
		}
		
		public async Task<Dictionary<string, object>> ListLoadedPlugins()
		{
			return await _session.Execute("plugin.loaded");
		}
		
		public async Task<Dictionary<string, object>> ListSessions()
		{
			return await _session.Execute("session.list");
		}
		
		public async Task<Dictionary<string, object>> StopSession(string sessionId)
		{
			return await _session.Execute("session.stop", sessionId);
		}
		
		public async Task<Dictionary<string, object>> ReadSessionShell(string sessionId)
		{
			return await this.ReadSessionShell(sessionId, null);
		}
		
		public async Task<Dictionary<string, object>> ReadSessionShell(string sessionId, int? readPointer)
		{
			if (readPointer.HasValue)
				return await _session.Execute("session.shell_read", sessionId, readPointer.Value);
			else
				return await _session.Execute("session.shell_read", sessionId);
		}
		
		public async Task<Dictionary<string, object>> WriteToSessionShell(string sessionId, string data)
		{
			return await _session.Execute("session.shell_write", sessionId, data);
		}
		
		public async Task<Dictionary<string, object>> WriteToSessionMeterpreter(string sessionId, string data)
		{
			return await _session.Execute("session.meterpreter_write", sessionId, data);
		}
		
		public async Task<Dictionary<string, object>> ReadSessionMeterpreter(string sessionId)
		{
			return await _session.Execute("session.meterpreter_read", sessionId);
		}
		
		public async Task<Dictionary<string, object>> RunSessionMeterpreterSingleCommand(string sessionId, string command)
		{
			return await _session.Execute("session.meterpreter_run_single", sessionId, command);
		}
		
		public async Task<Dictionary<string, object>> RunSessionMeterpreterScript(string sessionId, string scriptName)
		{
			return await _session.Execute("session.meterpreter_script", sessionId, scriptName);
		}
		
		public async Task<Dictionary<string, object>> DetachMeterpreterSession(string sessionId)
		{
			return await _session.Execute("session.meterpreter_session_detach", sessionId);
		}
		
		public async Task<Dictionary<string, object>> KillMeterpreterSession(string sessionId)
		{
			return await _session.Execute("session.meterpreter_session_kill", sessionId);
		}
		
		public async Task<Dictionary<string, object>> TabMeterpreterSession(string sessionId, string input)
		{
			return await _session.Execute("session.meterpreter_tabs", sessionId, input);
		}
		
		public async Task<Dictionary<string, object>> CompatibleModuleForSession(string sessionId)
		{
			return await _session.Execute("session.compatible_modules", sessionId);
		}
		
		public async Task<Dictionary<string, object>> UpgradeShellToMeterpreter(string sessionId, string host, string port)
		{
			return await _session.Execute("session.shell_upgrade", sessionId, host, port);
		}
		
		public async Task<Dictionary<string, object>> ClearSessionRing(string sessionId)
		{
			return await _session.Execute("session.ring_clear", sessionId);
		}
		
		public async Task<Dictionary<string, object>> LastSessionRing(string sessionId)
		{
			return await _session.Execute("session.ring_last", sessionId);
		}
		
		public async Task<Dictionary<string, object>> WriteToSessionRing(string sessionId, string data)
		{
			return await _session.Execute("session.ring_put", sessionId, data);
		}
		
		public async Task<Dictionary<string, object>> ReadSessionRing(string sessionId, int? readPointer)
		{
			if (readPointer.HasValue)
				return await _session.Execute("session.ring_read", sessionId, readPointer.Value);
			else
				return await _session.Execute("session.ring_read", sessionId);
		}
        
		public void Dispose()
		{
		}
	}
}


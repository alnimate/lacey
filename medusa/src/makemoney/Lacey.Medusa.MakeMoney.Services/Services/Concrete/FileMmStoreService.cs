using System.IO;
using Lacey.Medusa.MakeMoney.Services.Models.ScDevice;
using Newtonsoft.Json;

namespace Lacey.Medusa.MakeMoney.Services.Services.Concrete
{
    public class FileMmStoreService : IMmStoreService
    {
        private readonly string filePath;

        public FileMmStoreService(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveScDevice(ScDeviceResponse scDevice)
        {
            this.Save(scDevice);
        }

        public ScDeviceResponse GetScDevice()
        {
            return this.Get<ScDeviceResponse>();
        }

        private void Save<T>(T entity)
        {
            File.WriteAllText(this.filePath, JsonConvert.SerializeObject(entity));
        }

        private T Get<T>()
        {
            if (!File.Exists(this.filePath))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(this.filePath));
        }
    }
}
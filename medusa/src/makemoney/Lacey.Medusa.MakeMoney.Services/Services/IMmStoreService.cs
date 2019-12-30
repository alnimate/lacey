using Lacey.Medusa.MakeMoney.Services.Models.ScDevice;

namespace Lacey.Medusa.MakeMoney.Services.Services
{
    public interface IMmStoreService
    {
        void SaveScDevice(ScDeviceResponse scDevice);

        ScDeviceResponse GetScDevice();
    }
}
namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface IVideoObfuscateService
    {
        void Obfuscate(string inputFilePath, string outputFilePath);
    }
}
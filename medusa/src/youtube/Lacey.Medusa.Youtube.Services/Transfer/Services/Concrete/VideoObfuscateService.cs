using System;
using System.IO;
using System.Reflection;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services.Concrete
{
    public sealed class VideoObfuscateService : IVideoObfuscateService
    {
        public void Obfuscate(string inputFilePath, string outputFilePath)
        {
            var currentFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var inputFile = new MediaFile { Filename = inputFilePath };
            var outputFile = new MediaFile { Filename = outputFilePath };

            using (var engine = new Engine(Path.Combine(currentFolder, "ffmpeg.exe")))
            {
                engine.ConvertProgressEvent += OnConvertProgress;
                engine.ConversionCompleteEvent += OnConversionComplete;
                engine.GetMetadata(inputFile);

                var options = new ConversionOptions();

                //// First parameter requests the starting frame to cut the media from.
                //// Second parameter requests how long to cut the video.
                options.CutMedia(
                    TimeSpan.FromSeconds(0), 
                    inputFile.Metadata.Duration.Add(TimeSpan.FromSeconds(-2)));

                engine.Convert(inputFile, outputFile, options);
            }
        }

        private void OnConversionComplete(object sender, ConversionCompleteEventArgs e)
        {
            Console.WriteLine($"{(int)(e.ProcessedDuration.TotalSeconds / e.TotalDuration.TotalSeconds * 100)}%");
        }

        private void OnConvertProgress(object sender, ConvertProgressEventArgs e)
        {
            Console.WriteLine($"{(int)(e.ProcessedDuration.TotalSeconds / e.TotalDuration.TotalSeconds * 100)}%");
        }
    }
}
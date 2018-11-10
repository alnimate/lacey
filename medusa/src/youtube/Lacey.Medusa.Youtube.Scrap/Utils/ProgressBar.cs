using System;
using Lacey.Medusa.Common.Extensions.Base;

namespace Lacey.Medusa.Youtube.Scrap.Utils
{
    public class ProgressBar : IProgress<double>, IDisposable
    {
        private const int MaxBars = 25;

        private double progress;
        private int barsDrawn;
        private int barsOffset;

        public ProgressBar()
        {
            Initialize();
        }

        private void Initialize()
        {
            // Create empty progress bar
            Console.Write('[');
            barsOffset = Console.CursorLeft;
            Console.Write(' '.Repeat(MaxBars));
            Console.Write(']');
        }

        private void DrawProgress()
        {
            // Draw bars
            var bars = (int) Math.Floor(progress * MaxBars);
            for (var i = barsDrawn; i < bars; i++)
            {
                Console.SetCursorPosition(barsOffset + i, Console.CursorTop);
                Console.Write('-');
            }

            barsDrawn = bars;

            // Draw text
            Console.SetCursorPosition(barsOffset + MaxBars + 3, Console.CursorTop);
            Console.Write($"{progress:P0}");
        }

        public void Report(double value)
        {
            progress = value;
            DrawProgress();
        }

        public void Dispose()
        {
            Console.WriteLine();
        }
    }
}
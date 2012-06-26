using System;

namespace Zork.ConsoleApp.Utilities
{
    internal class TerminalColor : IDisposable
    {
        private ConsoleColor originalBackgroundColor;
        private ConsoleColor originalForegroundColor;

        public TerminalColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            originalBackgroundColor = Console.BackgroundColor;
            originalForegroundColor = Console.ForegroundColor;
            SetColor(foregroundColor, backgroundColor);
        }

        public void Dispose()
        {
            SetColor(originalForegroundColor, originalBackgroundColor);
        }

        private void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }
    }
}
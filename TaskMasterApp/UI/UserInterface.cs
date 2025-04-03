using System;
using System.IO;

namespace TaskMasterApp.UI
{
    /// <summary>
    /// Handles all user input/output logic for the console UI.
    /// Wraps input/output streams for testability and separation of concerns.
    /// </summary>
    public class UserInterface
    {
        private readonly TextReader _input;
        private readonly TextWriter _output;

        /// <summary>
        /// Initializes the interface with injected input/output streams.
        /// Supports swapping Console with mocks for testing.
        /// </summary>
        public UserInterface(TextReader input, TextWriter output)
        {
            _input = input;
            _output = output;
        }

        /// <summary>
        /// Writes text to the output stream without a newline.
        /// </summary>
        public void Write(string text) => _output.Write(text);

        /// <summary>
        /// Writes text to the output stream with a newline.
        /// </summary>
        public void WriteLine(string text) => _output.WriteLine(text);

        /// <summary>
        /// Reads a line of input or returns an empty string if null.
        /// </summary>
        public string ReadLine() => _input.ReadLine() ?? string.Empty;

        /// <summary>
        /// Prompts the user with a message and returns their input.
        /// </summary>
        public string Prompt(string message)
        {
            _output.Write(message);
            return ReadLine();
        }

        /// <summary>
        /// Displays a pause message and waits for Enter key.
        /// </summary>
        public void Pause(string message = "Press Enter to continue...")
        {
            _output.WriteLine(message);
            _input.ReadLine();
        }

        /// <summary>
        /// Displays a formatted header to visually separate UI sections.
        /// </summary>
        public void WriteHeader(string title)
        {
            _output.WriteLine($"\n=== {title} ===");
        }

        /// <summary>
        /// Writes a message in green to indicate success or status.
        /// </summary>
        public void WriteSuccess(string message)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            _output.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        /// Writes a message in red to indicate an error or invalid input.
        /// </summary>
        public void WriteError(string message)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            _output.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }
    }
}

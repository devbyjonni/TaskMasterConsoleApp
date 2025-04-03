using System;
using System.IO;

namespace TaskMasterApp.UI
{
    public class UserInterface
    {
        private readonly TextReader _input;
        private readonly TextWriter _output;

        public UserInterface(TextReader input, TextWriter output)
        {
            _input = input;
            _output = output;
        }

        public void Write(string text) => _output.Write(text);
        public void WriteLine(string text) => _output.WriteLine(text);

        public string ReadLine() => _input.ReadLine() ?? string.Empty;

        public string Prompt(string message)
        {
            _output.Write(message);
            return ReadLine();
        }

        public void Pause(string message = "Press Enter to continue...")
        {
            _output.WriteLine(message);
            _input.ReadLine();
        }

        public void WriteHeader(string title)
        {
            _output.WriteLine($"\n=== {title} ===");
        }
    }
}

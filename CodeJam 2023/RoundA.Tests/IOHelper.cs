using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundA.Tests
{
    public class IOHelper : Program.ConsoleIO
    {
        public string[] InputLines { get; set; }
        public string ExpectedOutput { get; set; }
        public StringBuilder Output { get; set; }

        private int LineToRead = 0;

        public IOHelper(string Input, string ExpectedOutput)
        {
            this.InputLines = Input.Split(Environment.NewLine);
            this.ExpectedOutput = ExpectedOutput;
            Output = new StringBuilder();
        }

        public override string ReadLine()
        {
            return InputLines[LineToRead++];
        }

        public override void WriteLine(string text)
        {
            Output.AppendLine(text);
        }
    }
}

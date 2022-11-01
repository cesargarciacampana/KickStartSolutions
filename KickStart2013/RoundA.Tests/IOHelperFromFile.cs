using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundA.Tests
{
    internal class IOHelperFromFile : IOHelper
    {
        public IOHelperFromFile(string InputFile, string ExpectedOutputFile)
            :base(File.ReadAllText(InputFile).Replace("\n", Environment.NewLine),
                 File.ReadAllText(ExpectedOutputFile).Replace("\n", Environment.NewLine))
        {

        }
    }
}

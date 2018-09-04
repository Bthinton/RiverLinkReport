using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLinkReport.CLI
{
    public class ProgramOptions
    {
        [Option('o', "operation", 
            HelpText = "Will Login, Get Data, and Insert data to database")]
        public string Operation { get; set; }

        [Option('u', "username",
            HelpText = "The service name as it appears in the barracuda")]
        public string Username { get; set; }

        [Option('p', "password",
            HelpText = "The service name as it appears in the barracuda")]
        public string Password { get; set; }
    }
}

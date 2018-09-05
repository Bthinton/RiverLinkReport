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
            HelpText = "This is the RiverLink account login")]
        public string Username { get; set; }

        [Option('p', "password",
            HelpText = "This is the RiverLink account password")]
        public string Password { get; set; }
    }
}

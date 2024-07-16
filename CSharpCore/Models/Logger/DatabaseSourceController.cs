using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.Extensions.DiagnosticAdapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Logger
{
    public class DatabaseSourceConllector
    {
        [DiagnosticName("CommandExecution")]
        public void OnCommandExecute(CommandType commandType,string commandText) 
        {
            Console.WriteLine($"Event Name: CommandExecution");
            Console.WriteLine($"Command Type:{commandType}");
            Console.WriteLine($"Command Text:{commandText}");
        }
    }
}

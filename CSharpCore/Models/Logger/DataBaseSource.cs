using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Logger
{
    [EventSource(Name = "Arrach-Data-SqlClient")]
    public class DataBaseSource : EventSource
    {
        public static readonly DataBaseSource Instance = new DataBaseSource();

        private DataBaseSource() { }

        [Event(1)]
        public void OnEventCommand(System.Data.CommandType commandType,string commandText)
        {
            WriteEvent(1, commandType, commandText);
        }
    }
}

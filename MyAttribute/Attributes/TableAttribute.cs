using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Attributes
{
    public class TableAttribute:Attribute
    {
        public TableAttribute(string _tableName) {
            TableName = _tableName;
        }
        public string TableName { get; set; }

        public string GetTableName() {
            return TableName;
        }
    }
}

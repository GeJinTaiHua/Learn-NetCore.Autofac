using System;
using System.Collections.Generic;
using System.Text;

namespace Processor.Database
{
    public class OracleDatabase : IDatabase
    {
        public string Name
        {
            get { return "oracle"; }
        }

        public string Select(string commandText)
        {
            return string.Format("'{0}' is a query sql in {1}!", commandText, Name);
        }

        public string Insert(string commandText)
        {
            return string.Format("'{0}' is a insert sql in {1}!", commandText, Name);
        }

        public string Update(string commandText)
        {
            return string.Format("'{0}' is a update sql in {1}!", commandText, Name);
        }

        public string Delete(string commandText)
        {
            return string.Format("'{0}' is a delete sql in {1}!", commandText, Name);
        }
    }
}

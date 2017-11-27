using System;
using System.Collections.Generic;
using System.Text;

namespace Processor.Database
{
    public class DatabaseManager
    {
        IDatabase _database;

        public DatabaseManager(IDatabase database)
        {
            _database = database;
        }

        public string Search(string commandText)
        {
            return _database.Select(commandText);
        }

        public string Add(string commandText)
        {
            return _database.Insert(commandText);
        }

        public string Save(string commandText)
        {
            return _database.Update(commandText);
        }

        public string Remove(string commandText)
        {
            return _database.Delete(commandText);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Processor.Database
{
    public interface IDatabase
    {
        string Name { get; }

        string Select(string commandText);

        string Insert(string commandText);

        string Update(string commandText);

        string Delete(string commandText);
    }
}

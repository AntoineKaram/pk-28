using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT.Data
{
    public interface IdbManager
    {
        IDbConnection GetConnection(string connectionString);
        T ExecuteSingleton<T>(string procedureName, Func<IDataReader, T> mapper, Dictionary<string, object> paramsDictionnary = null);
        List<T> ExecuteCollection<T>(string procedureName, Func<IDataReader, T> mapper, Dictionary<string, object> paramsDictionnary = null);
        IDbCommand GetCommand(string procedureName, IDbConnection con, Dictionary<string, object> paramsDictionnary = null);

        bool ExecuteCommand(string procedureName, Dictionary<string, object> paramsDictionnary = null);
    }
}

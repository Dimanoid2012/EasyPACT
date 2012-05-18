using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using EasyPACT.Exceptions;
using System.Linq;
using System.Xml.Linq;

namespace EasyPACT
{
    public static class Database
    {
        private const string ConnectionString = "Data Source=|DataDirectory|\\EasyPACT.sdf";
        static private readonly SqlCeConnection Connect = new SqlCeConnection(ConnectionString);
        static public void Open()
        {
            try
            {
                Connect.Open();
            }
            catch
            {
                throw new InvalidDatabaseConnectionOpenException("Не получается открыть файл базы данных!");
            }
        }
        /*static public SqlCeDataReader Query2(string query)
        {
            var command = new SqlCeCommand(query, Connect);
            var reader = command.ExecuteReader();
            reader.Read();
            return reader;
        }*/
        static public List<List<string>> Query(string query)
        {
            Open();
            var command = new SqlCeCommand(query, Connect);
            var adapter = new SqlCeDataAdapter(command);
            return ProcessingQuery(adapter);
        }
        static private List<List<string>> ProcessingQuery(SqlCeDataAdapter adapter)
        {
            var dataSet = new DataSet("answer");
            adapter.Fill(dataSet);
            Close();
            var list = new List<List<string>>();
            var schema = XDocument.Parse(dataSet.GetXml());
            var elements = schema.Root.Elements("Table");
            var listCount = elements.First().Nodes().Count();
            for (int i = 0; i < listCount; i++)
                list.Add(new List<string>());
            foreach (var element in elements)
                for (int i = 0; i < element.Nodes().Count(); i++)
                    list[i].Add(element.Elements().Nodes().ToArray()[i].ToString());
            return list;
        }
        /*static public string Select(string table, string fields, string conditions)
        {
            var query = string.Format("SELECT {0} FROM {1} WHERE {2}", fields, table, conditions);
            Open();
            SqlCeDataReader ans;
            try
            {
                ans = Query(query);
            }
            catch
            {
                throw new InvalidDatabaseQueryException("Некорректный запрос к базе данных!");
            }
            return "asd";
        }*/
        static public void Close()
        {
            Connect.Close();
        }
    }
}

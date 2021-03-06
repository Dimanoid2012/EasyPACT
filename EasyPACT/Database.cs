﻿using System.Collections.Generic;
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
        /// <summary>
        /// Открывает соединение с базой данных.
        /// </summary>
        static private void Open()
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
        /// <summary>
        /// Выполняет запрос к базе данных.
        /// </summary>
        /// <param name="query">SQL-запрос.</param>
        /// <returns>Возвращает ответ базы данных.</returns>
        static public List<List<string>> Query(string query)
        {
            var ret = new List<List<string>>();
            var command = new SqlCeCommand();
            command.Connection = Connect;
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            Open();
            switch(query.Split(' ')[0].ToLower())
            {
                case "select":
                    var adapter = new SqlCeDataAdapter(command);
                    ret = Select(adapter);
                    return ret;
                case "insert":
                    if (Insert(command))
                    {
                        ret.Add(new List<string>());
                        ret[0].Add("1");
                    }
                    else
                    {
                        ret.Add(new List<string>());
                        ret[0].Add("0");
                    }
                    return ret;
                default:
                    ret.Add(new List<string>());
                    ret[0].Add("0");
                    return ret;
            }
        }
        /// <summary>
        /// Выборка из базы данных.
        /// </summary>
        /// <param name="adapter">Адапер.</param>
        /// <returns>Возвращает ответ от базы данных.</returns>
        static private List<List<string>> Select(SqlCeDataAdapter adapter)
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
        /// <summary>
        /// Добавляет запись в базу данных.
        /// </summary>
        /// <param name="command">Команда добавления.</param>
        /// <returns>Возвращает успешность выполнения запроса.</returns>
        static private bool Insert(SqlCeCommand command)
        {
            command.ExecuteNonQuery();
            return true;
        }
        /// <summary>
        /// Закрывает соединение с базой данных.
        /// </summary>
        static private void Close()
        {
            Connect.Close();
        }
    }
}

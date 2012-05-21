using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Globalization;

namespace EasyPACT
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Разделитель - точка
            var inf = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            System.Threading.Thread.CurrentThread.CurrentCulture = inf;
            inf.NumberFormat.NumberDecimalSeparator = ".";
            // Вывод курсовой
            //var ans = Database.Query("insert into liquid_list(name,formula,molar_mass) values('Бутан','C4H10',58.1)");
            //var ans = Database.Query("select * from liquid_list");
            string ConnectionString = "Data Source=|DataDirectory|\\EasyPACT.sdf";
            SqlCeConnection Connect = new SqlCeConnection(ConnectionString);
            Connect.Open();
            var command = Connect.CreateCommand();
            command.CommandTimeout = Connect.ConnectionTimeout;
            command.Connection = Connect;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from liquid_list";
            var table = new DataTable();
            var adapter = new SqlCeDataAdapter(command);
            adapter.Fill(table);
            command.CommandText = "insert into liquid_list ([name],[formula],molar_mass) values('Бутан','C4H10',58.01)";
            adapter.UpdateCommand = command;
            var row = table.NewRow();
            row.BeginEdit();
            row.SetField("name", "Бутан");
            row.SetField("formula", "C4H10");
            row.SetField("molar_mass", Convert.ToSingle(58.01));
            row.EndEdit();
            table.Rows.Add(row);
            table.AcceptChanges();
            adapter.Update(table);
            table.AcceptChanges();  
            //table.AcceptChanges();
            
            
            Connect.Close();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

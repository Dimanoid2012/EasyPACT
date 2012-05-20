using System;
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
            var ans = Database.Query("select * from liquid_list");
            Console.ReadKey();
        }
    }
}

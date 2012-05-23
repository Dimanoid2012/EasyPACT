using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyPACT
{
    /// <summary>
    /// Данный класс позволяет вычислять любые характеристики
    /// жидкостей, трубопроводов, потоков и т.д.
    /// </summary>
    public static class Calculation
    {
        static private double LinearInterpolation(List<List<double>> list, double value)
        {
            // Выбираем известный аргумент слева от данного значения
            var xLeft = list[0].Last(a => a <= value);
            // Выбираем известный аргумент справа от данного значения
            var xRight = list[0].First(a => a >= value);
            // Выбираем значение при левом аргументе
            var yLeft = list[1].ElementAt(list[0].IndexOf(xLeft));
            // Выбираем значение при правом аргументе
            var yRight = list[1].ElementAt(list[0].IndexOf(xRight));
            // Если аргумент совпадает с узловой точкой, то возвращаем значение
            if (value == xLeft)
            {
                return yLeft;
            }
            if (value == xRight)
            {
                return yRight;
            }
            // Иначе вычисляем значение
            return yLeft + (yRight - yLeft)/(xRight - xLeft)*(value - xLeft);
        }
        /// <summary>
        /// Вычисляет плотность жидкости методом линейной интерполяции по узловым точкам,
        /// содержащимся в базе данных.
        /// </summary>
        /// <param name="liq">Объект, описывающий жидкость.</param>
        /// <returns>Возвращает значение плотности жидкости при ее температуре в килограммах на кубометр.</returns>
        static public double Density(LiquidPure liq)
        { 
            var table = Database.Query(String.Format("SELECT temperature,density FROM IV WHERE id='{0}'", liq.Id));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return LinearInterpolation(data,liq.Temperature);
        }
        /// <summary>
        /// Вычисляет динамический коэффициент вязкости жидкости методом линейной интерполяции по узловым точкам,
        /// содержащимся в базе данных.
        /// </summary>
        /// <param name="liq">Объект, описывающий жидкость.</param>
        /// <returns>Возвращает значение динамического коэффициента вязкости жидкости при ее температуре в мПа*с.</returns>
        static public double ViscosityDynamic(LiquidPure liq)
        {
            var table = Database.Query(String.Format("SELECT temperature,viscosity FROM IX WHERE id='{0}'", liq.Id));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return LinearInterpolation(data, liq.Temperature);
        }
        /// <summary>
        /// Вычисляет температуру кипения жидкости.
        /// </summary>
        /// <param name="liq">Объект, описывающий жидкость.</param>
        /// <returns>Возвращает значение температуры кипения жидкости при ее давлении в градусах Цельсия.</returns>
        static public double BoilingPoint(LiquidPure liq)
        {
            var table =
                Database.Query(
                    String.Format("SELECT pressure,boiling_point FROM boiling_points_from_pressure WHERE id='{0}'",
                                  liq.Id));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return LinearInterpolation(data, liq.Pressure);
        }
        /// <summary>
        /// Вычисляет температуру кипения жидкой смеси.
        /// </summary>
        /// <param name="Mix">Объект, описывающий жидкую смесь.</param>
        /// <returns>Возвращает значение температуры кипения жидкой смеси в градусах Цельсия в зависимости от давления и состава.</returns>
        static public double BoilingPointMix(LiquidMix mix)
        {
            var table =
                Database.Query(
                    String.Format(
                        "SELECT x,boiling_point FROM boiling_points_from_composition WHERE id1='{0}' AND id2='{1}' AND pressure={2}",
                        mix.LB.Id, mix.HB.Id, mix.Pressure));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return LinearInterpolation(data, mix.MolarFraction*100);
        }
        /// <summary>
        /// Вычисляет молярную массу жидкости.
        /// </summary>
        /// <param name="liq">Объект, описывающий жидкость.</param>
        /// <returns>Возвращает значение молярной массы жидкости в кг/кмоль.</returns>
        static public double MolarMass(LiquidPure liq)
        {
            var table =
                Database.Query(
                    String.Format(
                        "SELECT molar_mass FROM liquid_list WHERE id='{0}'", liq.Id));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return data[0][0];
        }
        /// <summary>
        /// Вычисляет коэффициент теплопроводности трубопровода.
        /// </summary>
        /// <param name="pip">Объект, описывающий трубопровод.</param>
        /// <returns>Возвращает значение коэффициента теплопроводности в Вт/(м*К).</returns>
        static public double ThermalConductivity(Pipeline pip)
        {
            var table =
                Database.Query(
                    String.Format(
                        "SELECT conductivity_min,conductivity_max FROM XXVIII WHERE id='{0}'", pip.MaterialId));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return (data[0][0] + data[1][0])/2;
        }
        /// <summary>
        /// Вычисляет коэффициент теплопроводности трубопровода.
        /// </summary>
        /// <param name="pip">Объект, описывающий трубопровод.</param>
        /// <returns>Возвращает значение коэффициента теплопроводности в Вт/(м*К).</returns>
        static public double RoughnessOfWalls(Pipeline pip)
        {
            var table =
                Database.Query(
                    String.Format(
                        "SELECT roughness_of_walls_min,roughness_of_walls_max FROM XII WHERE id='{0}'", pip.Type));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return (data[0][0] + data[1][0]) / 2 / 1000;
        }
        /// <summary>
        /// Вычисляет коэффициент местного сопротивления.
        /// </summary>
        /// <param name="type">Тип местного сопротивления и его параметры.</param>
        /// <returns>Возвращает значение коэффициента местного сопротивления.</returns>
        static public double FactorOfLocalResistance(double[] type)
        {
            var id = Convert.ToInt32(type[0]);
            List<List<double>> data;
            List<List<string>> table;
            switch (id)
            {
                case 1:
                    table = Database.Query(String.Format("SELECT koefficient FROM XIII_entrance WHERE id='{0}'",
                                                         type[1]));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return data[0][0];
                case 2:
                    table = Database.Query(String.Format("SELECT koefficient FROM XIII_exit WHERE id='{0}'",
                                                          type[1]));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return data[0][0];
                case 3:
                    if (type.Length == 2)
                    {
                        table =
                            Database.Query(String.Format("SELECT m,koefficient FROM XIII_diaphragm"));
                        data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                        return LinearInterpolation(data, type[1]);
                    }
                    var m = Math.Pow(type[1]/type[2], 2);
                    table =
                        Database.Query(String.Format("SELECT m,koefficient FROM XIII_diaphragm"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return LinearInterpolation(data, m);
                case 4:
                    table =
                        Database.Query(String.Format("SELECT angle,A FROM XIII_diversion_A"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    var A = LinearInterpolation(data, type[1]);
                    table =
                        Database.Query(String.Format("SELECT R_over_d,B FROM XIII_diversion_B"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    var B = LinearInterpolation(data, type[2]);
                    return A*B;
                case 5:
                    table =
                        Database.Query(
                            String.Format("SELECT D_condition,koefficient FROM XIII_bend WHERE"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return LinearInterpolation(data, type[1]);
                case 6:
                    table =
                        Database.Query(
                            String.Format("SELECT D,koefficient FROM XIII_faucet_normal"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return LinearInterpolation(data, type[1]);
                case 7:
                    table =
                        Database.Query(
                            String.Format(
                                "SELECT D,koefficient FROM XIII_faucet_direct_flow_koef"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    var koef = LinearInterpolation(data, type[1]);
                    if(type[2] < 300000)
                    {
                        table =
                            Database.Query(
                                String.Format("SELECT Re,K FROM XIII_faucet_direct_flow_K"));
                        data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                        koef *= LinearInterpolation(data, type[2]);
                    }
                    return koef;
                case 8:
                    table =
                        Database.Query(
                            String.Format("SELECT D_condition,koefficient FROM XIII_crane"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return (type[1] > data[0].Max()) ? data[0].Max() : LinearInterpolation(data, type[1]);
                case 9:
                    table =
                        Database.Query(
                            String.Format("SELECT D_condition,koefficient FROM XIII_latch"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return (type[1] > data[0].Max()) ? data[0].Max() : LinearInterpolation(data, type[1]);
                /*case 10:
                    table =
                        Database.Query(
                            String.Format(
                                "SELECT koefficient FROM XIII_expansion"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return data[0][0];
                case 11:
                    table =
                        Database.Query(
                            String.Format(
                                "SELECT koefficient FROM XIII_waist"));
                    data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
                    return data[0][0];*/
                default:
                    throw new Exception("Неправильный индекс местного сопротивления!");
            }    
        }
        static public string Name(Liquid liq)
        {
            if(liq.GetType().Name=="LiquidPure")
                return Database.Query(string.Format("SELECT name FROM liquid_list WHERE id='{0}'", liq.Id))[0][0];
            var name1 = Database.Query(string.Format("SELECT name FROM liquid_list WHERE id='{0}'", liq.Id.Split(',')[0]))[0][0];
            var name2 = Database.Query(string.Format("SELECT name FROM liquid_list WHERE id='{0}'", liq.Id.Split(',')[1]))[0][0];
            return name1 + " - " + name2;
        }
        static public double VaporizationHeat(Liquid liq)
        {
            var table = Database.Query(String.Format("SELECT temperature,vaporization_heat FROM XLV WHERE id='{0}'", liq.Id));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return LinearInterpolation(data, liq.Temperature);
        }
        static public double Pressure(int id,double t)
        {
            var table =
                Database.Query(
                    String.Format("SELECT boiling_point,pressure FROM boiling_points_from_pressure WHERE id='{0}'",
                                  id));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return LinearInterpolation(data, t);
        }
        static public double ThermalCapacity(LiquidPure liq)
        {
            var table = Database.Query(String.Format("SELECT temperature,thermal_capacity FROM thermal_capacity WHERE id='{0}'", liq.Id));
            var data = table.Select(list => list.ConvertAll(Convert.ToDouble)).ToList();
            return LinearInterpolation(data, liq.Temperature);
        }
        static public double ThermalCapacity(LiquidMix liq)
        {
            return liq.MassFraction*liq.LB.ThermalCapacity + (1 - liq.MassFraction)*liq.HB.ThermalCapacity;
        }
    }
}

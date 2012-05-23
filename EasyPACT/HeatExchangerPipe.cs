using System;

namespace EasyPACT
{
    public class HeatExchangerPipe
    {
        public int Id { get; private set; }
        public double Diameter { get; private set; }
        public int NumberOfPipes { get; private set; }
        public int NumberOfCourses { get; private set; }
        public double PipesLength { get; private set; }
        public double SurfaceArea { get; private set; }
        public Pipeline Pipeline { get; private set; }
        public Pipeline Case { get; private set; }
        public Liquid LiquidIn { get; private set; }
        public Liquid LiquidEx { get; private set; }
        public LiquidInPipeline LiquidInPipeline { get; private set; }
        public LiquidInPipeline LiquidInCase { get; private set; }
        /// <summary>
        /// Кожухотрубчатый теплообменник.
        /// </summary>
        /// <param name="id">Идентификатор ТО.</param>
        public HeatExchangerPipe(int id)
        {
            this.Id = id;
            var data =
                Database.Query(
                    String.Format(
                        "select diameter,number_of_pipes,number_of_courses,length_of_pipes,surface_area from XXXIV where id={0}",
                        id));
            this.Diameter = Convert.ToDouble(data[0][0]);
            this.NumberOfPipes = Convert.ToInt32(data[1][0]);
            this.NumberOfCourses = Convert.ToInt32(data[2][0]);
            this.PipesLength = Convert.ToDouble(data[3][0]);
            this.SurfaceArea = Convert.ToDouble(data[4][0]);
            this.Pipeline = new PipelineRound(33,1,0.025,2.5,this.PipesLength);
            this.Case = new PipelineRound(33, 1, this.Diameter, 0, 1);
        }
        /// <summary>
        /// Теплота, передающаяся в теплообменнике.
        /// </summary>
        public double Heat
        {
            get { return this.LiquidInCase.MassFlow*this.LiquidInCase.Liquid.VaporizationHeat; }
        }
        /// <summary>
        /// Средняя движущая сила процесса теплопередачи.
        /// </summary>
        public double Propellent
        {
            get
            {
                /*var t1 = this.LiquidInCase.Liquid.Temperature - this.LiquidInPipeline.Liquid.Temperature;
                var t2 = this.LiquidInCase.Liquid.Temperature - this.LiquidInPipeline.Liquid.BoilingPoint;
                return (t1 - t2)/Math.Log(t1/t2);*/
                return this.Heat/this.HeatTransferKoefficient/this.SurfaceArea;
            }
        }
        /// <summary>
        /// Удельная тепловая нагрузка.
        /// </summary>
        private double UnitThermalLoad
        {
            get { return this.Heat/this.SurfaceArea; }
        }
        /// <summary>
        /// Коэффициент теплопередачи.
        /// </summary>
        public double HeatTransferKoefficient
        {
            get
            {
                var liq = new LiquidPure(this.LiquidInCase.Liquid.Id, this.LiquidInCase.Liquid.Temperature,
                                         this.LiquidInCase.Liquid.Pressure);

                var a1 = 1.21*liq.ThermalConductivity*
                         Math.Pow(liq.Density*liq.VaporizationHeat*9.81/liq.ViscosityDynamic/this.Pipeline.Length, 1/3)*
                         this.UnitThermalLoad;
                var a2 = this.LiquidInCase.Nu*this.LiquidInCase.Liquid.ThermalConductivity/
                         this.LiquidInCase.Pipeline.Diameter;
                return 1/(1/a1 + 8.404e-4 + 1/a2);
            }
        }
        public Liquid Run()
        {
            var t1 = this.LiquidInCase.Liquid.Temperature - this.LiquidInPipeline.Liquid.Temperature;
            var dt = this.Propellent;
            double a = 0;
            double b = -Math.Exp(-(t1 - dt * Math.Log(t1)) / dt) / dt;
            for (int i = 1; i < 15; i++)
            {
                var fact = 1;
                for (int j = 2; j < i; j++)
                    fact *= j;
                a += Math.Pow(-1, i - 1) * Math.Pow(i, i - 2) / fact * Math.Pow(b, i);
            }
            //a = b - Math.Pow(b, 2) + 1.5 * Math.Pow(b, 3) - 8 / 3 * Math.Pow(b, 4) + 125 / 24 * Math.Pow(b, 5) -
            //    54 / 5 * Math.Pow(b, 6) + 16807 / 720 * Math.Pow(b, 7);
            var t2 = Math.Exp(-(t1 + 36.927 * a - dt * Math.Log(t1)) / dt);
            var t = t2 - this.LiquidInPipeline.Liquid.Temperature;
            return new LiquidPure(this.LiquidInPipeline.Liquid.Id, t, this.LiquidInPipeline.Liquid.Pressure);
        }
        /// <summary>
        /// Задает жидкость в трубах теплообменника.
        /// </summary>
        /// <param name="liq">Жидкость.</param>
        public void SetLiquidInPipes(Liquid liq)
        {
            this.LiquidIn = liq;
            this.LiquidInPipeline = new LiquidInPipeline(liq, this.Pipeline);
        }
        /// <summary>
        /// Задает жидкость в кожухе теплообменника.
        /// </summary>
        /// <param name="liq">Жидкость.</param>
        public void SetLiquidInCase(Liquid liq)
        {
            this.LiquidIn = liq;
            this.LiquidInCase = new LiquidInPipeline(liq, this.Case);
        }
    }
}

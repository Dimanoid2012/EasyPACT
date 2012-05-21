using System;

namespace EasyPACT
{
    public class HeatExchangerPipe
    {
        private int _id;
        private double _diameter;
        private int _numberOfPipes;
        private int _numberOfCourses;
        private double _pipesLength;
        private double _surfaceArea;
        private Pipeline _pipeline;
        private Pipeline _case;
        private Liquid _liquidIn;
        private Liquid _liquidEx;
        private LiquidInPipeline _liquidInPipeline;
        private LiquidInPipeline _liquidInCase;
        /// <summary>
        /// Кожухотрубчатый теплообменник.
        /// </summary>
        /// <param name="id">Идентификатор ТО.</param>
        public HeatExchangerPipe(int id)
        {
            this._id = id;
            var data =
                Database.Query(
                    String.Format(
                        "select diameter,number_of_pipes,number_of_courses,length_of_pipes,surface_area from XXXIV where id={0}",
                        id));
            this._diameter = Convert.ToDouble(data[0][0]);
            this._numberOfPipes = Convert.ToInt32(data[1][0]);
            this._numberOfCourses = Convert.ToInt32(data[2][0]);
            this._pipesLength = Convert.ToDouble(data[3][0]);
            this._surfaceArea = Convert.ToDouble(data[4][0]);
            this._pipeline = new PipelineRound(33,1,0.025,2.5,this._pipesLength);
            this._case = new PipelineRound(33, 1, this._diameter, 0, 1);
        }
        /// <summary>
        /// Задает жидкость в трубах теплообменника.
        /// </summary>
        /// <param name="liq">Жидкость.</param>
        public void SetLiquidInPipes(Liquid liq)
        {
            this._liquidIn = liq;
            this._liquidInPipeline = new LiquidInPipeline(liq, this._pipeline);
        }
        /// <summary>
        /// Задает жидкость в кожухе теплообменника.
        /// </summary>
        /// <param name="liq">Жидкость.</param>
        public void SetLiquidInCase(Liquid liq)
        {
            this._liquidIn = liq;
            this._liquidInCase = new LiquidInPipeline(liq, this._case);
        }
    }
}

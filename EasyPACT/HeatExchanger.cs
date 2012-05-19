namespace EasyPACT
{
    /// <summary>
    /// Класс, описывающий теплообменник типа "труба в трубе"
    /// </summary>
    public class HeatExchangerPipeInPipe
    {
        protected LiquidInPipeline _InPipe;
        protected LiquidInPipeline _ExPipe;
        //protected double _DiameterOfACasing;
        //protected int _CountOfCourses;
        //protected int _CountOfPipes;
        //protected double _LengthOfPipes;
        protected double _SurfaceArea;
        protected bool _IsContraflow;
        private HeatExchangerPipeInPipe() { }
        protected HeatExchangerPipeInPipe(LiquidInPipeline inPipe, LiquidInPipeline exPipe, bool isContraflow)
        {
            this._InPipe = inPipe;
            this._ExPipe = exPipe;
            this._IsContraflow = isContraflow;
        }
    }
}

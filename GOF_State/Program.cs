/// <summary>
/// позволяет объекту изменять свое поведение в зависимости от внутреннего состояния.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        var water = new Water(new LiquidState());
        water.Frost();
        water.Heart();
        water.Heart();
        water.Heart();
    }

    class Water
    {
        public IWaterState waterState { get; set; }
        public Water(IWaterState waterState)
        {
            this.waterState = waterState;
        }
        public void Heart()
        {
            waterState = waterState.Heat(this);
        }
        public void Frost()
        {
            waterState = waterState.Frost(this);
        }
    }

    interface IWaterState
    {
        IWaterState Heat(Water water);
        IWaterState Frost(Water water);
    }

    class LiquidState : IWaterState
    {
        public IWaterState Frost(Water water)
        {
            Console.WriteLine("Превращаем жидкость в лед");
            return new IceState();
        }

        public IWaterState Heat(Water water)
        {
            Console.WriteLine("Превращаем жидкость в газ");
            return new GasState();
        }
    }
    class GasState : IWaterState
    {
        public IWaterState Frost(Water water)
        {
            Console.WriteLine("Превращаем газ в жидкость");
            return new LiquidState();
        }

        public IWaterState Heat(Water water)
        {
            Console.WriteLine("Крепче нагреваем пар");
            return this;
        }
    }
    class IceState : IWaterState
    {
        public IWaterState Frost(Water water)
        {
            Console.WriteLine("Крепче морозим лед");
            return this;
        }

        public IWaterState Heat(Water water)
        {
            Console.WriteLine("Превращаем лед в жидкость");
            return new LiquidState();
        }
    }

}




///замена условных конструкций

//class Program
//{
//    static void Main(string[] args)
//    {
//        Water water = new Water(WaterState.LIQUID);
//        water.Heat();
//        water.Frost();
//        water.Frost();

//        Console.Read();
//    }
//}
//enum WaterState
//{
//    SOLID,
//    LIQUID,
//    GAS
//}
//class Water
//{
//    public WaterState State { get; set; }

//    public Water(WaterState ws)
//    {
//        State = ws;
//    }

//    public void Heat()
//    {
//        if (State == WaterState.SOLID)
//        {
//            Console.WriteLine("Превращаем лед в жидкость");
//            State = WaterState.LIQUID;
//        }
//        else if (State == WaterState.LIQUID)
//        {
//            Console.WriteLine("Превращаем жидкость в пар");
//            State = WaterState.GAS;
//        }
//        else if (State == WaterState.GAS)
//        {
//            Console.WriteLine("Повышаем температуру водяного пара");
//        }
//    }
//    public void Frost()
//    {
//        if (State == WaterState.LIQUID)
//        {
//            Console.WriteLine("Превращаем жидкость в лед");
//            State = WaterState.SOLID;
//        }
//        else if (State == WaterState.GAS)
//        {
//            Console.WriteLine("Превращаем водяной пар в жидкость");
//            State = WaterState.LIQUID;
//        }
//    }
//}
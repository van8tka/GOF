namespace GOF_Facade
{/// <summary>
/// позволяет скрыть сложность системы с помощью предоставления упрощенного интерфейса
/// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var facade = new Facade(new SysA(), new SysB(), new SysC());
            facade.Operation2();
            facade.Operation1();
        }

        class SysA
        {
            public void Run() => Console.WriteLine(this.GetType());
        }
        class SysB
        {
            public void Go() => Console.WriteLine(this.GetType());
        }
        class SysC
        {
            public void Handle() => Console.WriteLine(this.GetType());
        }

        class Facade
        {
            private SysA sysA;
            private SysB sysB;
            private SysC sysC;
            public Facade(SysA sysA, SysB sysB, SysC sysC)
            {
                this.sysA = sysA;
                this.sysB = sysB;
                this.sysC = sysC;
            }

            public void Operation1()
            {
                sysA.Run();
                sysB.Go();
                sysC.Handle();
            }
            public void Operation2()
            {
                sysB.Go();
                sysA.Run();
                sysA.Run();
                sysA.Run();
                sysB.Go();
            }
        }
    }
}
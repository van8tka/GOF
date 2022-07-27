namespace GOF_TemplateMethod
{
    /// <summary>
    /// определяет общий алгоритм поведения подклассов, 
    /// позволяя им переопределить отдельные шаги этого алгоритма без изменения его структуры.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var tm = new ConcreteMethod();
            tm.TemplateMethod();
        }

        abstract class TemplateMethodClass
        {
            public abstract void Operation_1();
            public abstract void Operation_2();
            public void CommonOperation()
            {
                Console.WriteLine("Common");
            }
            public void TemplateMethod()
            {
                CommonOperation();
                Operation_1();
                Operation_2();
            }
        }

        class ConcreteMethod : TemplateMethodClass
        {
            public override void Operation_1()
            {
                Console.WriteLine("operation_1");
            }

            public override void Operation_2()
            {
                Console.WriteLine("operation_2");
            }
        }
    }
}
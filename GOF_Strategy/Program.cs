/// <summary>
/// определяет набор алгоритмов, инкапсулирует каждый из них и обеспечивает их взаимозаменяемость. 
/// В зависимости от ситуации мы можем легко заменить один используемый алгоритм другим.
/// При этом замена алгоритма происходит независимо от объекта, который использует данный алгоритм.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        var str1 = new ConcreteStr_A();
        var str2 = new ConcreteStr_B();
        var client = new Client(str1);
        client.InvokeStrategy();
        client.strategy = str2;
        client.InvokeStrategy();
    }
    class Client
    {
        public IStrategy strategy { get; set; }
        public Client(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void InvokeStrategy()
        {
            strategy.Run();
        }
    }

    interface IStrategy
    {
        void Run();
    }
    class ConcreteStr_A : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("A");
        }
    }
    class ConcreteStr_B : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("B");
        }
    }
}
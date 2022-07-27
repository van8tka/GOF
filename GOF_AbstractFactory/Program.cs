/// <summary>
/// предоставляет интерфейс для создания семейств взаимосвязанных объектов
/// с определенными интерфейсами без указания конкретных типов данных объектов
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        var fac1 = new ConcreteFactory_1();
        var fac2 = new ConcreteFactory_2();
        var client = new Client(fac1);
        client.Run();
        client = new Client(fac2);
        client.Run();
    }
#region products
    abstract class AbstractProduct_A
    {
        public abstract void Interact(AbstractProduct_B pb);
    }
    abstract class AbstractProduct_B
    {
        public abstract void Interact(AbstractProduct_A pb);
    }

    class Product_A1 : AbstractProduct_A
    {
        public override void Interact(AbstractProduct_B pb)
        {
            Console.WriteLine("Product_A1 interact - " + pb.GetType());
        }
    }
    class Product_A2 : AbstractProduct_A
    {
        public override void Interact(AbstractProduct_B pb)
        {
            Console.WriteLine("Product_A2 interact - " + pb.GetType());
        }
    }

    class Product_B1 : AbstractProduct_B
    {
        public override void Interact(AbstractProduct_A pb)
        {
            Console.WriteLine("Product_B1 interact - " + pb.GetType());
        }
    }
    class Product_B2 : AbstractProduct_B
    {
        public override void Interact(AbstractProduct_A pb)
        {
            Console.WriteLine("Product_B2 interact - " + pb.GetType());
        }
    }
    #endregion
    #region abstract_factory
    abstract class AbstractFactory
    {
        public abstract AbstractProduct_A CreateProductA();
        public abstract AbstractProduct_B CreateProductB();
    }

    class ConcreteFactory_1 : AbstractFactory
    {
        public override AbstractProduct_A CreateProductA()
        {
           return new Product_A1();
        }

        public override AbstractProduct_B CreateProductB()
        {
            return new Product_B1();
        }
    }

    class ConcreteFactory_2 : AbstractFactory
    {
        public override AbstractProduct_A CreateProductA()
        {
            return new Product_A2();
        }

        public override AbstractProduct_B CreateProductB()
        {
            return new Product_B2();
        }
    }
    #endregion
    #region client
    class Client
    {
        AbstractProduct_A pa;
        AbstractProduct_B pb;
        public Client(AbstractFactory factory)
        {
            pa = factory.CreateProductA();
            pb = factory.CreateProductB();
        }

        public void Run()
        {
            pa.Interact(pb);
            pb.Interact(pa);
        }
    }
    #endregion
}


/// <summary>
/// определяет интерфейс для создания объектов некоторого класса,
/// но непосредственное решение о том, объект какого класса создавать
/// происходит в подклассах. То есть паттерн предполагает, 
/// что базовый класс делегирует создание объектов классам-наследникам.
/// </summary>
class Program
{

    static void Main(string[] args)
    {
        var creator = new Creator[2];
        creator[0] = new CreatorProduct_A();
        creator[1] = new CreatorProduct_B();
        Console.WriteLine(creator[0].CreateProduct().GetType());
        Console.WriteLine(creator[1].CreateProduct().GetType());
    }
    class Product
    {

    }

    class Product_A : Product
    {

    }
    class Product_B : Product
    {

    }

    abstract class Creator
    {
        public abstract Product CreateProduct();
    }

    class CreatorProduct_A : Creator
    {
        public override Product CreateProduct()
        {
            return new Product_A();
        }
    }

    class CreatorProduct_B : Creator
    {
        public override Product CreateProduct()
        {
            return new Product_B();
        }
    }
}

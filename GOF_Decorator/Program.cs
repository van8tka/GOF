
namespace GOF_Decorator
{
    /// <summary>
    /// позволяет динамически подключать к объекту дополнительную функциональность.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var italian = new ItalianPizza();
            var itWithMush = new MushromsPizza(italian);
            var rusPiz = new RussianPizza();
            var rusWithTomato = new TomatoPizza(rusPiz);
            var tomatoAndMush = new TomatoPizza(itWithMush);
            var tomatoAndMush2 = new TomatoPizza(tomatoAndMush);
            Console.WriteLine(italian.Name);
            Console.WriteLine(itWithMush.Name);
            Console.WriteLine(rusPiz.Name);
            Console.WriteLine(rusWithTomato.Name);
            Console.WriteLine(tomatoAndMush.Name);
            Console.WriteLine(tomatoAndMush2.Name);
        }
        #region OBjectWichMayBeDecorate
        abstract class Pizza
        {
            public Pizza(string name)
            {
                Name = name;
            }

            public  string Name { get; protected set; }
            public abstract int GetCost();
        }
 

        class ItalianPizza : Pizza
        {
            public ItalianPizza() : base("Italian pizza")
            {
            }

            public override int GetCost()
            {
                return 10;
            }
        }
        class RussianPizza : Pizza
        {
            public RussianPizza() : base("Russian pizza")
            {
            }

            public override int GetCost()
            {
                return 12;
            }
        }
        #endregion
        abstract class PizzaDecorator : Pizza
        {
            protected Pizza pizza;
            public PizzaDecorator(string name, Pizza pizza):base(name)
            {
                this.pizza = pizza;
            }
        }

        class TomatoPizza : PizzaDecorator
        {
            
            public TomatoPizza(Pizza pizza) : base(pizza.Name + ", with tomato", pizza)
            {
            }
           

            public override int GetCost()
            {
                return pizza.GetCost() + 4;
            }
        }

        class MushromsPizza : PizzaDecorator
        {
            public MushromsPizza(Pizza pizza) : base(pizza.Name +", with mushroms", pizza)
            {   
            }

            public override int GetCost()
            {
                return pizza.GetCost() + 7;
            }
        }
    }
}
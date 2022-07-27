namespace GOF_Mediatr
{
    /// <summary>
    /// обеспечивает взаимодействие множества объектов без необходимости ссылаться друг на друга.
    /// Тем самым достигается слабосвязанность взаимодействующих объектов.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var baryga = new BarygaMediator();
            Colleague farmer = new FarmerColleague(baryga);
            Colleague shop = new ShopColleague(baryga);
            baryga._farmer = farmer;
            baryga._shop = shop;

            farmer.Send("Яблоки поспели");
            shop.Send("Заберу оптом 10 тон яблок");
        }

        interface IMediator
        {
            void Send(string data, Colleague colleague);
        }

        class BarygaMediator : IMediator
        {
            public Colleague _farmer { get; set; }
            public Colleague _shop { get; set; }
 
            public void Send(string data, Colleague colleague)
            {
                if(colleague.Name == "farmer")
                {
                    _shop.Notify(data);
                }
                if (colleague.Name == "shop")
                {
                    _farmer.Notify(data);
                }
            }
        }

        #region colleague
        abstract class Colleague
        {
            protected IMediator m_mediator;
            public Colleague(string name, IMediator mediator)
            {
                Name = name;
                m_mediator = mediator;
            }
            public abstract void Notify(string data);
            public abstract void Send(string data);

            public string Name { get; }
        }

        class FarmerColleague : Colleague
        {
            public FarmerColleague(IMediator mediator):base("farmer", mediator)
            {
            }

            public override void Notify(string data)
            {
                Console.WriteLine(data);
            }

            public override void Send(string data)
            {
                m_mediator.Send(data, this);
            }
        }

        class ShopColleague : Colleague
        {
            public ShopColleague(IMediator mediator) : base("shop", mediator)
            {
            }

            public override void Notify(string data)
            {
                Console.WriteLine(data);
            }

            public override void Send(string data)
            {
                m_mediator.Send(data, this);
            }
        }
  #endregion
    }
}
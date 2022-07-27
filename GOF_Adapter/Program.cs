namespace GOF_Adapter
{
    /// <summary>
    /// Паттерн Адаптер (Adapter) предназначен для преобразования интерфейса одного класса в интерфейс другого
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            var vodila = new Vodila() { Transport = car };
            vodila.Control();
            var horse = new Horse();
            vodila.Transport = new TransportAdapter(horse);
            vodila.Control();
        }

        #region ClientOfTransport
        class Vodila
        {
            public ITransport Transport { get; set; }
            public void Control()
            {
                Transport.Drive();
            }
        }
        #endregion

        interface ITransport
        {
            void Drive();
        }
        class Car : ITransport
        {
            public void Drive()
            {
                Console.WriteLine("Машина едет по дорогам");
            }
        }
        interface IAnimal
        {
            void Move();
        }
        class Horse : IAnimal
        {
            public void Move()
            {
                Console.WriteLine("Лошадь скачет по полям");
            }
        }
        #region adapter
        class TransportAdapter : ITransport
        {
            private readonly IAnimal _animal;
            public TransportAdapter(IAnimal animal) => _animal = animal;
            public void Drive()
            {
                _animal.Move();
            }
        }
        #endregion

    }
}
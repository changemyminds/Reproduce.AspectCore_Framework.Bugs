namespace AspectCore_Framework.Bugs
{
    public class Sample
    {
    }

    public interface IGenericService<T>
    {
        T TestGeneric1();
        
        void TestGeneric2();
    }

    public interface IAService
    {
        void TestA();
    }

    public interface IBService : IAService, IGenericService<Sample>
    {
        void TestB();
    }

    public class TestService : IBService
    {
        public void TestA()
        {
            System.Console.WriteLine("Call TestA");
        }

        public void TestB()
        {
            System.Console.WriteLine("Call TestB");
        }

        public Sample TestGeneric1()
        {
            System.Console.WriteLine("Call TestGeneric1");
            return new Sample();
        }

        public void TestGeneric2()
        {
            System.Console.WriteLine("Call TestGeneric2");
        }
    }
}

using Castle.DynamicProxy;

namespace AspectCore_Framework.Bugs
{
    public class TestAopInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var className = invocation.TargetType;
            var methodName1 = invocation.Method.Name;
            System.Console.WriteLine($"{className}, {methodName1}");
            invocation.Proceed(); // continue
        }
    }
}
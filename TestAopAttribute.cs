using AspectCore.DynamicProxy;

namespace AspectCore_Framework.Bugs
{
    public class TestAopAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var className = context.Implementation.GetType().FullName;
            var methodName1 = context.ServiceMethod.Name;
            var methodName2 = context.ImplementationMethod.Name;
            System.Console.WriteLine($"{className}, {methodName1}, {methodName2}");
            await next(context);
        }
    }
}
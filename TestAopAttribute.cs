using AspectCore.DynamicProxy;

namespace AspectCore_Framework.Bugs
{
    public class TestAopAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var className = context.Implementation.GetType().FullName;
            var methodName = context.ServiceMethod.Name;
            System.Console.WriteLine($"{className}, {methodName}");
            await next(context);
        }
    }
}
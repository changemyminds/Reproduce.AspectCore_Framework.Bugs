using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using AspectCore_Framework.Bugs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBService,TestService>();
builder.Services.AddSingleton<TestAopAttribute>();
builder.Services.ConfigureDynamicProxy(config =>
{
    config.Interceptors.AddServiced<TestAopAttribute>(
        Predicates.ForService("*Service")
    );
});
builder.Host.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());

var app = builder.Build();

using var scop = app.Services.CreateScope();
var bService = scop.ServiceProvider.GetRequiredService<IBService>();
bService.TestA();
bService.TestB();
bService.TestGeneric1();
bService.TestGeneric2();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

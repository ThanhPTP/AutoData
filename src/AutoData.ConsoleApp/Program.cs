using Microsoft.Extensions.DependencyInjection;

namespace AutoData.ConsoleApp
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDependencies()
                .BuildServiceProvider();

            serviceProvider.GetService<StartUp>()
                .Run();
        }

        private static ServiceCollection AddDependencies(this ServiceCollection services)
        {
            services.AddSingleton<StartUp>();

            services.AddScoped<IAutoData, AutoData>();
            services.AddScoped<IFillable, Fillable>();
            services.AddScoped<ISeparatable, Separatable>();
            services.AddSingleton<IRandomize, Randomize>();

            return services;
        }
    }
}

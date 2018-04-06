using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFx.Data
{
    public static class ContextOptionsServiceCollectionExtensions
    {
        public static IServiceCollection AddMicroFxDBContext<TDbContext>(this IServiceCollection services,Action<ContextOptions> optionsAction) where TDbContext: class,IDBContext
        {
            var options = new ContextOptions();
            optionsAction(options);
            return services.AddSingleton(options)
                        .AddScoped<IDBContext, TDbContext>();
                        
        }
    }
}

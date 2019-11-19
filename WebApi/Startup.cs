using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Data;
using WebApi.Repositories;
using WebApi.Repositories.Interfaces;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureTransientServices(services);
            ConfigureRepositories(services);
            //ConfigureEntityFramework(services);

            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("ApiContext"));
            services.AddScoped<ApiContext>();

            services.AddMemoryCache();
            services.AddControllers();            
        }

        private static void ConfigureTransientServices(IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IProdutoRepository, ProdutoRepository>();
        }

        private static void ConfigureEntityFramework(IServiceCollection services)
        {
            var databaseName = Configuration["ApiContext"];

            services.AddDbContext<ApiContext>(options =>
                options.UseInMemoryDatabase(databaseName));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }        
    }
}

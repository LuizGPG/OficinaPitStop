using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OficinaPitStop.Api.GraphQL.Produtos.Marcas.Schemas;
using OficinaPitStop.Api.GraphQL.Produtos.Schemas;
using OficinaPitStop.Repositories;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Repositories.Repository;
using OficinaPitStop.Repositories.Repository.Produtos;
using OficinaPitStop.Repositories.Repository.Produtos.Marcas;

namespace OficinaPitStop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            services.AddDbContext<OficinaPitStopContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            
            DependencyInjectorRepository(services);
            AddSchemaToScope(services);

            services.AddGraphQL(options =>
                {
                    options.ExposeExceptions = true;
                }).
                AddGraphTypes(ServiceLifetime.Scoped).
                AddDataLoader();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            app.UseGraphQL<ProdutoSchema>();
            app.UseGraphQL<MarcaSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            /*app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            */
            /*app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });*/
        }
        
        
        private static void AddSchemaToScope(IServiceCollection services)
        {
            services.AddScoped<ProdutoSchema>();
            services.AddScoped<MarcaSchema>();
        }

        private static void DependencyInjectorRepository(IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
        }
    }
}

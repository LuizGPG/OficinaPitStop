using System.Diagnostics.CodeAnalysis;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OficinaPitStop.Api.GraphQL;
using OficinaPitStop.Repositories;
using OficinaPitStop.Repositories.Abstractions.Repository;
using OficinaPitStop.Repositories.Abstractions.Repository.Produtos.Marcas;
using OficinaPitStop.Repositories.Repository.Produtos;
using OficinaPitStop.Repositories.Repository.Produtos.Marcas;
using OficinaPitStop.Services.Abstractions.Produtos;
using OficinaPitStop.Services.Abstractions.Produtos.Marcas;
using OficinaPitStop.Services.Produtos;
using OficinaPitStop.Services.Produtos.Marcas;

namespace OficinaPitStop.Api
{
    [ExcludeFromCodeCoverage]
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

            DependencyInjectorService(services);
            DependencyInjectorRepository(services);
            AddSchemaToScope(services);

            services.AddGraphQL(options =>
                {
                    options.ExposeExceptions = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
            
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddCors();
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

            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


            app.UseGraphQL<OficinaPitStopSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }

        private static void AddSchemaToScope(IServiceCollection services)
        {
            services.AddScoped<OficinaPitStopSchema>();
        }

        private static void DependencyInjectorService(IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IMarcaService, MarcaService>();
        }
        private static void DependencyInjectorRepository(IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
        }
    }
}
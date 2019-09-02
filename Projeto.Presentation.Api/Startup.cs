using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Application.Adapters;
using Projeto.Application.Contracts;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Configuração para o EntityFramework

            //mapeando injeção de dependência para a classe DataContext
            services.AddTransient<DataContext>();

            //mapeando a string de conexão que será enviada para a classe DataContext
            services.AddDbContext<DataContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("Aula"))
                );

            #endregion

            #region Configuração para Injeção de Dependência

            //camada de aplicação
            services.AddTransient<IDependenteApplicationService, DependenteApplicationService>();
            services.AddTransient<IFuncionarioApplicationService, FuncionarioApplicationService>();

            //camada de dominio
            services.AddTransient<IDependenteDomainService, DependenteDomainService>();
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();

            //camada de infra estrutura do repositorio
            services.AddTransient<IDependenteRepository, DependenteRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();

            #endregion

            #region Configuração para o AutoMapper

            AutoMapperConfig.Register();

            #endregion

            #region Configuração para o SWAGGER

            services.AddSwaggerGen(
                    swagger =>
                    {
                        swagger.SwaggerDoc("v1",
                            new Info
                            {
                                Title = "Sistema de Controle de Funcionários",
                                Version = "v1",
                                Description = "Projeto desenvolvido em aula - C# WebDeveloper",
                                Contact = new Contact
                                {
                                    Name = "COTI Informática",
                                    Url = "http://www.cotiinformatica.com.br",
                                    Email = "contato@cotiinformatica.com.br"
                                }
                            });
                    }
                );

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            #region Configuração para o SWAGGER

            app.UseSwagger(); //definindo o uso do Swagger para o projeto
            app.UseSwaggerUI(
                    swagger =>
                    {
                        swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                    }
                );

            #endregion
        }
    }
}

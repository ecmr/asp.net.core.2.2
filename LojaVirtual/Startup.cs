using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.DataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.Contracts;
using LojaVirtual.Libraries.Sessao;
using LojaVirtual.Libraries.Login;
using System.Net.Mail;
using System.Net;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Middleware;
using LojaVirtual.Libraries.CarrinhoCompra;
using AutoMapper;
using LojaVirtual.Libraries.AutoMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper.Internal;
using Microsoft.Extensions.Hosting;

namespace LojaVirtual
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
            /*
             * AutoMapper
             */

            //services.AddAutoMapper(typeof(Startup));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                //Needed for https://github.com/AutoMapper/AutoMapper/issues/3988
                mc.Internal().MethodMappingEnabled = false;
                mc.AddProfile(new MappingProfile());
            });
            //mapperConfig.AssertConfigurationIsValid();

            IMapper mapper = mapperConfig.CreateMapper();
            //builder.Services.AddSingleton(mapper);
            services.AddSingleton(mapper);

            /*
             * Padrão Repository
             */
            services.AddHttpContextAccessor();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();

            /*
             * SMTP
             */
            services.AddScoped<SmtpClient>(options =>
            {
                SmtpClient smtp = new SmtpClient()
                {
                    Host = Configuration.GetValue<string>("Email:ServerSMTP"),
                    Port = Configuration.GetValue<int>("Email:ServerPort"),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Configuration.GetValue<string>("Email:Username"), Configuration.GetValue<string>("Email:Password")),
                    EnableSsl = true
                };

                return smtp;
            });
            services.AddScoped<GerenciarEmail>();
            services.AddScoped<LojaVirtual.Libraries.Cookie.Cookie>();
            services.AddScoped<CarrinhoCompra>();

            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*
             * Session - Configuração
             */
            services.AddMemoryCache(); //Guardar os dados na memória
            services.AddSession(options =>
            {

            });

            services.AddScoped<Sessao>();
            services.AddScoped<LojaVirtual.Libraries.Cookie.Cookie>();
            services.AddScoped<LoginCliente>();
            services.AddScoped<LoginColaborador>();

            services.AddMvc(options =>
            {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "O campo deve ser preenchido!");
                options.EnableEndpointRouting = true;

            });




            //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtual;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string connection = "Server=EDINEI-LAPTOP;Database=CommerceLoja;User Id=edine;Password=P@ssW0rd#2023!;";
            //services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<CommerceLojaContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.UseMvc();
        }
    }
}
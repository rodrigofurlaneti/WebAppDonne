namespace WebApi.Donne
{
    public class Startup : IStartup
    {
        private readonly string _allowPolicy = "_AllowPolicy";
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: _allowPolicy, builder => builder.WithOrigins("*")
                                                                    .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddScoped<WebApi.Donne.Infrastructure.SeedWork.ILogger, WebApi.Donne.Infrastructure.SeedWork.Logger>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
        }

        public void Configure(WebApplication webApplication, IWebHostEnvironment webHostEnvironment)
        {
            if (webApplication.Environment.IsDevelopment() || webApplication.Environment.IsProduction())
            {
                webApplication.UseDeveloperExceptionPage();

                webApplication.UseSwagger();

                webApplication.UseSwaggerUI();

                webApplication.MapSwagger();
            }

            webApplication.UseHttpsRedirection();

            webApplication.UseCors(_allowPolicy);

            webApplication.UseAuthorization();

            webApplication.MapControllers();

            webApplication.Run();
        }

    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }

        void Configure(WebApplication webApplication, IWebHostEnvironment webHostEnvironment);

        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webApplicationBuilder.Configuration) as IStartup;

            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(webApplicationBuilder.Services);

            var app = webApplicationBuilder.Build();

            startup.Configure(app, app.Environment);

            app.Run();

            return webApplicationBuilder;
        }
    }


}

var AllowPolicy = "_AllowPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowPolicy, builder => builder.WithOrigins("https://orange-ocean-0e4330d10.4.azurestaticapps.net")
                                                        .AllowAnyMethod()
    .AllowAnyHeader());
});

builder.Services.AddScoped<WebApi.Donne.Infrastructure.SeedWork.ILogger, WebApi.Donne.Infrastructure.SeedWork.Logger>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapSwagger();
}

app.UseHttpsRedirection();

app.UseCors(AllowPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();

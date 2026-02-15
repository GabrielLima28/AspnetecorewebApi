using AspnetecorewebApi.Cotexto;
using AspnetecorewebApi.Extensions;
using AspnetecorewebApi.filter;
using AspnetecorewebApi.Logging;
using AspnetecorewebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//configuração para evitar loopings na serialização JSON 
builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);

 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// o AddScoped é um método que determina o ciclo de vida da minha aplicação 

builder.Services.AddScoped<ApiLoggingFilter>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<IMeuServico, MeuServiço>();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguratiom
    {

    LogLevel = LogLevel.Information
}

    ));

///<summary>
/// função que vai adicionar o filtro e 
/// todos os controladores 
/// vão poder utilizá-lo 
/// 
/// 
/// </summary>
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
    ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
   // Então eu estou definindo um fluxo de 
   // execução e definindo aqui 
   // os métodos de extenção 
   /**/
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
//Api Use Suthorization Define o método de 
//autorização para verificar as permissões 
// de acesso
app.UseAuthorization();
app.Use(async (context, next) =>
{
    //adicionar o codigo antes do request 
    await next(context);
    // adicionar o código depois do request 
});
//Mapeamento dos controllers da aplicação 

app.MapControllers();


app.Run(async (context) =>
{
    await context.Response.WriteAsync("Middleware final");
});


app.Run();

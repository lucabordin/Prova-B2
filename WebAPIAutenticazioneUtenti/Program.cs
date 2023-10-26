using Microsoft.EntityFrameworkCore;
using WebAPIAutenticazioneUtenti.Helpers;
using WebAPIAutenticazioneUtenti.Services;
using WebAPIFaseA.DataSource;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UtenteContext>(options =>
{
    string? cnUtente = builder.Configuration.GetConnectionString("cnUtente");
    options.UseSqlServer(cnUtente);
});
builder.Services.AddScoped<UtenteContext, UtenteContext>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<IHelper, Helper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

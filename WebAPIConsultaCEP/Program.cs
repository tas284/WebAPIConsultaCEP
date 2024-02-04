using WebAPIConsultaCEP.Interfaces;
using WebAPIConsultaCEP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICepService, ViaCEPService>();
builder.Services.AddScoped<HttpClient>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

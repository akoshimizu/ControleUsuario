using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using ProjetoUsuario.Application.Interfaces;
using ProjetoUsuario.Application.Services;
using ProjetoUsuario.Domain.Mapper;
using ProjetoUsuario.Persistence.Context;
using ProjetoUsuario.Persistence.Repository;
using ProjetoUsuario.Persistence.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
{ 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version())));
//builder.Services.AddDbContext<MySQLContext>(o => o.UseInMemoryDatabase("teste_usuario"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MesaProfile));

// Dependency Injection
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Controle de Usuarios - v1");
            });
    
    var options = new RewriteOptions();
    options.AddRedirect("^$", "swagger");
    app.UseRewriter(options);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

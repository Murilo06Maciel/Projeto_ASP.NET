
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Gerenciador_De_Tarefas.Data;
using Gerenciador_De_Tarefas.Models;


var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext para MySQL
builder.Services.AddDbContext<TarefasContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddControllers();

var app = builder.Build();

// Aplica migrations automaticamente (cria o banco/tabelas se não existirem)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TarefasContext>();
    db.Database.Migrate();
}

app.UseDefaultFiles(); // Serve index.html por padrão
app.UseStaticFiles(); // Permite servir arquivos da pasta wwwroot

app.MapControllers();

app.MapGet("/sobre", async context =>
{
    await context.Response.SendFileAsync("wwwroot/sobre.html");
});

app.Run();

// (nenhuma alteração necessária aqui, apenas garanta que o nome do banco está igual ao da connection string e do script SQL)

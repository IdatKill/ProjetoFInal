using back_app.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Cadastrar o Livro
app.MapPost("/api/livros/cadastrar", ([FromBody] Livro livro, [FromServices] AppDataContext ctx) => {
    ctx.Livros.Add(livro);
    ctx.SaveChanges();
    return Results.Created($"/livros/{livro.Id}", livro);
});

// Listar os livros cadastrados
app.MapGet("/api/livros/listar", ([FromServices] AppDataContext ctx) =>
{
    return Results.Ok(ctx.Livros.ToList());
});

// Cadastrar Usuário
app.MapPost("/api/usuarios/cadastrar", ([FromBody] Usuario usuario, [FromServices] AppDataContext ctx) => {
    ctx.Usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created($"/usuarios/{usuario.Id}", usuario);
});

// Listar todos os usuários
app.MapGet("/api/usuarios/listar", ([FromServices] AppDataContext ctx) => {
    return Results.Ok(ctx.Usuarios.ToList());
});

// Listar os usuários ativos
app.MapGet("/api/usuariosAtivos/listar", ([FromServices] AppDataContext ctx) => {
    var usuariosAtivos = ctx.Usuarios.Where(u => u.Ativo).ToList();
    return Results.Ok(usuariosAtivos);
});

// Desativar o usuário baseado no ID
app.MapPost("/api/usuarios/desativar/{id}", (int id, [FromServices] AppDataContext ctx) =>
{
    var usuario = ctx.Usuarios.Find(id);

    if (usuario == null)
        return Results.NotFound($"Usuário com ID {id} não encontrado.");

    usuario.Ativo = false;
    ctx.SaveChanges();
    return Results.Ok(usuario);
});

// Ativar o usuário baseado no ID
app.MapPost("/api/usuarios/ativar/{id}", (int id, [FromServices] AppDataContext ctx) =>
{
    var usuario = ctx.Usuarios.Find(id);

    if (usuario == null)
        return Results.NotFound($"Usuário com ID {id} não encontrado.");

    usuario.Ativo = true;
    ctx.SaveChanges();
    return Results.Ok(usuario);
});




app.Run();

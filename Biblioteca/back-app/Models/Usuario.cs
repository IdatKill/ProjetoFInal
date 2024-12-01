using System;

namespace back_app.Models;

public class Usuario
{
    public int Id {get; set;}
    public string? Nome {get; set;}
    public string? Email {get; set;}
    public string? Celular {get; set;}
    public DateTime CadastradoEm {get; set;} = DateTime.Now;
    public bool Ativo {get; set;} = true;
}

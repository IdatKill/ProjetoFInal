import axios from "axios";
import React, { useEffect, useState } from "react";
import { Livro } from "../../src/Models/Livro";
import "./cadastrarLivro.css";

function CadastrarLivro() {
    const [livros, setLivros] = useState<any[]>([]);
    const [titulo, setTitulo] = useState("");
    const [autor, setAutor] = useState("");
    const [editora, setEditora] = useState("");
    const [genero, setGenero] = useState("");

    useEffect(() => {
        axios
          .get<any[]>("http://localhost:5173/api/livros/listar")
          .then((resposta) => {
            setLivros(resposta.data);
          });
      }, []);

      function enviarLivro(event: any) {
        event.preventDefault();
        const livros: Livro = {
          titulo: titulo,
          autor: autor,
          editora: editora,
          genero: genero,
        };

        fetch("http://localhost:5173/api/livros/cadastrar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(livros),
        })
        .then((resposta) => resposta.json())
        .then((livros) => {
            console.log(livros);
        })
    }
    return (
        <div>
            <h1>Cadastrar Produto</h1>
            <form onSubmit={enviarLivro}>
                <div className="form-group">
                    <label htmlFor="titulo">Título</label>
                    <input
                     type="text"
                     id="titulo"
                     name="titulo"
                     required
                     onChange={(event:any) => setTitulo(event.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="autor">Autor</label>
                    <input
                     type="text"
                     id="autor"
                     name="autor"
                     required
                     onChange={(event:any) => setAutor(event.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="editora">Editora</label>
                    <input
                     type="text"
                     id="editora"
                     name="editora"
                     required
                     onChange={(event:any) => setEditora(event.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="genero">Gênero</label>
                    <input
                     type="text"
                     id="genero"
                     name="genero"
                     required
                     onChange={(event:any) => setGenero(event.target.value)}
                    />
                </div>
            </form>
        </div>
       
        
    );
}

export default CadastrarLivro;

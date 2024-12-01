import { Link } from "react-router-dom";

function App() {
  return (
    <div>
      <Link to="/">Home</Link>
      <Link to="../public/paginas/cadastrarLivro.tsx">Cadastrar</Link>
    </div>
);
}

export default App;

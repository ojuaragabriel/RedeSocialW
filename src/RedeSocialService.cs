using System;
using System.Collections.Generic;
using System.Linq;

namespace RedeSocialW
{
    public class RedeSocialService
    {
        private readonly List<Usuario> usuarios = new();
        private readonly List<Mensagem> mensagens = new();

        public Usuario Registrar(string nome, string email, string senhaHash)
        {
            var u = new Usuario(IdGenerator.Next(), nome, email, senhaHash);
            usuarios.Add(u);
            return u;
        }

        public Usuario Login(string email, string senhaHash)
        {
            var u = usuarios.FirstOrDefault(x => x.Email == email);
            if (u != null && u.Autenticar(senhaHash)) return u;
            throw new InvalidOperationException("Credenciais inválidas");
        }

        public Mensagem Postar(Usuario autor, string conteudo)
        {
            var m = new Mensagem(IdGenerator.Next(), autor, conteudo);
            mensagens.Add(m);
            return m;
        }

        public bool Curtir(Usuario u, Mensagem m) => m.AdicionarCurtida(u);
        public bool Descurtir(Usuario u, Mensagem m) => m.RemoverCurtida(u);
        public Comentario Comentar(Usuario u, Mensagem m, string texto) => m.AdicionarComentario(u, texto);

        public IEnumerable<Mensagem> Timeline() => mensagens.OrderByDescending(m => m.CriadoEm);

        public void ExcluirMensagem(Usuario autor, Mensagem m)
        {
            if (m.Autor.Id != autor.Id) throw new InvalidOperationException("Somente o autor pode excluir");
            mensagens.Remove(m);
        }
    }
}

using System;
using System.Collections.Generic;

namespace RedeSocialW
{
    public class Mensagem
    {
        public int Id { get; }
        public Usuario Autor { get; }
        public string Conteudo { get; private set; }
        public DateTime CriadoEm { get; }
        private readonly HashSet<int> curtidores = new();
        private readonly List<Comentario> comentarios = new();

        public Mensagem(int id, Usuario autor, string conteudo)
        {
            Id = id;
            Autor = autor;
            Conteudo = conteudo;
            CriadoEm = DateTime.Now;
        }

        public bool AdicionarCurtida(Usuario u) => curtidores.Add(u.Id);
        public bool RemoverCurtida(Usuario u) => curtidores.Remove(u.Id);
        public int ContarCurtidas() => curtidores.Count;

        public Comentario AdicionarComentario(Usuario u, string texto)
        {
            var c = new Comentario(IdGenerator.Next(), this, u, texto);
            comentarios.Add(c);
            return c;
        }

        public IEnumerable<Comentario> ListarComentarios() => comentarios;
    }
}

using System;

namespace RedeSocialW
{
    public class Comentario
    {
        public int Id { get; }
        public Mensagem Mensagem { get; }
        public Usuario Autor { get; }
        public string Texto { get; }
        public DateTime CriadoEm { get; }

        public Comentario(int id, Mensagem mensagem, Usuario autor, string texto)
        {
            Id = id;
            Mensagem = mensagem;
            Autor = autor;
            Texto = texto;
            CriadoEm = DateTime.Now;
        }
    }
}

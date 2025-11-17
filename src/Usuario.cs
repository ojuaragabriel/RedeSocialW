using System;

namespace RedeSocialW
{
    public class Usuario
    {
        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        private string SenhaHash { get; }

        public Usuario(int id, string nome, string email, string senhaHash)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
        }

        public bool Autenticar(string senhaHash) => SenhaHash == senhaHash;
    }
}

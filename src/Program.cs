using System;
using System.Linq;

namespace RedeSocialW
{
    class Program
    {
        static void Main()
        {
            var app = new RedeSocialService();

            var ana = app.Registrar("Ana", "ana@w.com", "h_ana");
            var bob = app.Registrar("Bob", "bob@w.com", "h_bob");

            var anaLogada = app.Login("ana@w.com", "h_ana");
            var post = app.Postar(anaLogada, "Olá, mundo W!");

            var bobLogado = app.Login("bob@w.com", "h_bob");
            Console.WriteLine($"Curtida Bob 1: {app.Curtir(bobLogado, post)}");
            Console.WriteLine($"Curtida Bob 2: {app.Curtir(bobLogado, post)}");
            Console.WriteLine($"Curtidas atuais: {post.ContarCurtidas()}");

            app.Comentar(bobLogado, post, "Bem vinda!");
            app.Comentar(anaLogada, post, "Obrigada!");

            foreach (var c in post.ListarComentarios())
                Console.WriteLine($"Comentário de {c.Autor.Nome}: {c.Texto}");

            foreach (var m in app.Timeline())
                Console.WriteLine($"Post {m.Id} de {m.Autor.Nome}: {m.Conteudo} [{m.ContarCurtidas()} curtidas]");

            Console.WriteLine("Demonstração concluída.");
        }
    }
}

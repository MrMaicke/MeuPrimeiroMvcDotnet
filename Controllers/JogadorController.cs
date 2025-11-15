
using MeuPrimeiroMvc.Contexts;
using MeuPrimeiroMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuPrimeiroMvc.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        // Criar uma referência (instância) sobre a comunicação do meu banco de dados
        ProjetoTesteContext _context = new ProjetoTesteContext();

        public IActionResult Index()
        {
            // .include() - trago os dados das tabelas relacionadas
            var listaJogadores = _context.Jogadors.ToList();

            ViewBag.ListaJogadores = listaJogadores;

            // Passando também a lista de equipes para montar o meu select
            var listaEquipes = _context.Equipes.ToList();

            ViewBag.ListaEquipes = listaEquipes;

            return View();
        }

        [Route("cadastrar")]
        public IActionResult CadastrarJogador(Jogador jogador)
        {
            // Armazenar a equipe no banco de dados
            _context.Add(jogador);

            // Registrar as alterações no banco de dados
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Na rota de excluir, vamos capturar o id que vem na url
        [Route("ExcluirJogador/{idJogador}")]
        public IActionResult ExcluirEquipe(int idJogador)
        {
            //Pegar o id de referência, e vou procurar a equipe no banco de dados
            Jogador jogador = _context.Jogadors.FirstOrDefault(x => x.Id == idJogador); // select * from EQUIPE where id == (valor da equipe da tabela)


            _context.Remove(jogador);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
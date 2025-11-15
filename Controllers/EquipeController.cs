
using MeuPrimeiroMvc.Contexts;
using MeuPrimeiroMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuPrimeiroMvc.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        // Criar uma referência (instância) sobre a comunicação do meu banco de dados
        ProjetoTesteContext _context = new ProjetoTesteContext();

        public IActionResult Index()
        {
            // Forma de listar todos os itens da tabela de (Equipe)
            var listaEquipes = _context.Equipes.ToList();

            // Passar a tela (em forma de memoria) os dados das equipes cadastras
            ViewBag.ListaEquipes = listaEquipes;

            return View();
        }

        [Route("cadastrar")]
        public IActionResult CadastrarEquipe(Equipe equipe)
        {
            // Armazenar a equipe no banco de dados
            _context.Add(equipe);

            // Registrar as alterações no banco de dados
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Na rota de excluir, vamos capturar o id que vem na url
        [Route("ExcluirEquipe/{idEquipe}")]
        public IActionResult ExcluirEquipe(int idEquipe)
        {
            //Pegar o id de referência, e vou procurar a equipe no banco de dados
            Equipe equipe = _context.Equipes.FirstOrDefault(x => x.Id == idEquipe); // select * from EQUIPE where id == (valor da equipe da tabela)


            _context.Remove(equipe);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Route("Atualizar/{idEquipe}")]
        public IActionResult Atualizar(int idEquipe)
        {
            Equipe equipe = _context.Equipes.FirstOrDefault(x => x.Id == idEquipe);

            ViewBag.Equipe = equipe;

            return View();
        }

        [Route("AtualizarEquipe")]
        public IActionResult AtualizarEquipe(Equipe equipe)
        {
            _context.Equipes.Update(equipe);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

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
    }
}
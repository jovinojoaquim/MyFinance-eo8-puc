using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers
{

    [Route("PlanoConta")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IRepositoryService<PlanoConta> _planoContaRepository;

        public PlanoContaController(ILogger<PlanoContaController> logger, IRepositoryService<PlanoConta> planoContaService)
        {
            _logger = logger;
            _planoContaRepository = planoContaService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Lista = _planoContaRepository.ListarRegistros();
            return View();
        }

        [HttpPost]
        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel? model, int? id)
        {
            if (id != null && !ModelState.IsValid)
            {
                var registro = _planoContaRepository.RetornarRegistro((int)id);
                var planoContaModel = new PlanoContaModel()
                {
                    Id = registro.Id,
                    Nome = registro.Nome,
                    Tipo = registro.Tipo
                };

                return View(planoContaModel);
            }
            else if (model != null && ModelState.IsValid)
            {
                var planoConta = new PlanoConta()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Tipo = model.Tipo
                };

                _planoContaRepository.Salvar(planoConta);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _planoContaRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
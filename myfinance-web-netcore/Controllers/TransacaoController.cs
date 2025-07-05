using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers
{

    [Route("Transacao")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly IRepositoryService<Transacao> _transacaoService;
        private readonly IRepositoryService<PlanoConta> _planoContaRepository;

        public TransacaoController(ILogger<TransacaoController> logger, IRepositoryService<Transacao> transacaoService, IRepositoryService<PlanoConta> planoContaService)
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaRepository = planoContaService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Lista = _transacaoService.ListarRegistros(source => source.Include(p => p.PlanoConta));
            return View();
        }

        [HttpGet("Cadastro")]
        public IActionResult Cadastro()
        {
            var transacaoModel = new TransacaoModel(_planoContaRepository);            
            return View(transacaoModel);
        }

        [HttpGet("Cadastro/{id}")]
        public IActionResult Cadastro(int id)
        {
            var registro = _transacaoService.RetornarRegistro((int)id);            
            var planoContaModel = new TransacaoModel(_planoContaRepository)
            {
                Id = registro.Id,
                Historico = registro.Historico,
                Data = registro.Data,
                Valor = registro.Valor,
                Tipo = registro.PlanoConta.Tipo,
                PlanoContaId = registro.PlanoContaId                
            };

            return View(planoContaModel);
        }

        [HttpPost("Cadastro")]
        [HttpPost("Cadastro/{id}")]
        public IActionResult Cadastro(TransacaoModel model, int? id)
        {
            if (ModelState.IsValid)
            {
                var planoConta = new Transacao()
                {
                    Id = model.Id,
                    Historico = model.Historico,
                    Data = model.Data,
                    Valor = model.Valor,
                    PlanoContaId = model.PlanoContaId

                };
                _transacaoService.Salvar(planoConta);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _transacaoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
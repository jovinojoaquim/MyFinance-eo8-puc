using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public string? Historico { get; set; }
        public string? Tipo { get; set; }
        public DateTime Data { get; set; }
        public int PlanoContaId { get; set; }
        public IEnumerable<SelectListItem>? PlanoConta { get; set; }
        public double Valor { get; set; }

        public TransacaoModel()
        {
            
        }
        public TransacaoModel(IRepositoryService<PlanoConta> planoContaService)
        {
            var listaPlanoContas = planoContaService.ListarRegistros();

            var planoContaSelectItems = new SelectList(listaPlanoContas, nameof(Domain.PlanoConta.Id), nameof(Domain.PlanoConta.Nome));
            PlanoConta = planoContaSelectItems;
            Data = DateTime.Now;
        }
    }
}
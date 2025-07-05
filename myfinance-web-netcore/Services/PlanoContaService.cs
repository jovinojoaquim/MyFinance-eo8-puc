using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDBContext _banco;
        public PlanoContaService(MyFinanceDBContext banco)
        {
            _banco = banco;
        }

        public List<PlanoConta> RetornarTotalValoresDePlanosContaMaisUtilizados()
        {
            throw new NotImplementedException();
        }
    }
}
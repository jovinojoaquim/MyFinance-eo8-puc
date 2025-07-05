using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;

namespace myfinance_web_netcore.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDBContext _banco;
        public TransacaoService(MyFinanceDBContext banco)
        {
            _banco = banco;
        }

        public List<Transacao> RetornarTransacaoMaisCaraDoAno(int Ano)
        {
            throw new NotImplementedException();
        }
    }
}
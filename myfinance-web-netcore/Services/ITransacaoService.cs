using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Services
{

    public interface ITransacaoService
    {
        List<Transacao> RetornarTransacaoMaisCaraDoAno(int Ano);        
    }

}
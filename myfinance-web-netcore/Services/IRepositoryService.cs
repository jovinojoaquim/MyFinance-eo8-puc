using Microsoft.EntityFrameworkCore.Query;

namespace myfinance_web_netcore.Services
{
    public interface IRepositoryService<T> where T : class
    {
        List<T> ListarRegistros(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        void Salvar(T registro);
        void Excluir(int id);
        T RetornarRegistro(int id);
    }
}
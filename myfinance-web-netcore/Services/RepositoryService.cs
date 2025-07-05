
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using myfinance_web_netcore.Infrastructure;

namespace myfinance_web_netcore.Services
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        private readonly MyFinanceDBContext _banco;
        private readonly DbSet<T> _dbSet;

        public RepositoryService(MyFinanceDBContext banco)
        {
            _banco = banco;
            _dbSet = banco.Set<T>();
        }
        public void Excluir(int id)
        {
            var item = RetornarRegistro(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                _banco.SaveChanges();
            }            
        }

        public List<T> ListarRegistros(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include is null)
                return _dbSet.ToList();

            return include(_dbSet).ToList();
        }

        public T RetornarRegistro(int id)
        {
            return _dbSet.Find(id);
        }

        public void Salvar(T registro)
        {
            var entry = _banco.Entry(registro);
            var key = _banco.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.First();
            var id = entry.Property(key.Name).CurrentValue;

            if (id == null)
            {
                _dbSet.Add(registro);
            }
            else
            {
                _dbSet.Attach(registro);
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _banco.SaveChanges();
        }
    }
}
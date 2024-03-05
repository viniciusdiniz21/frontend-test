using CompanyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Data.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(int id);
        List<TEntity> ObterTodos();
        bool Adicionar(TEntity entity);
        bool Atualizar(TEntity entity);
        bool ExclusaoLogica(TEntity entity);
        bool Remover(int id);

    }
}

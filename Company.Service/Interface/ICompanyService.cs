using CompanyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Service.Interface
{
    public interface ICompanyService : IDisposable
    {
        Task<List<Company>> Buscar();
        Task<Company> ObterPorId(int id);
        Task<bool> Adicionar(Company company);
        Task<bool> Atualizar(Company company);
        Task<bool> ExclusaoLogica(Company company);
        Task<bool> Remover(int id);
    }
}

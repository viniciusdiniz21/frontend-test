using CompanyApi.Data.Interface;
using CompanyApi.Domain.Entities;
using CompanyApi.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Service.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public bool Adicionar(Company company)
        {
            return _companyRepository.Adicionar(company);
        }

        public bool Atualizar(Company company)
        {
            var oldCompany = _companyRepository.ObterPorId(company.Id);

            if( oldCompany.Active != company.Active)
            {
                return false;
            }


            return _companyRepository.Atualizar(company);
        }

        public List<Company> Buscar()
        {
            return _companyRepository.ObterTodos();
        }

        public void Dispose()
        {
            _companyRepository.Dispose();
        }

        public bool ExclusaoLogica(Company company)
        {
            return _companyRepository.ExclusaoLogica(company);
        }

        public Company ObterPorId(int id)
        {
            return _companyRepository.ObterPorId(id);
        }

        public bool Remover(int id)
        {
            return _companyRepository.Remover(id);
        }
    }
}

using CompanyApi.Data.Interface;
using CompanyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Data.Interface
{
    public interface ICompanyRepository : IRepository<Company>
    {
    }
}

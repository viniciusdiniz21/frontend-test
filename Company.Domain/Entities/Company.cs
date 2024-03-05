using Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Entities
{
    public class Company : Entity
    {
        public string AvatarUrl { get; set; }
        public string NomeFantasia { get; set; }
        public int QtdeFuncionarios { get; set; }
    }
}

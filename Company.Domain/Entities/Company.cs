﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        public string NomeFantasia { get; set; }
        public int QtdeFuncionarios { get; set; }
        public bool Active { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.DTO.Bond;
using CompanyAPI.Models;

namespace CompanyAPI.DTO.Company
{
    public class EditCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public EntrepreneurBondDTO Entrepreneur { get; set; }
    }
}
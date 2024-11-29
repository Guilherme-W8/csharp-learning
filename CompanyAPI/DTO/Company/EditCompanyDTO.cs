using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.DTO.Company
{
    public class EditCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public EntrepreneurModel Entrepreneur { get; set; }
    }
}
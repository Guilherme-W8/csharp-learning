using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Data;
using CompanyAPI.DTO.Company;
using CompanyAPI.Models;

namespace CompanyAPI.Services.Company
{
    public class CompanyService : ICompanyInterface
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext context)
        {
            _context = context;

        }
        public Task<ResponseModel<List<CompanyModel>>> CreateCompany(CreateCompanyDTO companyDTODTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> EditCompany(EditCompanyDTO editCompanyDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CompanyModel>> FindCompanyByEntrepreneurId(int entrepreneurID)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CompanyModel>> FindCompanyById(int companyID)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> ListCompanies()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> RemoveCompany(int companyID)
        {
            throw new NotImplementedException();
        }
    }
}
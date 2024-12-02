using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.DTO.Company;
using CompanyAPI.Models;

namespace CompanyAPI.Services.Company
{
    public interface ICompanyInterface
    {
        Task<ResponseModel<List<CompanyModel>>> ListCompanies();
        Task<ResponseModel<CompanyModel>> FindCompanyById(int companyID);
        Task<ResponseModel<List<CompanyModel>>> FindCompanyByEntrepreneurId(int entrepreneurID);
        Task<ResponseModel<List<CompanyModel>>> CreateCompany(CreateCompanyDTO companyDTO);
        Task<ResponseModel<List<CompanyModel>>> EditCompany(EditCompanyDTO editCompanyDTO);
        Task<ResponseModel<List<CompanyModel>>> RemoveCompany(int companyID);
    }
}
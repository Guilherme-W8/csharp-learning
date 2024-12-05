using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Services.Company;
using Microsoft.AspNetCore.Mvc;

using CompanyAPI.DTO.Company;
using CompanyAPI.Models;

namespace CompanyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CompanyController : ControllerBase
    {
        private readonly ICompanyInterface _companyInterface;
        public CompanyController(ICompanyInterface companyInterface)
        {
            _companyInterface = companyInterface;
        }

        [HttpGet("ListCompanies")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListCompanies()
        {
            var companies = await _companyInterface.ListCompanies();
            return Ok(companies);
        }

        [HttpGet("FindCompanyById/{companyID}")]
        public async Task<ActionResult<ResponseModel<CompanyModel>>> FindCompanyById(int companyID)
        {
            var company = await _companyInterface.FindCompanyById(companyID);
            return Ok(company);
        }

        [HttpGet("FindCompanyByEntrepreneurId/{entrepreneurID}")]
        public async Task<ActionResult<ResponseModel<CompanyModel>>> FindCompanyByEntrepreneurId(int entrepreneurID)
        {
            var company = await _companyInterface.FindCompanyByEntrepreneurId(entrepreneurID);
            return Ok(company);
        }

        [HttpPost("CreateCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> CreateCompany(CreateCompanyDTO companyDTO)
        {
            var companies = await _companyInterface.CreateCompany(companyDTO);
            return Ok(companies);
        }

        [HttpPut("EditCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> EditCompany(EditCompanyDTO editCompanyDTO)
        {
            var companies = await _companyInterface.EditCompany(editCompanyDTO);
            return Ok(companies);
        }

        [HttpDelete("RemoveCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> RemoveCompany(int companyID)
        {
            var companies = await _companyInterface.RemoveCompany(companyID);
            return Ok(companies);
        }
    }
}
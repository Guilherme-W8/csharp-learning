using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.DTO.Entrepreneur;
using CompanyAPI.Models;
using CompanyAPI.Services.Entrepreneur;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntrepreneurController : ControllerBase
    {
        private readonly IEntrepreneurInterface _entrepreneurInterface;
        public EntrepreneurController(IEntrepreneurInterface entrepreneurInterface)
        {
            _entrepreneurInterface = entrepreneurInterface;
        }

        [HttpGet("ListEntrepreneurs")]
        public async Task<ActionResult<ResponseModel<List<EntrepreneurModel>>>> ListEntrepreneurs()
        {
            var entrepreneurs = await _entrepreneurInterface.ListEntrepreneurs();
            return Ok(entrepreneurs);
        }

        [HttpGet("FindEntrepreneurById/{entrepreneurID}")]
        public async Task<ActionResult<ResponseModel<EntrepreneurModel>>> FindEntrepreneurById(int entrepreneurID)
        {
            var entrepreneur = await _entrepreneurInterface.FindEntrepreneurById(entrepreneurID);
            return Ok(entrepreneur);
        }

        [HttpGet("FindEntrepreneurByCompanyId/{companyID}")]
        public async Task<ActionResult<ResponseModel<EntrepreneurModel>>> FindEntrepreneurByCompanyId(int companyID)
        {
            var entrepreneur = await _entrepreneurInterface.FindEntrepreneurByCompanyId(companyID);
            return Ok(entrepreneur);
        }

        [HttpPost("CreateEntrepreneur")]
        public async Task<ActionResult<ResponseModel<List<EntrepreneurModel>>>> CreateEntrepreneur(CreateEntrepreneurDTO entrepreneurDTO)
        {
            var entrepreneurs = await _entrepreneurInterface.CreateEntrepreneur(entrepreneurDTO);
            return Ok(entrepreneurs);
        }

        [HttpPut("EditEntrepreneur")]
        public async Task<ActionResult<ResponseModel<List<EntrepreneurModel>>>> EditEntrepreneur(EditEntrepreneurDTO editEntrepreneurDTO)
        {
            var entrepreneurs = await _entrepreneurInterface.EditEntrepreneur(editEntrepreneurDTO);
            return Ok(entrepreneurs);
        }

        [HttpDelete("RemoveEntrepreneur")]
        public async Task<ActionResult<ResponseModel<List<EntrepreneurModel>>>> RemoveEntrepreneur(int entrepreneurID)
        {
            var entrepreneurs = await _entrepreneurInterface.RemoveEntrepreneur(entrepreneurID);
            return Ok(entrepreneurs);
        }
    }
}
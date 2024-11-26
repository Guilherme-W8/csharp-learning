using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
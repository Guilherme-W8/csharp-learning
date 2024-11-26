using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Data;
using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services.Entrepreneur
{
    public class EntrepreneurService : IEntrepreneurInterface
    {
        private readonly AppDbContext _context;
        public EntrepreneurService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<EntrepreneurModel>> FindEntrepreneurByCompanyId(int companyID)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<EntrepreneurModel>> FindEntrepreneurById(int entrepreneurID)
        {
            ResponseModel<EntrepreneurModel> response = new ResponseModel<EntrepreneurModel>();

            try
            {
                var entrepreneur = await _context.Entrepreneurs.FirstOrDefaultAsync(entrepreneurDabase => entrepreneurDabase.Id == entrepreneurID);

                if (entrepreneur == null)
                {
                    response.Message = "No register returned";
                    return response;
                }

                response.Data = entrepreneur;
                response.Message = "Entrepreneur returned successfully";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<EntrepreneurModel>>> ListEntrepreneurs()
        {
            ResponseModel<List<EntrepreneurModel>> response = new ResponseModel<List<EntrepreneurModel>>();

            try
            {
                var entrepreneurs = await _context.Entrepreneurs.ToListAsync();
                response.Data = entrepreneurs;
                response.Message = "All entrepreneurs returned successfully";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
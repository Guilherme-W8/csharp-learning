using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Data;
using CompanyAPI.DTO.Entrepreneur;
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

        public async Task<ResponseModel<List<EntrepreneurModel>>> CreateEntrepreneur(CreateEntrepreneurDTO entrepreneurDTO)
        {
            var response = new ResponseModel<List<EntrepreneurModel>>();

            try
            {
                var entrepreneur = new EntrepreneurModel()
                {
                    Name = entrepreneurDTO.Name,
                    Surname = entrepreneurDTO.Surname
                };

                _context.Add(entrepreneur);
                await _context.SaveChangesAsync();

                response.Data = await _context.Entrepreneurs.ToListAsync();
                response.Message = "Created";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<EntrepreneurModel>> FindEntrepreneurByCompanyId(int companyID)
        {
            ResponseModel<EntrepreneurModel> response = new ResponseModel<EntrepreneurModel>();

            try
            {
                var company = await _context.Companies
                .Include(e => e.Entrepreneur)
                .FirstOrDefaultAsync(companyDatabase => companyDatabase.Id == companyID);

                if (company == null)
                {
                    response.Message = "No register returned";
                    return response;
                }

                response.Data = company.Entrepreneur;
                response.Message = "Entrepreneur successfully returned";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
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
        public async Task<ResponseModel<List<EntrepreneurModel>>> RemoveEntrepreneur(int entrepreneurID)
        {
            var response = new ResponseModel<List<EntrepreneurModel>>();

            try
            {
                var entrepreneur = await _context.Entrepreneurs
                .FirstOrDefaultAsync(entrepreneurDatabase => entrepreneurDatabase.Id == entrepreneurID);

                if (entrepreneur == null)
                {
                    response.Message = "no entrepreneurs located";
                    return response;
                }

                _context.Remove(entrepreneur);
                await _context.SaveChangesAsync();

                response.Data = await _context.Entrepreneurs.ToListAsync();
                response.Message = "Entrepreneur successfully removed";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<EntrepreneurModel>>> EditEntrepreneur(EditEntrepreneurDTO editEntrepreneurDTO)
        {
            var response = new ResponseModel<List<EntrepreneurModel>>();

            try
            {
                var entrepreneur = await _context.Entrepreneurs
                .FirstOrDefaultAsync(entrepreneurDatabase => entrepreneurDatabase.Id == editEntrepreneurDTO.Id);

                if (entrepreneur == null)
                {
                    response.Message = "no entrepreneurs located";
                    return response;
                }

                entrepreneur.Name = editEntrepreneurDTO.Name;
                entrepreneur.Surname = editEntrepreneurDTO.Surname;

                _context.Update(entrepreneur);

                await _context.SaveChangesAsync();

                response.Data = await _context.Entrepreneurs.ToListAsync();
                response.Message = "Entrepreneur successfully edited";

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
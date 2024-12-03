using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Data;
using CompanyAPI.DTO.Company;
using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services.Company
{
    public class CompanyService : ICompanyInterface
    {
        private readonly AppDbContext _context;
        public CompanyService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<CompanyModel>>> CreateCompany(CreateCompanyDTO companyDTO)
        {
            var response = new ResponseModel<List<CompanyModel>>();

            try
            {
                var entrepreneur = await _context.Entrepreneurs
                .FirstOrDefaultAsync(e => e.Id == companyDTO.Entrepreneur.Id);

                if (entrepreneur == null)
                {
                    response.Message = "Entrepreneur register not found";
                    return response;
                }

                var company = new CompanyModel()
                {
                    Name = companyDTO.Name,
                    Industry = companyDTO.Industry,
                    Entrepreneur = entrepreneur
                };

                _context.Add(company);
                await _context.SaveChangesAsync();

                response.Data = await _context.Companies.Include(e => e.Entrepreneur).ToListAsync();
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<CompanyModel>>> EditCompany(EditCompanyDTO editCompanyDTO)
        {
            var response = new ResponseModel<List<CompanyModel>>();

            try
            {
                var company = await _context.Companies
                .Include(e => e.Entrepreneur)
                .FirstOrDefaultAsync(c => c.Id == editCompanyDTO.Id);

                var entrepreneur = await _context.Entrepreneurs
                .FirstOrDefaultAsync(e => e.Id == editCompanyDTO.Entrepreneur.Id);

                if (company == null)
                {
                    response.Message = "Company register not found";
                    return response;
                }

                if (entrepreneur == null)
                {
                    response.Message = "Entrepreneur register not found";
                    return response;
                }

                company.Name = editCompanyDTO.Name;
                company.Industry = editCompanyDTO.Industry;
                company.Entrepreneur = entrepreneur;

                _context.Update(company);
                await _context.SaveChangesAsync();

                response.Data = await _context.Companies.ToListAsync();

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<CompanyModel>>> FindCompanyByEntrepreneurId(int entrepreneurID)
        {
            var response = new ResponseModel<List<CompanyModel>>();

            try
            {
                var company = await _context.Companies.Include(e => e.Entrepreneur).Where(companyDatabase => companyDatabase.Entrepreneur.Id == entrepreneurID).ToListAsync();

                if (company == null)
                {
                    response.Message = "No register returned";
                    return response;
                }

                response.Data = company;
                response.Message = "Companies successfully returned";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<CompanyModel>> FindCompanyById(int companyID)
        {
            var response = new ResponseModel<CompanyModel>();

            try
            {
                var company = await _context.Companies.FirstOrDefaultAsync(companyDatabase => companyDatabase.Id == companyID);

                if (company == null)
                {
                    response.Message = "No register returned";
                    return response;
                }

                response.Data = company;
                response.Message = "Company returned successfully";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<CompanyModel>>> ListCompanies()
        {
            var response = new ResponseModel<List<CompanyModel>>();

            try
            {
                var companies = await _context.Companies.ToListAsync();
                response.Data = companies;
                response.Message = "All companies returned successfully";

                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<List<CompanyModel>>> RemoveCompany(int companyID)
        {
            throw new NotImplementedException();
        }
    }
}
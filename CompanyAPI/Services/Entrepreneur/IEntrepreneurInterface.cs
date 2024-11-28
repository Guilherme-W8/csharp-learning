using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.DTO.Entrepreneur;
using CompanyAPI.Models;

namespace CompanyAPI.Services.Entrepreneur
{
    public interface IEntrepreneurInterface
    {
        Task<ResponseModel<List<EntrepreneurModel>>> ListEntrepreneurs();
        Task<ResponseModel<EntrepreneurModel>> FindEntrepreneurById(int entrepreneurID);
        Task<ResponseModel<EntrepreneurModel>> FindEntrepreneurByCompanyId(int companyID);
        Task<ResponseModel<List<EntrepreneurModel>>> CreateEntrepreneur(CreateEntrepreneurDTO entrepreneurDTO);
        Task<ResponseModel<List<EntrepreneurModel>>> EditEntrepreneur(EditEntrepreneurDTO editEntrepreneurDTO);
        Task<ResponseModel<List<EntrepreneurModel>>> RemoveEntrepreneur(int entrepreneurID);
    }
}
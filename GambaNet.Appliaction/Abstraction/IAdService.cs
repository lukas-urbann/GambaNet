using GambaNet_Web.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet_Web.Application.Abstraction
{
    public interface IAdService
    {
        Task UploadAdAsync(Ad ad, IFormFile image);
        Task<Ad> GetRandomAdAsync();
        Task<IEnumerable<Ad>> GetAllAdsAsync(); // Add this method
        Task<Ad> GetAdByIdAsync(int id); // Add this method
        Task AddAdAsync(Ad ad); // Add this method
        Task UpdateAdAsync(Ad ad); // Add this method
        Task DeleteAdAsync(int id); // Add this method
    }
}

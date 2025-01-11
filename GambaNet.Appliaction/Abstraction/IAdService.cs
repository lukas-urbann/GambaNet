using GambaNet.Domain.Entities;
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
    }
}

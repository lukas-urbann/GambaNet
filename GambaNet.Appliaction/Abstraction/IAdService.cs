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
        IList<Ad> Select();
        void Create(Ad ad);
        bool Delete(int id);
        void Update(Ad ad);
        Task<Ad> GetRandomAdAsync();
        Task DeleteAdAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambaNet_Web.Application.Abstraction
{
    public interface IReCaptchaService
    {
        Task<bool> VerifyCaptchaAsync(string token);
    }
}

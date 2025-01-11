using GambaNet_Web.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GambaNet_Web.ViewComponents
{
    public class RandomAdViewComponent : ViewComponent
    {
        private readonly IAdService _adService;

        public RandomAdViewComponent(IAdService adService)
        {
            _adService = adService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ad = await _adService.GetRandomAdAsync();
            return View(ad);
        }
    }
}
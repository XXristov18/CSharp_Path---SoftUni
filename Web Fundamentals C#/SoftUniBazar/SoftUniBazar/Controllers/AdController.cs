using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Services.Interfaces;
using SoftUniBazar.ViewModels.ad;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly IAdService service;
        private readonly ICategoryService categoryService;
        public AdController(IAdService service, ICategoryService categoryService)
        {
            this.service = service;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> All()
        {
            var ads = await service.AllAsync();
            return View(ads);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await service.GetAdAsync(id);

            var model = new AdUpdateViewModel
            {
                Name = ad.Name,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                CategoryId = ad.CategoryId
            };
            model.Categories = await categoryService.AllAsync();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdUpdateViewModel model)
        {
            model.Categories = await categoryService.AllAsync();
            await service.EditAsync(id, model);
            return RedirectToAction("All");
        }
        public async Task<IActionResult> Add()
        {
            var productFromModel = new AdAddViewModel()
            {
                Categories = await this.categoryService.AllAsync(),
            };

            return View(productFromModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AdAddViewModel model)
        {
            var userId = GetUserId();
            model.Categories = await categoryService.AllAsync();
            if (ModelState.IsValid)
            {
                await service.AddAsync(userId,model);
            }
            return RedirectToAction("All");
        }
        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();
            var ads = await service.CartAsync(userId);
            if (ads.Ads.Count() == 0)
            {
                return NotFound();
            }
            return View(ads);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            try
            {
                await service.AddToCart(GetUserId(), id);
                return RedirectToAction("Cart");
            }
            catch (Exception)
            {
                return RedirectToAction("All");
            }

        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await service.RemoveFromCart(GetUserId(), id);
            return RedirectToAction("All");
        }
        public string GetUserId()
        {
            string userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userIdString))
            {
                return userIdString;
            }
            else
            {
                throw new InvalidOperationException("User ID not found or invalid.");
            }
        }

    }
}
using Guards;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Entities;
using SoftUniBazar.Services.Interfaces;
using SoftUniBazar.ViewModels.ad;
using System;

namespace SoftUniBazar.Services
{
    public class AdService : IAdService
    {
        private readonly BazarDbContext context;
        public AdService(BazarDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(string id,AdAddViewModel model)
        {
            Guard.ArgumentNotNull(model, nameof(model));
            var ad = new Ad
            {
                OwnerId = id,
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CreatedOn = DateTime.Now,
                Price = model.Price,
                CategoryId = model.CategoryId,
            };
            await context.AddAsync(ad);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<AdAllViewModel>> AllAsync()
        {
            return await context.Ads
                .Select(x => new AdAllViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Price = x.Price,
                    Owner = x.Owner,
                    Category = x.Category.Name,
                    CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd H:mm")
                }).ToListAsync();
        }

        public async Task<AdCartViewModel> CartAsync(string id)
        {
            var cart = context.AdBuyers
       .Include(x => x.Ad)
       .Where(x => x.BuyerId == id);

            var cartToShow = new AdCartViewModel
            {
                BuyerId = id,
                Ads = await cart.Select(x => new AdAllViewModel
                {
                    Id = x.Ad.Id,
                    Name = x.Ad.Name,
                    Description = x.Ad.Description,
                    ImageUrl = x.Ad.ImageUrl,
                    CreatedOn = x.Ad.CreatedOn.ToString(),
                    Category = x.Ad.Category.Name,
                    Price = x.Ad.Price,
                    Owner = x.Ad.Owner
                }).ToListAsync()
            };
            return cartToShow;

        }

        public async Task EditAsync(int id, AdUpdateViewModel model)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            var adToEdit = await context.Ads.FindAsync(id);

            Guard.ArgumentNotNull(adToEdit, nameof(adToEdit));
            adToEdit.Name = model.Name;
            adToEdit.Description = model.Description;
            adToEdit.ImageUrl = model.ImageUrl;
            adToEdit.Price = model.Price;
            adToEdit.CategoryId = model.CategoryId;
            await context.SaveChangesAsync();

        }
        public async Task RemoveFromCart(string userId, int id)
        {
            Guard.ArgumentNotNull(userId, nameof(userId));
            Guard.ArgumentNotNull(id, nameof(id));

            var ab = new AdBuyer
            {
                BuyerId = userId,
                AdId = id,
            };
            if (context.AdBuyers.Contains(ab))
            {
                context.AdBuyers.Remove(ab);
            }
            await context.SaveChangesAsync();
        }
        public async Task AddToCart(string userId, int id)
        {
            Guard.ArgumentNotNull(userId, nameof(userId));
            Guard.ArgumentNotNull(id, nameof(id));

            var ab = new AdBuyer
            {
                BuyerId = userId,
                AdId = id,
            };
            if (!context.AdBuyers.Contains(ab))
            {
                await context.AdBuyers.AddAsync(ab);
            }
            else
            {
                throw new Exception();
            }
            await context.SaveChangesAsync();
        }
        public async Task<Ad> GetAdAsync(int id)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            var product = await context.Ads.FirstOrDefaultAsync(x => x.Id == id);
            Guard.ArgumentNotNull(product, nameof(product));
            return product;
        }
    }
}

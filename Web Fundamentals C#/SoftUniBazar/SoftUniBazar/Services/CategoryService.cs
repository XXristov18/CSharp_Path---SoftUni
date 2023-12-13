using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Services.Interfaces;
using SoftUniBazar.ViewModels.category;

namespace SoftUniBazar.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext context;
        public CategoryService(BazarDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CategoryAllViewModel>> AllAsync()
        {
            return await context.Categories.Select(x => new CategoryAllViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }
    }
}

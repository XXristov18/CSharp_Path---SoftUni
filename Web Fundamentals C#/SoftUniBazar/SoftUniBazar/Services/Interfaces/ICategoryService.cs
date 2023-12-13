using SoftUniBazar.ViewModels.category;

namespace SoftUniBazar.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryAllViewModel>> AllAsync();

    }
}

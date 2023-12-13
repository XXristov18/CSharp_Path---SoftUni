using SoftUniBazar.Data.Entities;
using SoftUniBazar.ViewModels.ad;

namespace SoftUniBazar.Services.Interfaces
{
    public interface IAdService
    {
        Task<ICollection<AdAllViewModel>> AllAsync();
        Task AddAsync(string id,AdAddViewModel model);
        Task EditAsync(int id, AdUpdateViewModel model);
        Task AddToCart(string userId,int id);
        Task RemoveFromCart(string userId,int id);
        Task<AdCartViewModel> CartAsync(string id);
        Task<Ad> GetAdAsync(int id);
    }
}

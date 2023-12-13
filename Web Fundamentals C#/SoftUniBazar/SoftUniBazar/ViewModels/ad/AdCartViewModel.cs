using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Entities;

namespace SoftUniBazar.ViewModels.ad
{
    public class AdCartViewModel
    {
        public string BuyerId { get; set; } = null!;
        public virtual IdentityUser Buyer { get; set; } = null!;
        public ICollection<AdAllViewModel> Ads { get; set; } = new HashSet<AdAllViewModel>();
    }
}
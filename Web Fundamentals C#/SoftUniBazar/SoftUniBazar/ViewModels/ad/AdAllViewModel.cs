using Microsoft.AspNetCore.Identity;

namespace SoftUniBazar.ViewModels.ad
{
    public class AdAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string OwnerId { get; set; } = null!;
        public virtual IdentityUser Owner { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string CreatedOn { get; set; }
        public int CategoryId { get; set; }
        public virtual string Category { get; set; } = null!;
    }
}

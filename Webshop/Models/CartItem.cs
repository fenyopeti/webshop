namespace Webshop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class CartItem
    {
        public Guid Id { get; set; }

        [StringLength(255)]
        public string CartId { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(Resources.Cart))]
        public int? Quantity { get; set; }

        public DateTime? DateCreated { get; set; }

        public Guid? MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}

namespace Webshop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class OrdersItem
    {
        public Guid Id { get; set; }

        public Guid? OrderId { get; set; }

        public Guid? MenuItemId { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(Resources.Cart))]
        public int? Quantity { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Order Order { get; set; }
    }
}

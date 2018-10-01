namespace Webshop.Models
{
    using System;

    public partial class OrdersItem
    {
        public Guid Id { get; set; }

        public Guid? OrderId { get; set; }

        public Guid? MenuItemId { get; set; }

        public int? Quantity { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Order Order { get; set; }
    }
}

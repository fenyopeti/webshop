namespace Webshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuItem()
        {
            CartItems = new HashSet<CartItem>();
            OrdersItems = new HashSet<OrdersItem>();
        }

        public Guid Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Category", ResourceType = typeof(Resources.MenuItem))]
        public string Category { get; set; }

        [StringLength(255)]
        [Display(Name = "Description", ResourceType = typeof(Resources.MenuItem))]
        public string Description { get; set; }

        [StringLength(255)]
        [Display(Name = "Name", ResourceType = typeof(Resources.MenuItem))]
        public string Name { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.MenuItem))]
        public int? Price { get; set; }

        public int? Spicy { get; set; }

        public int? Vegatarian { get; set; }

        public int? OrderedSum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartItem> CartItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
    }
}

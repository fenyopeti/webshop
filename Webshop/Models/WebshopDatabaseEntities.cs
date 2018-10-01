namespace Webshop.Models
{
    using System.Data.Entity;

    public partial class WebshopDatabaseEntities : DbContext
    {
        public WebshopDatabaseEntities()
            : base("name=Models")
        {
        }

        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersItem> OrdersItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .Property(e => e.CartId)
                .IsUnicode(false);

            modelBuilder.Entity<MenuItem>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<MenuItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MenuItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}

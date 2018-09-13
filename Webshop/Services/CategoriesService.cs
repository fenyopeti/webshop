using System.Collections.Generic;
using System.Linq;
using Webshop.Models;

namespace Webshop.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly WebshopDatabaseEntities1 db = new WebshopDatabaseEntities1();

        public IEnumerable<string> FindAll()
        {
            return db.MenuItems.Select(item => item.Category).Distinct();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
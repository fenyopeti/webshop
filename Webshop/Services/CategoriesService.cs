using System.Collections.Generic;
using System.Linq;
using Webshop.Models;

namespace Webshop.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly WebshopDatabaseEntities db = new WebshopDatabaseEntities();

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
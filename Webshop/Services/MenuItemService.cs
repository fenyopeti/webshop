using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly WebshopDatabaseEntities1 db = new WebshopDatabaseEntities1();

        public async Task<IEnumerable<MenuItem>> FindAllAsync()
        {
            return await db.MenuItems.ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> FindTopAsync(int limit)
        {
            return await db.MenuItems
                .OrderByDescending(item => item.OrderedSum)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> FindCategoryAsync(string category, string search = "")
        {
            return await db.MenuItems
                .Where(item => item.Category == category)
                .Where(item => item.Description.Contains(search))
                .ToListAsync();
        }
  
        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
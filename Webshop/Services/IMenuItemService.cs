using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Services
{
    public interface IMenuItemService : IDisposable
    {
        Task<IEnumerable<MenuItem>> FindAllAsync();
        Task<IEnumerable<MenuItem>> FindTopAsync(int limit);
        Task<IEnumerable<MenuItem>> FindCategoryAsync(string category, string searchKey);
    }}
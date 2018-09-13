using System;
using System.Collections.Generic;

namespace Webshop.Services
{
    public interface ICategoriesService : IDisposable
    {
        IEnumerable<string> FindAll();
    }
}
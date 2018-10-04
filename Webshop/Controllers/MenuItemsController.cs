using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webshop.Services;

namespace Webshop.Controllers
{
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly ICategoriesService _categoriesService;

        public MenuItemsController(IMenuItemService menuItemService, ICategoriesService categoriesService)
        {
            _menuItemService = menuItemService;
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewBag.Categories = _categoriesService.FindAll();
            return View(await _menuItemService.FindTopAsync(10));
        }

        [HttpGet]
        public async Task<ActionResult> Category(string id)
        {
            ViewBag.Category = id;
            var searchKey = Request.Params["search"] ?? "";
            
            return View(await _menuItemService.FindCategoryAsync(id, searchKey));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _menuItemService.Dispose();
                _categoriesService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

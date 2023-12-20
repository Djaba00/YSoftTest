using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using YSoftTest.Services;
using YSoftTest.ViewModels;

namespace YSoftTest.Controllers
{
    public class HomeController : Controller
    {
        private IProductsService productsService { get; set; }
        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<ActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var itemsCount = await productsService.GetProductsTotalCount();

            var products = await productsService.GetProductsPage(pageNumber, pageSize);

            var result = new ProductPageViewModel();

            result.Page = new PageViewModel(itemsCount, pageNumber, pageSize);
            result.Products = products;

            return View(result);
        }

        public async Task<ActionResult> GenerateProducts(int count)
        {
            await productsService.GenerateProductsForDb(count);

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
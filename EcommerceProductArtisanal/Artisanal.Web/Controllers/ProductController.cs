using Artisanal.Web.Models;
using Artisanal.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Artisanal.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService proudtService)
        {
            _productService = proudtService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> List = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
                List = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            return View(List);
        }
    }
}

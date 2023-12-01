using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebAPI.Common.Result;
using WebUI.Common.Tools;
using WebUI.ViewModels.Category;
using WebUI.ViewModels.Product;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

		public ProductController(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            TempData["responseType"] = ResponseType.Warning;
            var response = await client.GetAsync("http://localhost:20304/api/Products/GetProductWithCategories");
            var data = JsonConvert.DeserializeObject<DataResult<List<ProductListModel>>>(await response.Content.ReadAsStringAsync());
            if (data.ResponseType == ResponseType.Success)
            {
                return View(data.Data);
            }
            return View(new List<ProductListModel>());
        }

        public async Task<IActionResult> Delete(int id)
        {
			var client = _httpClient.CreateClient();
			var response = await client.PostAsync("http://localhost:20304/api/Products/delete?id=" + id, null);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
            ViewBag.v = await getCategoriesWithDropList();
			TempData["responseType"] = ResponseType.Warning;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(ProductAddModel model)
		{
            var client = _httpClient.CreateClient();
            ViewBag.v = await getCategoriesWithDropList();
            if (ModelState.IsValid)
			{
				var response = await client.PostAsJsonAsync("http://localhost:20304/api/Products/add", model);
				var deserializeObject = JsonConvert.DeserializeObject<DataResult<ProductAddModel>>(await response.Content.ReadAsStringAsync());
				if (deserializeObject.ResponseType == ResponseType.Success)
				{
                    TempData["responseType"] = deserializeObject.ResponseType;
                    TempData["responseMessage"] = deserializeObject.Message;
                    return View();
                }
                TempData["responseType"] = ResponseType.Error;
                TempData["responseMessage"] = "Ürün ekleme sırasında hata meydana geldi!";
            }
            TempData["responseType"] = ResponseType.Warning;
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("http://localhost:20304/api/Products/"+id);
            var deserializeData = JsonConvert.DeserializeObject<DataResult<ProductUpdateModel>>(await response.Content.ReadAsStringAsync());
            ViewBag.v = await getCategoriesWithDropList();
            TempData["responseType"] = ResponseType.Warning;
            if (deserializeData.ResponseType == ResponseType.Success)
            {
                return View(deserializeData.Data);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateModel model)
        {
            var client = _httpClient.CreateClient();
            ViewBag.v = await getCategoriesWithDropList();
            if (ModelState.IsValid)
            {
                var response = await client.PostAsJsonAsync("http://localhost:20304/api/Products/update", model);
                var deserializeObject = JsonConvert.DeserializeObject<DataResult<ProductUpdateModel>>(await response.Content.ReadAsStringAsync());
                if (deserializeObject.ResponseType == ResponseType.Success)
                {
                    TempData["responseType"] = deserializeObject.ResponseType;
                    TempData["responseMessage"] = deserializeObject.Message;
                    return View();
                }
                TempData["responseType"] = ResponseType.Error;
                TempData["responseMessage"] = "Ürün ekleme sırasında hata meydana geldi!";
            }
            TempData["responseType"] = ResponseType.Warning;
            return View(model);
        }



        // voids

        public async Task<List<SelectListItem>> getCategoriesWithDropList()
		{
            var client = _httpClient.CreateClient();
            var categoryResponse = await client.GetAsync("http://localhost:20304/api/Categories/getall");
            var data = JsonConvert.DeserializeObject<DataResult<List<CategoryListModel>>>(await categoryResponse.Content.ReadAsStringAsync());
            if (data != null)
            {
                List<SelectListItem> selectList = (from x in data.Data
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
                return selectList;
            }
            return new List<SelectListItem>();
        }
	}
}

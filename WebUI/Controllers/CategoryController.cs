using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebAPI.Common.Result;
using WebUI.Common.Tools;
using WebUI.ViewModels.Category;

namespace WebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClient;

		public CategoryController(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClient.CreateClient();
			var response = await client.GetAsync("http://localhost:20304/api/Categories/getall");
			var jsonData = JsonConvert.DeserializeObject<DataResult<List<CategoryListModel>>>(await response.Content.ReadAsStringAsync());
			return View(jsonData);
		}
		[HttpGet]
		public IActionResult Add()
		{
			TempData["responseType"] = ResponseType.Warning;
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(CategoryAddModel model)
		{
			if (ModelState.IsValid)
			{
				var client = _httpClient.CreateClient();
				var serializeObject = JsonConvert.SerializeObject(model);
				var response = await client.PostAsync("http://localhost:20304/api/Categories/add", RestfulTools.GetContent(serializeObject));
				var deserializeObject = JsonConvert.DeserializeObject<DataResult<CategoryAddModel>>(await response.Content.ReadAsStringAsync());
                TempData["responseType"] = deserializeObject.ResponseType;
                TempData["responseMessage"] = deserializeObject.Message;
				model = new CategoryAddModel();
                return View(model);
			}
            TempData["responseType"] = ResponseType.Warning;
            return View();
		}
		public async Task<IActionResult> Delete(int id)
		{
			var client = _httpClient.CreateClient();
			var response = await client.PostAsync("http://localhost:20304/api/Categories/delete?id=" + id,null);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(int id)
		{
            TempData["responseType"] = ResponseType.Warning;
            var client = _httpClient.CreateClient();
			var response = await client.GetAsync("http://localhost:20304/api/Categories/"+id);
			var jsonData = JsonConvert.DeserializeObject<DataResult<CategoryListModel>>(await response.Content.ReadAsStringAsync());
			if (jsonData.ResponseType == ResponseType.Success)
			{
                CategoryUpdateModel model = new()
                {
                    Id = jsonData.Data.Id,
                    CategoryName = jsonData.Data.CategoryName,
                    Status = jsonData.Data.Status
                };
				return View(model);
            }
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Update(CategoryUpdateModel categoryUpdateModel)
		{
			if (ModelState.IsValid)
			{
                var client = _httpClient.CreateClient();
                var response = await client.PostAsJsonAsync("http://localhost:20304/api/Categories/update", categoryUpdateModel);
                var deserializeObject = JsonConvert.DeserializeObject<DataResult<CategoryUpdateModel>>(await response.Content.ReadAsStringAsync());
                TempData["responseType"] = deserializeObject.ResponseType;
                TempData["responseMessage"] = deserializeObject.Message;
                if (response.IsSuccessStatusCode)
                {
                    return View();
                }
            }
			TempData["responseType"] = ResponseType.Error;
            TempData["responseMessage"] = "İşlem sırasında hata meydana geldi!";
            return View(categoryUpdateModel);
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutHeaderComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

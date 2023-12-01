using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

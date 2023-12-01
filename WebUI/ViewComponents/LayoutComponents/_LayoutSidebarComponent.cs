using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

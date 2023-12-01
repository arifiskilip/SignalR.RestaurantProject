using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

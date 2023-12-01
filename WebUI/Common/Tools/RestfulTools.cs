using System.Text;

namespace WebUI.Common.Tools
{
    public static class RestfulTools
    {
        public static StringContent GetContent(string content)
        {
            return new StringContent(content, Encoding.UTF8, "application/json");
            
        }
    }
}

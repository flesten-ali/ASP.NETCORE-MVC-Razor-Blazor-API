using System.Text;

namespace BathenyShop;

public class UseCustomeMiddleware
{
    private RequestDelegate _nextMiddleware;

    public UseCustomeMiddleware(RequestDelegate nextMiddleware)
    {
        _nextMiddleware = nextMiddleware;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Path.ToString().ToLower() == "/pie/list")
        {
            await httpContext.Response.WriteAsync("This is the Pie controller", Encoding.UTF8);
        }
        else
        {
            await _nextMiddleware.Invoke(httpContext);
        }
    }
}

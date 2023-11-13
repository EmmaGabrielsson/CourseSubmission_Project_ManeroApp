namespace Manero.Middleware;

public class EssentialCookieConsentMiddleware
{
    private readonly RequestDelegate _next;

    public EssentialCookieConsentMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Check if the "OrderID" cookie exists and its value
        var orderId = context.Request.Cookies["OrderID"];

        if (string.IsNullOrEmpty(orderId))
        {
            // Create a new "OrderID" and set it as a cookie
            orderId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(24),
                IsEssential = true,
                Path = "/"
            };

            context.Response.Cookies.Append("OrderID", orderId, cookieOptions);
        }

        // Continue processing the request
        await _next(context);
    }
}


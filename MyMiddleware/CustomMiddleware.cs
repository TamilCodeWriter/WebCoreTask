namespace WebCoreTask.MyMiddleware
{
    public class CustomMiddleware
    {
        readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log Request
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}Custom");
            Console.WriteLine("Befor Process the request");

            //  await context.Response.WriteAsync("Before processing the request");
            await _next(context);
            await context.Response.WriteAsync("After processing the request");
        }

    }
}

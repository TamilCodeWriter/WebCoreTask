namespace WebCoreTask.MyMiddleware
{
    public class SimpleMiddleware
    {

        readonly RequestDelegate _Next;

        public SimpleMiddleware(RequestDelegate next)
        {
            _Next = next;
        }
        public async Task InvokeAsync(HttpContext context) {

            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            // await context.Response.WriteAsync("Before processing request");
            await _Next(context);
            await context.Response.WriteAsync("After processing SimpleMiddleware request");
        }
    }
}

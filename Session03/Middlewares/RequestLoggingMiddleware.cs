namespace Session03.Middlewares;

public class RequestLoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, RequestLoggerService requestLogger)
    {
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();

        await requestLogger.LogAsync(context.Request.Method, context.Request.Path, body);

        await next(context);
    }
}

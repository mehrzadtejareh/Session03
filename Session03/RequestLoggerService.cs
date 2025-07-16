namespace Session03;

public class RequestLoggerService(RequestLogDbContext db)
{
    public async Task LogAsync(string method, string path, string body)
    {
        var log = new RequestLog
        {
            Method = method,
            Path = path,
            Body = body
        };

        db.RequestLogs.Add(log);
        await db.SaveChangesAsync();
    }
}
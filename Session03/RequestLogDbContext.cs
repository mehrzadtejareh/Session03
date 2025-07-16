using Microsoft.EntityFrameworkCore;

namespace Session03;

public class RequestLogDbContext(DbContextOptions<RequestLogDbContext> options) : DbContext(options)
{
    public DbSet<RequestLog> RequestLogs { get; set; }
}
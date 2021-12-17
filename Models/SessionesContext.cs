using Microsoft.EntityFrameworkCore;

namespace Eroski.Models
{
    public class SessionesContext : DbContext
    {
        public SessionesContext(DbContextOptions<SessionesContext> options)
            : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
    }
}
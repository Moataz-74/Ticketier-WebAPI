using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Ticketier_WebAPI.Core.Models;

namespace Ticketier_WebAPI.Core.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }
        public DbSet<Ticket> Tickets { get; set; }
    }
}

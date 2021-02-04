using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StockExchange.Host.indentity;

namespace StockExchange.Host.dbcontext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
    {
        
    }
}
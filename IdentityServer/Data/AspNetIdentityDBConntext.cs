using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class AspNetIdentityDBConntext:IdentityDbContext
    {
        public AspNetIdentityDBConntext(DbContextOptions<AspNetIdentityDBConntext> options) : base(options)
        {

        }
    }
}

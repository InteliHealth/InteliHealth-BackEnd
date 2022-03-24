using Microsoft.EntityFrameworkCore;

namespace InteliHealth.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}

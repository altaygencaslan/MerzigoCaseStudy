using ContentAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business
{
    public class ContentDbContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_02.ContextVeri
{
    class MusteriDbContext : DbContext
    {
        public DbSet<Musteri> musteris { get; set; }
    }
}

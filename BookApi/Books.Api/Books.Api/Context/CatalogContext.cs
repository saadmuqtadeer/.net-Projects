using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Context
{
    public class CatalogContext:DbContext
    {
        public CatalogContext(DbContextOptions options): base(options) {
        }
        public DbSet<Book> Products { get; set; }

    }

}
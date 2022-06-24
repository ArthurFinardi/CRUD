using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class CrudDataContext : DbContext
    {
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }

        public CrudDataContext(DbContextOptions<CrudDataContext> options)
            : base(options)
        {
        }



    }
}
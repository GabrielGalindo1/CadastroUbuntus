using CadastroUbuntu.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroUbuntu.Data
{
    public class BancoContext : DbContext
    { 
        public BancoContext (DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ListaModel> Listas { get; set; }
    }
}

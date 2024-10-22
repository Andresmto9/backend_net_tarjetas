using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base (options)
        {       
        }
        public DbSet<TarjetaCreditoModel> Tarjeta {  get; set; }
    }
}

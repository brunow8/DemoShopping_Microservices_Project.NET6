using DemoShopping.ProductAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DemoShopping.ProductAPI.Data.Context {
    public class MyApplicationContext : DbContext {
        public MyApplicationContext(DbContextOptions<MyApplicationContext> options) : base(options) {

        }

        public DbSet<Product> Products {get; set;}
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp4
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> order { get; set; }
        public ApplicationContext() : base("pizza.db")
        {
        }
    }
}

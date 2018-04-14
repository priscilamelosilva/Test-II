using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Vendas.Models;

namespace Vendas.DAL
{
    public class Context : DbContext
    {
        public Context() : base("Vendas")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido{ get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
    }
}
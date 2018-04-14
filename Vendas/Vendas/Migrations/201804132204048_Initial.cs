namespace Vendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Idade = c.Int(nullable: false),
                        Cpf = c.String(),
                        Email = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.PedidoItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Material = c.String(),
                        Quantidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdPedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.IdPedido, cascadeDelete: true)
                .Index(t => t.IdPedido);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoItem", "IdPedido", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "IdCliente", "dbo.Cliente");
            DropIndex("dbo.PedidoItem", new[] { "IdPedido" });
            DropIndex("dbo.Pedido", new[] { "IdCliente" });
            DropTable("dbo.PedidoItem");
            DropTable("dbo.Pedido");
            DropTable("dbo.Cliente");
        }
    }
}

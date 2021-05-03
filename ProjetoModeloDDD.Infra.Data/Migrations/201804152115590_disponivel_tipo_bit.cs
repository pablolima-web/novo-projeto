namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class disponivel_tipo_bit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Disponivel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Disponivel", c => c.String(maxLength: 100, unicode: false));
        }
    }
}

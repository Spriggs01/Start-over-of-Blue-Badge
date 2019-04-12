namespace HealthyEats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedEditViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavoriteRecipe", "RecipeTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FavoriteRecipe", "RecipeTitle");
        }
    }
}

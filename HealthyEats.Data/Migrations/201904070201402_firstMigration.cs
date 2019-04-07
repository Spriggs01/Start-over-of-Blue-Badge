namespace HealthyEats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FavoriteRecipe");
            AddColumn("dbo.RecipeType", "Image", c => c.String());
            AlterColumn("dbo.FavoriteRecipe", "RecipeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Recipe", "Link", c => c.String());
            AddPrimaryKey("dbo.FavoriteRecipe", "RecipeID");
            DropColumn("dbo.FavoriteRecipe", "FavoriteRecipeID");
            DropColumn("dbo.Recipe", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipe", "Image", c => c.String(nullable: false));
            AddColumn("dbo.FavoriteRecipe", "FavoriteRecipeID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.FavoriteRecipe");
            AlterColumn("dbo.Recipe", "Link", c => c.String(nullable: false));
            AlterColumn("dbo.FavoriteRecipe", "RecipeID", c => c.Int(nullable: false));
            DropColumn("dbo.RecipeType", "Image");
            AddPrimaryKey("dbo.FavoriteRecipe", "FavoriteRecipeID");
        }
    }
}

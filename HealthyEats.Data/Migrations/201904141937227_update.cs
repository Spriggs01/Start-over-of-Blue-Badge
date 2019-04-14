namespace HealthyEats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavoriteRecipe", "RecipeID", "dbo.Recipe");
            DropIndex("dbo.FavoriteRecipe", new[] { "RecipeID" });
            AddColumn("dbo.Recipe", "FavoriteRecipe_FavoriteRecipeID", c => c.Int());
            CreateIndex("dbo.Recipe", "FavoriteRecipe_FavoriteRecipeID");
            AddForeignKey("dbo.Recipe", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe", "FavoriteRecipeID");
            DropColumn("dbo.Meal", "RecipeTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meal", "RecipeTitle", c => c.String());
            DropForeignKey("dbo.Recipe", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe");
            DropIndex("dbo.Recipe", new[] { "FavoriteRecipe_FavoriteRecipeID" });
            DropColumn("dbo.Recipe", "FavoriteRecipe_FavoriteRecipeID");
            CreateIndex("dbo.FavoriteRecipe", "RecipeID");
            AddForeignKey("dbo.FavoriteRecipe", "RecipeID", "dbo.Recipe", "RecipeID", cascadeDelete: true);
        }
    }
}

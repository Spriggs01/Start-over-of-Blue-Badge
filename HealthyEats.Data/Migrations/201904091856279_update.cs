namespace HealthyEats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe");
            DropForeignKey("dbo.MealRecipe", "Recipe_RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.FavoriteRecipes", "Recipe_RecipeID", "dbo.Recipe");
            DropIndex("dbo.MealRecipe", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.FavoriteRecipes", new[] { "FavoriteRecipe_FavoriteRecipeID" });
            DropIndex("dbo.FavoriteRecipes", new[] { "Recipe_RecipeID" });
            DropPrimaryKey("dbo.FavoriteRecipe");
            DropPrimaryKey("dbo.Recipe");
            DropPrimaryKey("dbo.FavoriteRecipes");
            DropPrimaryKey("dbo.MealRecipe");
            AddColumn("dbo.Meal", "RecipeID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavoriteRecipe", "FavoriteRecipeID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavoriteRecipe", "FavoriteList", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Recipe", "RecipeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipe", "RecipeTitle", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FavoriteRecipes", "Recipe_RecipeID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.MealRecipe", "Recipe_RecipeID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FavoriteRecipe", "FavoriteList");
            AddPrimaryKey("dbo.Recipe", "RecipeTitle");
            AddPrimaryKey("dbo.FavoriteRecipes", new[] { "FavoriteRecipe_FavoriteRecipeID", "Recipe_RecipeID" });
            AddPrimaryKey("dbo.MealRecipe", new[] { "Meal_MealID", "Recipe_RecipeID" });
            CreateIndex("dbo.MealRecipe", "Recipe_RecipeID");
            CreateIndex("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID");
            CreateIndex("dbo.FavoriteRecipes", "Recipe_RecipeID");
            AddForeignKey("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe", "FavoriteList", cascadeDelete: true);
            AddForeignKey("dbo.MealRecipe", "Recipe_RecipeID", "dbo.Recipe", "RecipeTitle", cascadeDelete: true);
            AddForeignKey("dbo.FavoriteRecipes", "Recipe_RecipeID", "dbo.Recipe", "RecipeTitle", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoriteRecipes", "Recipe_RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.MealRecipe", "Recipe_RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe");
            DropIndex("dbo.FavoriteRecipes", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.FavoriteRecipes", new[] { "FavoriteRecipe_FavoriteRecipeID" });
            DropIndex("dbo.MealRecipe", new[] { "Recipe_RecipeID" });
            DropPrimaryKey("dbo.MealRecipe");
            DropPrimaryKey("dbo.FavoriteRecipes");
            DropPrimaryKey("dbo.Recipe");
            DropPrimaryKey("dbo.FavoriteRecipe");
            AlterColumn("dbo.MealRecipe", "Recipe_RecipeID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavoriteRecipes", "Recipe_RecipeID", c => c.Int(nullable: false));
            AlterColumn("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipe", "RecipeTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Recipe", "RecipeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.FavoriteRecipe", "FavoriteList", c => c.String());
            AlterColumn("dbo.FavoriteRecipe", "FavoriteRecipeID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Meal", "RecipeID");
            AddPrimaryKey("dbo.MealRecipe", new[] { "Meal_MealID", "Recipe_RecipeID" });
            AddPrimaryKey("dbo.FavoriteRecipes", new[] { "FavoriteRecipe_FavoriteRecipeID", "Recipe_RecipeID" });
            AddPrimaryKey("dbo.Recipe", "RecipeID");
            AddPrimaryKey("dbo.FavoriteRecipe", "FavoriteRecipeID");
            CreateIndex("dbo.FavoriteRecipes", "Recipe_RecipeID");
            CreateIndex("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID");
            CreateIndex("dbo.MealRecipe", "Recipe_RecipeID");
            AddForeignKey("dbo.FavoriteRecipes", "Recipe_RecipeID", "dbo.Recipe", "RecipeTitle", cascadeDelete: true);
            AddForeignKey("dbo.MealRecipe", "Recipe_RecipeID", "dbo.Recipe", "RecipeTitle", cascadeDelete: true);
            AddForeignKey("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe", "FavoriteList", cascadeDelete: true);
        }
    }
}

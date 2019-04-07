namespace HealthyEats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeFavoriteRecipe", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe");
            DropPrimaryKey("dbo.FavoriteRecipe");
            CreateTable(
                "dbo.RecipeFavoriteRecipe",
                c => new
                    {
                        Recipe_RecipeID = c.Int(nullable: false),
                        FavoriteRecipe_FavoriteRecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeID, t.FavoriteRecipe_FavoriteRecipeID })
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.FavoriteRecipe", t => t.FavoriteRecipe_FavoriteRecipeID, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeID)
                .Index(t => t.FavoriteRecipe_FavoriteRecipeID);
            
            CreateTable(
                "dbo.MealRecipe",
                c => new
                    {
                        Meal_MealID = c.Int(nullable: false),
                        Recipe_RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meal_MealID, t.Recipe_RecipeID })
                .ForeignKey("dbo.Meal", t => t.Meal_MealID, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeID, cascadeDelete: true)
                .Index(t => t.Meal_MealID)
                .Index(t => t.Recipe_RecipeID);
            
            AddColumn("dbo.FavoriteRecipe", "FavoriteRecipeID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.FavoriteRecipe", "FavoriteList", c => c.String());
            AddColumn("dbo.Recipe", "TypeName", c => c.String());
            AddColumn("dbo.Recipe", "Dietary", c => c.String());
            AddColumn("dbo.Recipe", "Image", c => c.String());
            AddPrimaryKey("dbo.FavoriteRecipe", "FavoriteRecipeID");
            DropColumn("dbo.FavoriteRecipe", "RecipeID");
            DropColumn("dbo.Meal", "RecipeID");
            DropTable("dbo.RecipeType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeType",
                c => new
                    {
                        RecipeTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                        Dietary = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.RecipeTypeID);
            
            AddColumn("dbo.Meal", "RecipeID", c => c.Int(nullable: false));
            AddColumn("dbo.FavoriteRecipe", "RecipeID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.MealRecipe", "Recipe_RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.MealRecipe", "Meal_MealID", "dbo.Meal");
            DropForeignKey("dbo.RecipeFavoriteRecipe", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe");
            DropForeignKey("dbo.RecipeFavoriteRecipe", "Recipe_RecipeID", "dbo.Recipe");
            DropIndex("dbo.MealRecipe", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.MealRecipe", new[] { "Meal_MealID" });
            DropIndex("dbo.RecipeFavoriteRecipe", new[] { "FavoriteRecipe_FavoriteRecipeID" });
            DropIndex("dbo.RecipeFavoriteRecipe", new[] { "Recipe_RecipeID" });
            DropPrimaryKey("dbo.FavoriteRecipe");
            DropColumn("dbo.Recipe", "Image");
            DropColumn("dbo.Recipe", "Dietary");
            DropColumn("dbo.Recipe", "TypeName");
            DropColumn("dbo.FavoriteRecipe", "FavoriteList");
            DropColumn("dbo.FavoriteRecipe", "FavoriteRecipeID");
            DropTable("dbo.MealRecipe");
            DropTable("dbo.RecipeFavoriteRecipe");
            AddPrimaryKey("dbo.FavoriteRecipe", "RecipeID");
            AddForeignKey("dbo.RecipeFavoriteRecipe", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe", "FavoriteRecipeID", cascadeDelete: true);
        }
    }
}

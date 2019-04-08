namespace HealthyEats.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteRecipe",
                c => new
                    {
                        FavoriteRecipeID = c.Int(nullable: false, identity: true),
                        FavoriteList = c.String(),
                        RecipeID = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FavoriteRecipeID);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        RecipeTitle = c.String(nullable: false),
                        Link = c.String(),
                        Calories = c.Int(nullable: false),
                        TypeName = c.String(),
                        Dietary = c.String(),
                        RecipeTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        MealID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        MealName = c.String(),
                        MealDescription = c.String(),
                    })
                .PrimaryKey(t => t.MealID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
            
            CreateTable(
                "dbo.FavoriteRecipes",
                c => new
                    {
                        FavoriteRecipe_FavoriteRecipeID = c.Int(nullable: false),
                        Recipe_RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FavoriteRecipe_FavoriteRecipeID, t.Recipe_RecipeID })
                .ForeignKey("dbo.FavoriteRecipe", t => t.FavoriteRecipe_FavoriteRecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeID, cascadeDelete: true)
                .Index(t => t.FavoriteRecipe_FavoriteRecipeID)
                .Index(t => t.Recipe_RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.FavoriteRecipes", "Recipe_RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.FavoriteRecipes", "FavoriteRecipe_FavoriteRecipeID", "dbo.FavoriteRecipe");
            DropForeignKey("dbo.MealRecipe", "Recipe_RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.MealRecipe", "Meal_MealID", "dbo.Meal");
            DropIndex("dbo.FavoriteRecipes", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.FavoriteRecipes", new[] { "FavoriteRecipe_FavoriteRecipeID" });
            DropIndex("dbo.MealRecipe", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.MealRecipe", new[] { "Meal_MealID" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.FavoriteRecipes");
            DropTable("dbo.MealRecipe");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Meal");
            DropTable("dbo.Recipe");
            DropTable("dbo.FavoriteRecipe");
        }
    }
}

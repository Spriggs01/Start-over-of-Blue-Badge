using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using HealthyEats.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HealthyEats.WebMVC.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<FavoriteRecipe> FavoriteRecipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

          // modelBuilder.Entity<FavoriteRecipe>()
             //   .HasMany<Recipe>(s => s.Recipes)
             //   .WithMany(c => c.FavoriteRecipes)
              //  .Map(cs =>
              //  {
               //     cs.MapLeftKey("FavoriteRecipe_FavoriteRecipeID");
                 //   cs.MapRightKey("Recipe_RecipeID");
                   // cs.ToTable("FavoriteRecipes");
               // });

           // modelBuilder.Entity<Meal>()
             //   .HasMany<Recipe>(s => s.Recipes)
               // .WithMany(c => c.Meals)
                //.Map(cs =>
               // {
                 //   cs.MapLeftKey("Meal_MealID");
                   // cs.MapRightKey("Recipe_RecipeID");
                    //cs.ToTable("MealRecipe");
                //});

           
        }


        public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
        {
            public IdentityUserLoginConfiguration()
            {
                HasKey(IdentityUserLogin => IdentityUserLogin.UserId);
            }
        }

        public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
        {

            public IdentityUserRoleConfiguration()
            {
                HasKey(iur => iur.RoleId);
            }

        }

    }
}
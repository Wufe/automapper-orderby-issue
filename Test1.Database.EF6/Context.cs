using System.Data.Entity;
using Test1.Database.Entities;

namespace Test1.Database.EF6
{
	public class Context : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public DbSet<Article> Articles { get; set; }

		public Context() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AutomapperTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
		{ }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{


			modelBuilder.Entity<Product>()
				.ToTable("Products")
				.HasKey(e => e.Id);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Articles)
				.WithRequired(e => e.Product)
				.HasForeignKey(e => e.ProductId);

			modelBuilder.Entity<Article>()
				.ToTable("Article")
				.HasKey(pa => new { pa.ProductId, pa.Id });

		}
	}
}

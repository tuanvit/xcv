using Microsoft.EntityFrameworkCore;
using Shopping.Models;

namespace Shopping.Repository
{
	public class SeedData
	{
		public static void SeedingData(DataContext _context)
		{
			_context.Database.Migrate();
			if (!_context.Products.Any())
			{

				CategoryModel macbook = new CategoryModel { Name = "Macbook", Slug = "macbook", Description = "Macbook is the best", Status = 1 };
				CategoryModel pc = new CategoryModel { Name = "Pc", Slug = "pc", Description = "PC is the best", Status = 1 };

				BrandModel apple = new BrandModel { Name = "Apple", Slug = "apple", Description = "Apple is the best", Status = 1 };
				BrandModel samsung = new BrandModel { Name = "Samsung", Slug = "sansung", Description = "Samsung is the best", Status = 1 };

				_context.Products.AddRange( 

					new ProductModel { Name = "Macbook", Slug = "macbook", Description = "Macbook is the best", Image = "1.png", Category = macbook, Brand = apple, Price = 1234 },
					new ProductModel { Name = "Pc", Slug = "pc", Description = "PC is the best", Image = "1.png", Category = pc, Brand = samsung, Price = 1234 }


					);
				_context.SaveChanges();
			}
		}
	}
}

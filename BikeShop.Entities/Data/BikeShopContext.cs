using BikeShop.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Entities.Data
{
    public class BikeShopContext : DbContext
    {
        public BikeShopContext(DbContextOptions<BikeShopContext> options)
            : base(options)
        {
        }
        #region db properties 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        #endregion

        #region Seed data method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //validations using Fluent API
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerId)
                .HasColumnName("CustomerId");
            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .IsRequired();


            #region Data Seeding
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { CategoryId = 1, CategoryName = "Children Bike"},
                new Category { CategoryId = 2, CategoryName = "Road Bike"},
                new Category { CategoryId = 3, CategoryName = "Mountain Bike"},
                new Category { CategoryId = 4, CategoryName = "Electric Bike"}
                );
            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ProductId = 1, ProductName ="Bmax 4 wiler", ModelYear= 2020, Price= 1200, CategoryId = 1, BrandId = 1},
                new Product { ProductId = 2, ProductName = "RMB Max", ModelYear = 2018, Price = 2300, CategoryId = 2, BrandId = 2},
                new Product { ProductId = 3, ProductName = "Bmax 4 wiler", ModelYear = 2007, Price = 800, CategoryId = 3, BrandId = 3 },
                new Product { ProductId = 4, ProductName = "Max", ModelYear = 2020, Price = 1500, CategoryId = 4, BrandId = 4}
                );
            modelBuilder.Entity<Brand>()
                .HasData(
                new Brand { BrandID = 1, BrandName = "Max" },
                new Brand { BrandID = 2, BrandName = "RMB" },
                new Brand { BrandID = 3, BrandName = "Max" },
                new Brand { BrandID = 4, BrandName = "Big Max" }
                );
            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { CustomerId = 1, FirstName = "Rosey", LastName = "Boxa", ContactNumber= "012365478", Email="roseyboxa@gmail.com", Street="12 Cool str", City="Centurion", Province="Gauteng", Country="SA", PostalCode= "125"},
                new Customer { CustomerId = 2, FirstName = "Oozy", LastName = "Cheal", ContactNumber = "05123654", Email = "oozyCheal@gmail.com", Street = "11A Kerol str", City = "Bloemfontein", Province = "Free State", Country = "SA", PostalCode = "125"},
                new Customer { CustomerId = 3, FirstName = "Lulu", LastName = "Mini", ContactNumber = "012365478", Email = "luluMini@gmail.com", Street = "785 Mapel str", City = "Centurion", Province = "Gauteng", Country = "SA", PostalCode = "1235"},
                new Customer { CustomerId = 4, FirstName = "Roxy", LastName = "Ferero", ContactNumber = "012365478", Email = "roxyFerero@gmail.com", Street = "85 Ocean Breeze str", City = "Minlerton", Province = "Western Cape", Country = "SA", PostalCode = "001"}

                );
            modelBuilder.Entity<Store>()
                .HasData(
                new Store { StoreId= 1, StoreName ="Sandton Shop", Contacts=0123654, Email= "bikeSonton@bikeshop.co.za", Address="121 Lake street Sandton Gauteng", ProductId = 1},
                new Store { StoreId = 2, StoreName = "Cape Town Shop", Contacts = 0123654, Email = "bikeCapeTown@bikeshop.co.za", Address = "10 Ocean Blue Mall  CapeTown Western Cape", ProductId = 2},
                new Store { StoreId = 3, StoreName = "Bloemfontein Shop", Contacts = 0123654, Email = "bikeBloem@bikeshop.co.za", Address = "Rich street 10A Bloem FS", ProductId = 2}
                );
            modelBuilder.Entity<Order>()
                .HasData(
                new Order { OrderId = 1, OrderDate= DateTime.Parse("2020/12/15"), RequiredDate= DateTime.Parse("2021/01/01"), ShippedDate= DateTime.Parse("2020/12/28"),  StoreId = 1, CustomerId = 2},
                new Order { OrderId = 2, OrderDate = DateTime.Parse("2021/12/15"), RequiredDate = DateTime.Parse("2022/01/01"), ShippedDate = DateTime.Parse("2021/12/28"), StoreId = 2, CustomerId = 3 },
                new Order { OrderId = 3, OrderDate = DateTime.Parse("2020/12/15"), RequiredDate = DateTime.Parse("2021/01/01"), ShippedDate = DateTime.Parse("2020/12/28"), StoreId = 1, CustomerId = 4 },
                new Order { OrderId = 4, OrderDate = DateTime.Parse("2021/12/15"), RequiredDate = DateTime.Parse("2022/01/01"), ShippedDate = DateTime.Parse("2021/12/28"), StoreId = 2, CustomerId =2 }

                );
            #endregion 
        }
        #endregion
         

    }
}

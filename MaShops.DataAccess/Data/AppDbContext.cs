using MaShops.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaShops.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCart> ProductsCarts { get; set;}
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductReview> ProductsReviews { get; set; }
        public DbSet<ProductSave> ProductSaves { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreSave> StoreSaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Address>().HasData(
            //    new Address
            //    {
            //        Id = 1,
            //        AppartmentNo = 60,
            //        City = "Riyadh",
            //        Country = "Saudi Arabia",
            //        Street = "Tahlia Street",
            //        ZipCode = null,
            //    },
            //    new Address
            //    {
            //        Id = 2,
            //        AppartmentNo = 30,
            //        City = "Riyadh",
            //        Country = "Saudi Arabia",
            //        Street = "Al Sahafa Street",
            //        ZipCode = null,
            //    },
            //    new Address
            //    {
            //        Id = 3,
            //        AppartmentNo = 25,
            //        City = "Jeddah",
            //        Country = "Saudi Arabia",
            //        Street = "Hira Street",
            //        ZipCode = null,
            //    }
            //);

            //modelBuilder.Entity<Banner>().HasData(
            //    new Banner
            //    {
            //        Id = 1,
            //        PhotoURL = "/uploads/banner1.jpg",
            //        Status = true
            //    },
            //    new Banner
            //    {
            //        Id = 2,
            //        PhotoURL = "/uploads/banner2.jpg",
            //        Status = true
            //    },
            //    new Banner
            //    {
            //        Id = 3,
            //        PhotoURL = "/uploads/banner3.jpg",
            //        Status = false
            //    },
            //    new Banner
            //    {
            //        Id = 4,
            //        PhotoURL = "/uploads/banner4.jpg",
            //        Status = false
            //    },
            //    new Banner
            //    {
            //        Id = 5,
            //        PhotoURL = "/uploads/banner5.jpg",
            //        Status = true
            //    }
            //);

            //modelBuilder.Entity<Cart>().HasData(
            //    new Cart
            //    {
            //        Id = 1,
            //        CustomerId = 1
            //    },
            //    new Cart
            //    {
            //        Id = 2,
            //        CustomerId = 2
            //    },
            //    new Cart
            //    {
            //        Id = 3,
            //        CustomerId = 3
            //    }
            //);

            //modelBuilder.Entity<Category>().HasData(
            //    new Category
            //    {
            //        Id = 1,
            //        Name = "Food"
            //    },
            //    new Category
            //    {
            //        Id = 2,
            //        Name = "Electronics"
            //    }
            //);

            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        Id = 1,
            //        Name = "DIMSUMCO Sesame Peanut Ball (Vegetarian) – (12’s) 300g",
            //        MainPosterURL = "/uploads/prod-1-main-poster.png",
            //        OldPrice = null,
            //        NewPrice = 4.99,
            //        CategoryId = 1,
            //        StoreId = 1,
            //        InStock = 5,
            //        HTMLDescription = "<p>Rolled in sesame seeds, and fried until crispy on the outside, but still soft and chewy on the inside, DIMSUMCO Sesame Peanut Ball (Vegetarian) are actually an irresistible treat.</p><ul><li><b><i>1 pkt of 12 pieces of Sesame Peanut Ball (Vegetarian).</i></b></li><li><b><i>Halal Certified</i></b></li><li><b><i>300g</i></b></li></ul>"
            //    },
            //    new Product
            //    {
            //        Id = 2,
            //        Name = "ESR for iPad 9th Generation case(2021) Lightweight Hard Case,Auto Sleep/Wake, Ascend Series case for iPad 10.2 Inch, Lavender",
            //        MainPosterURL = "/uploads/prod-2-main-poster.png",
            //        OldPrice = 17.99,
            //        NewPrice = 11.99,
            //        CategoryId = 2,
            //        StoreId = 2,
            //        InStock = 7,
            //        HTMLDescription = "<ul> <li> Only compatible with iPad 9/8/7 (2021, 2020, 2019); Model numbers:A2602, A2604, A2603,A2605, A2270, A2428, A2429, A2430, A2197, A2200, A2198 </li> <li>Magnetic trifold stand supports both viewing and writing modes</li> <li>Instantly activate auto sleep/wake when you open or close the cover</li> <li>Front cover protects your screen from scratches while remaining slim</li> <li> Translucent matte back adds a colorful twist while leaving the logo visible </li> </ul>"
            //    },
            //    new Product
            //    {
            //        Id = 3,
            //        Name = "Logitech Keys-to-Go Super-Slim and Super-Light Bluetooth Keyboard for iPhone, iPad, Mac and Apple TV, Including iPad Air 5th Gen (2022) - Classic Blue",
            //        MainPosterURL = "/uploads/prod-3-main-poster.jpg",
            //        OldPrice = 42.99,
            //        NewPrice = 29.99,
            //        CategoryId = 2,
            //        StoreId = 3,
            //        InStock = 5,
            //        HTMLDescription = "<ul> <li> Keys-To-Go is a super-slim, super-light keyboard that you can keep with you through the day whether you’re working or learning from the backyard or back at the office. </li> <li> The sealed keyboard protects against crumbs, spills, and almost anything else you (or your kids) can throw at it, and wipes clean in seconds. </li> <li> Works with the screens you use most including iPhone, iPad, and Apple TV, and even comes with a convenient stand for your phone. </li> <li> Comfortable, soft keys type silently so you and the people around you can focus on working or learning without distractions. </li> <li> Full row of iOS shortcut keys provide one-tap access to popular functions like volume up/down, mute, media controls, and more. </li> <li> An easy one-time Bluetooth pairing provides a reliable connection between Keys-To-Go and your device. </li> <li> Type for up to 3 months without needing to recharge the battery so you can spend more time typing and less time wondering where you left that charging cable. </li> </ul>"
            //    }
            //);

            //modelBuilder.Entity<ProductCart>().HasData(
            //    new ProductCart
            //    {
            //        Id = 1,
            //        ProductId = 1,
            //        CartId = 1,
            //    },
            //    new ProductCart
            //    {
            //        Id = 2,
            //        ProductId = 2,
            //        CartId = 2,
            //    },
            //    new ProductCart
            //    {
            //        Id = 3,
            //        ProductId = 3,
            //        CartId = 3,
            //    }
            //);

            //modelBuilder.Entity<ProductPhoto>().HasData(
            //    new ProductPhoto
            //    {
            //        Id = 1,
            //        ProductId = 1,
            //        URL = "/uploads/prod1-photo1.jpg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 2,
            //        ProductId = 1,
            //        URL = "/uploads/prod1-photo2.jpeg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 3,
            //        ProductId = 1,
            //        URL = "/uploads/prod1-photo3.jpg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 4,
            //        ProductId = 2,
            //        URL = "/uploads/prod2-photo1.jpg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 5,
            //        ProductId = 2,
            //        URL = "/uploads/prod2-photo2.jpg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 6,
            //        ProductId = 2,
            //        URL = "/uploads/prod2-photo3.jpg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 7,
            //        ProductId = 3,
            //        URL = "/uploads/prod3-photo1.jpeg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 8,
            //        ProductId = 3,
            //        URL = "/uploads/prod3-photo2.jpg"
            //    },
            //    new ProductPhoto
            //    {
            //        Id = 9,
            //        ProductId = 3,
            //        URL = "/uploads/prod3-photo3.jpeg"
            //    }
            //);

            //modelBuilder.Entity<ProductReview>().HasData(
            //    new ProductReview
            //    {
            //        Id = 1,
            //        CustomerId = 1,
            //        Rating = 5,
            //        ProductId = 1,
            //        Comment = "Wow, this food product exceeded my expectations! The flavors are incredibly delicious and well-balanced. It's the perfect combination of sweet and savory. The texture is spot on, providing a delightful crunch with every bite. I highly recommend trying this. It has become my new favorite snack!",
            //        Date = DateTime.Today
            //    },
            //    new ProductReview
            //    {
            //        Id = 2,
            //        CustomerId = 2,
            //        Rating = 3,
            //        ProductId = 2,
            //        Comment = "I recently purchased the ESR for iPad and have mixed feelings about it. On the positive side, it offers decent protection for my iPad and fits well, providing a snug and secure fit. The design is sleek and visually appealing. However, I did encounter a few drawbacks. The stand functionality could be improved as it feels a bit flimsy and doesn't always hold the iPad at the desired angle. Additionally, I noticed that the case tends to attract fingerprints easily, requiring frequent cleaning. Overall, it's an average product that offers basic protection but could use some enhancements in terms of functionality and fingerprint resistance.",
            //        Date = DateTime.Today
            //    },
            //    new ProductReview
            //    {
            //        Id = 3,
            //        CustomerId = 3,
            //        Rating = 1,
            //        ProductId = 3,
            //        Comment = "The Logitech Keys-to-Go Bluetooth Keyboard for iPhone was a huge disappointment. Despite its sleek and slim design, the performance is severely lacking. The keys feel mushy and unresponsive, making typing a frustrating experience. Additionally, the Bluetooth connectivity is unreliable, frequently disconnecting and requiring constant reconnection. The battery life is abysmal, barely lasting a couple of hours before needing a recharge. It's incredibly disappointing to invest in a keyboard that falls so short in terms of usability and reliability. I would not recommend this product.",
            //        Date = DateTime.Today
            //    }
            //);

            //modelBuilder.Entity<ProductSave>().HasData(
            //    new ProductSave
            //    {
            //        Id = 1,
            //        ProductId = 1,
            //        UserId = 1,
            //        Date = DateTime.Today
            //    },
            //    new ProductSave
            //    {
            //        Id = 2,
            //        ProductId = 2,
            //        UserId = 2,
            //        Date = DateTime.Today
            //    },
            //    new ProductSave
            //    {
            //        Id = 3,
            //        ProductId = 3,
            //        UserId = 3,
            //        Date = DateTime.Today
            //    }
            //);

            //modelBuilder.Entity<Sale>().HasData(
            //    new Sale
            //    {
            //        Id = 1,
            //        CustomerId = 1,
            //        ProductId = 1,
            //        DateTime = DateTime.Today
            //    },
            //    new Sale
            //    {
            //        Id = 2,
            //        CustomerId = 2,
            //        ProductId = 2,
            //        DateTime = DateTime.Today
            //    },
            //    new Sale
            //    {
            //        Id = 3,
            //        CustomerId = 3,
            //        ProductId = 3,
            //        DateTime = DateTime.Today
            //    }                
            //);

            //modelBuilder.Entity<Store>().HasData(
            //    new Store
            //    {
            //        Id = 1,
            //        OwnerId = 4,
            //        Name = "Evergreen Emporium",
            //        PosterURL = "/uploads/store-1-poster.jpg",
            //        Status = true
            //    },
            //    new Store
            //    {
            //        Id = 2,
            //        OwnerId = 5,
            //        Name = "GizmoTech Hub",
            //        PosterURL = "/uploads/store-2-poster.png",
            //        Status = true
            //    },
            //    new Store
            //    {
            //        Id = 3,
            //        OwnerId = 6,
            //        Name = "iConnect Depot",
            //        PosterURL = "/uploads/store-3-poster.jpeg",
            //        Status = true
            //    }                
            //);

            //modelBuilder.Entity<StoreSave>().HasData(
            //    new StoreSave
            //    {
            //        Id = 1,
            //        StoreId = 1,
            //        UserId = 1,
            //        Date = DateTime.Today,
            //    },
            //    new StoreSave
            //    {
            //        Id = 2,
            //        StoreId = 2,
            //        UserId = 2,
            //        Date = DateTime.Today
            //    },
            //    new StoreSave
            //    {
            //        Id = 3,
            //        StoreId = 3,
            //        UserId = 3,
            //        Date = DateTime.Today
            //    }    
            //);

            ////modelBuilder.Entity<ApplicationUser>().HasData(
            ////    new ApplicationUser
            ////    {
            ////        Id = 1,
            ////        FirstName = "Mohammed",
            ////        SecondName = "Khalid",
            ////        ThirdName = "Omar",
            ////        LastName = "Hamza",
            ////        Username = "mohammedhamza",
            ////        EncPassword = "slSe@#VSs1532",
            ////        Email = "mohammedhamza@gmail.com",
            ////        PhoneNumber = "00966532071000",
            ////        Nationality = "Saudi Arabia",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 1,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 2,
            ////        FirstName = "Shaimaa",
            ////        SecondName = "Sameer",
            ////        ThirdName = "Osama",
            ////        LastName = "Salim",
            ////        Username = "shaimaasalim",
            ////        EncPassword = "slSe@#fSF3",
            ////        Email = "shaimaasalim@gmail.com",
            ////        PhoneNumber = "00966532071001",
            ////        Nationality = "Saudi Arabia",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 2,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 3,
            ////        FirstName = "Osama",
            ////        SecondName = "Hamza",
            ////        ThirdName = "Salim",
            ////        LastName = "Sameer",
            ////        Username = "osamasameer",
            ////        EncPassword = "@#$FSAF@#",
            ////        Email = "osamasameer@gmail.com",
            ////        PhoneNumber = "00966532071002",
            ////        Nationality = "Yemen",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 3,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 4,
            ////        FirstName = "Mohammed",
            ////        SecondName = "Khalid",
            ////        ThirdName = "Osama",
            ////        LastName = "Naser",
            ////        Username = "mohammednaser",
            ////        EncPassword = "sF3#$Gs%#ss",
            ////        Email = "mohammednaser@gmail.com",
            ////        PhoneNumber = "00966532071003",
            ////        Nationality = "Saudi Arabia",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 3,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 5,
            ////        FirstName = "Khalid",
            ////        SecondName = "Naser",
            ////        ThirdName = "Amer",
            ////        LastName = "Osama",
            ////        Username = "khalidamer",
            ////        EncPassword = "Sfe34%#2#5%",
            ////        Email = "khalidamer@gmail.com",
            ////        PhoneNumber = "00966532071004",
            ////        Nationality = "Yemen",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 2,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 6,
            ////        FirstName = "Mahmoud",
            ////        SecondName = "Khalid",
            ////        ThirdName = "Osama",
            ////        LastName = "Mansour",
            ////        Username = "mahmoudmansour",
            ////        EncPassword = "@#FsdE323#",
            ////        Email = "mahmoudmansour@gmail.com",
            ////        PhoneNumber = "00966532071005",
            ////        Nationality = "Yemen",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 1,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 7,
            ////        FirstName = "Abdullah",
            ////        SecondName = "Mansour",
            ////        ThirdName = "Mahmoud",
            ////        LastName = "Saleh",
            ////        Username = "abdullahsaleh",
            ////        EncPassword = "234SDFe3#$",
            ////        Email = "abdullahsaleh@gmail.com",
            ////        PhoneNumber = "00966532071006",
            ////        Nationality = "Yemen",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 2,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 8,
            ////        FirstName = "Hattan",
            ////        SecondName = "Mahmoud",
            ////        ThirdName = "Mansour",
            ////        LastName = "Faisal",
            ////        Username = "hattanfaisal",
            ////        EncPassword = "&%sdfSE323",
            ////        Email = "hattanfaisal@gmail.com",
            ////        PhoneNumber = "00966532071007",
            ////        Nationality = "Saudi Arabia",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 2,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 9,
            ////        FirstName = "Somayah",
            ////        SecondName = "Faisal",
            ////        ThirdName = "Mahmoud",
            ////        LastName = "Omar",
            ////        Username = "somayahomar",
            ////        EncPassword = "((^77456FDg3",
            ////        Email = "somayahomar@gmail.com",
            ////        PhoneNumber = "00966532071008",
            ////        Nationality = "Saudi Arabia",
            ////        BirthDate = new DateTime(2000, 1, 1),
            ////        AddressId = 3,
            ////        PhotoURL = null,
            ////        Status = true,
            ////    },
            ////    new ApplicationUser
            ////    {
            ////        Id = 10,
            ////        FirstName = "Mazen",
            ////        SecondName = "Ameen",
            ////        ThirdName = "Hamid",
            ////        LastName = "Salah",
            ////        Username = "masalah-tech",
            ////        EncPassword = "M@zen852",
            ////        Email = "masalah.tech@gmail.com",
            ////        PhoneNumber = "00967774806897",
            ////        Nationality = "Yemen",
            ////        BirthDate = new DateTime(2000, 12, 16),
            ////        AddressId = 1,
            ////        PhotoURL = "/uploads/mazen2.png",
            ////        Status = true,
            ////    }
            ////);

            // Change delete constraint from "Cascade" to "NoAction"
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }


            base.OnModelCreating(modelBuilder);
        }

    }
}

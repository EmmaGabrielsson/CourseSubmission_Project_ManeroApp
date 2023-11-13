using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Manero.Contexts;

public class DataContext : IdentityDbContext<UserEntity>
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    // Add tables below (eg. public DbSet<AdressEntity> Adresses { get; set; })
    public DbSet<AdressEntity> Adresses { get; set; }
    public DbSet<UserAdressEntity> UserAdresses { get; set; }
    public DbSet<PromocodeEntity> Promocodes { get; set; }
    public DbSet<UserPromocodeEntity> UserPromocodes { get; set; }
    public DbSet<PaymentMethodEntity> PaymentMethods { get; set; }
    public DbSet<UserPaymentMethodsEntity> UserPaymentMethods { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<SizeEntity> Sizes { get; set; }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ImageEntity> Images { get; set; }
    public DbSet<ProductImageEntity> ProductImages { get; set; }
    public DbSet<ProductReviewEntity> ProductReviews { get; set; }
    public DbSet<ProductVariantEntity> ProductVariants { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderRowEntity> OrderRows { get; set; }
    public DbSet<CheckoutEntity> CheckoutEntities { get; set; }
    public DbSet<StatusCodeEntity> StatusCodes { get; set; }


    // Insert/seed initial data into the tables, when database is created
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        string passwordHash = new PasswordHasher<UserEntity>().HashPassword(null!, "BytMig123!");


        // Add initial data to the AspNetUsers table
        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984",
                UserName = "annettehill",
                Email = "annette@example.com",
                NormalizedEmail = "ANNETTE@EXAMPLE.COM",
                NormalizedUserName = "ANNETTEHILL",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                PhoneNumber = "0704567890",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Annette",
                LastName = "Hill",
                ProfileImageUrl = "/images/profiles/annette-hill.jpg"
            },
            new UserEntity
            {
                Id = "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284",
                UserName = "cameronwilliamson",
                Email = "cameron@example.com",
                NormalizedEmail = "CAMERON@EXAMPLE.COM",
                NormalizedUserName = "CAMERONWILLIAMSON",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                PhoneNumber = "0705678901",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Cameron",
                LastName = "Williamson",
                ProfileImageUrl = "/images/profiles/cameron-williamson.jpg"
            },
            new UserEntity
            {
                Id = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d",
                UserName = "jacobjones",
                Email = "jacob@example.com",
                NormalizedEmail = "JACOB@EXAMPLE.COM",
                NormalizedUserName = "JACOBJONES",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                PhoneNumber = "0706789012",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Jacob",
                LastName = "Jones",
                ProfileImageUrl = "/images/profiles/jacob-jones.jpg"
            },
            new UserEntity
            {
                Id = "1f75883b-125b-49b9-a3f1-931b83d05199",
                UserName = "jennywilson",
                Email = "jenny@example.com",
                NormalizedEmail = "JENNY@EXAMPLE.COM",
                NormalizedUserName = "JENNYWILSON",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                PhoneNumber = "0707890123",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Jenny",
                LastName = "Wilson",
                ProfileImageUrl = "/images/profiles/jenny-wilson.jpg"
            },
            new UserEntity
            {
                Id = "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3",
                UserName = "marvinmckinney",
                Email = "marvin@example.com",
                NormalizedEmail = "MARVIN@EXAMPLE.COM",
                NormalizedUserName = "MARVINMCKINNEY",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                PhoneNumber = "0708901234",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Marvin",
                LastName = "McKinney",
                ProfileImageUrl = "/images/profiles/marvin-mckinney.jpg"
            },
            new UserEntity
            {
                Id = "3b21a87a-aa26-4c90-9a2d-4c81205a0721",
                UserName = "theresawebb",
                Email = "theresa@example.com",
                NormalizedEmail = "THERESA@EXAMPLE.COM",
                NormalizedUserName = "THERESAWEBB",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                PhoneNumber = "0709012345",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Theresa",
                LastName = "Webb",
                ProfileImageUrl = "/images/profiles/theresa-webb.jpg"
            });

        // Add initial data to the Adresses table
        modelBuilder.Entity<AdressEntity>().HasData(
            new AdressEntity { Id = 1, StreetName = "Tomtebodavägen 3A", PostalCode = "17165", City = "Solna" },
            new AdressEntity { Id = 2, StreetName = "Stenbackevägen 6", PostalCode = "70225", City = "Örebro" },
            new AdressEntity { Id = 3, StreetName = "Haga Östergata 12", PostalCode = "41301", City = "Göteborg" },
            new AdressEntity { Id = 4, StreetName = "Nässjögatan 10", PostalCode = "30248", City = "Halmstad" },
            new AdressEntity { Id = 5, StreetName = "Östra Förstadsgatan 46", PostalCode = "21212", City = "Malmö" },
            new AdressEntity { Id = 6, StreetName = "Södergatan 78", PostalCode = "25237", City = "Helsingborg" },
            new AdressEntity { Id = 7, StreetName = "Västra Kajen 8", PostalCode = "37431", City = "Karlshamn" },
            new AdressEntity { Id = 8, StreetName = "Barkgatan 6", PostalCode = "21422", City = "Malmö" },
            new AdressEntity { Id = 9, StreetName = "Adolf Fredriks Kyrkogata 2", PostalCode = "11137", City = "Stockholm" }
            );

        // Add initial data to the UserAdresses table
        modelBuilder.Entity<UserAdressEntity>().HasData(
            new UserAdressEntity { AdressId = 1, UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", Title = "Home" },
            new UserAdressEntity { AdressId = 1, UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", Title = "Home" },
            new UserAdressEntity { AdressId = 2, UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", Title = "Home" },
            new UserAdressEntity { AdressId = 2, UserId = "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", Title = "Home" },
            new UserAdressEntity { AdressId = 3, UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", Title = "Parents" },
            new UserAdressEntity { AdressId = 3, UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", Title = "Work" },
            new UserAdressEntity { AdressId = 3, UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", Title = "Home" },
            new UserAdressEntity { AdressId = 4, UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", Title = "Other" },
            new UserAdressEntity { AdressId = 4, UserId = "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", Title = "Work" },
            new UserAdressEntity { AdressId = 5, UserId = "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", Title = "Other" },
            new UserAdressEntity { AdressId = 5, UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", Title = "Other" },
            new UserAdressEntity { AdressId = 6, UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", Title = "Parents" },
            new UserAdressEntity { AdressId = 7, UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", Title = "Other" },
            new UserAdressEntity { AdressId = 7, UserId = "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", Title = "Parents" },
            new UserAdressEntity { AdressId = 8, UserId = "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3", Title = "Home" },
            new UserAdressEntity { AdressId = 9, UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", Title = "Work" }
            );

        // Add initial data to the Promocodes table
        modelBuilder.Entity<PromocodeEntity>().HasData(
            new PromocodeEntity { Id = "WIN5IQP658", Discount = 5, ImageUrl = "~/images/promocodes/5.png", Title = "Get 5% Off Your Purchase Today!", ValidUntilDate = new DateTime(2023, 11, 30) },
            new PromocodeEntity { Id = "APIK85WQRT", Discount = 10, ImageUrl = "~/images/promocodes/10.png", Title = "Enjoy a 10% Discount on Your Next Order!", ValidUntilDate = new DateTime(2023, 11, 25) },
            new PromocodeEntity { Id = "20DERL5LOT", Discount = 20, ImageUrl = "~/images/promocodes/20.png", Title = "Big Savings: Take 20% Off Your Purchase!", ValidUntilDate = new DateTime(2023, 12, 31) }
            );

        // Add initial data to the UserPromocodes table
        modelBuilder.Entity<UserPromocodeEntity>().HasData(
            new UserPromocodeEntity { UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", CodeId = "WIN5IQP658" },
            new UserPromocodeEntity { UserId = "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3", CodeId = "WIN5IQP658" },
            new UserPromocodeEntity { UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", CodeId = "APIK85WQRT" },
            new UserPromocodeEntity { UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", CodeId = "APIK85WQRT" },
            new UserPromocodeEntity { UserId = "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3", CodeId = "APIK85WQRT" },
            new UserPromocodeEntity { UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", CodeId = "20DERL5LOT" }
            );

        // Add initial data to the Categories table
        modelBuilder.Entity<CategoryEntity>().HasData(
            new CategoryEntity { Id = 1, CategoryName = "Men" },
            new CategoryEntity { Id = 2, CategoryName = "Women" },
            new CategoryEntity { Id = 3, CategoryName = "Kids" },
            new CategoryEntity { Id = 4, CategoryName = "Sport" },
            new CategoryEntity { Id = 5, CategoryName = "Accessories" },
            new CategoryEntity { Id = 6, CategoryName = "Dresses" },
            new CategoryEntity { Id = 7, CategoryName = "Shoes" },
            new CategoryEntity { Id = 8, CategoryName = "Pants" },
            new CategoryEntity { Id = 9, CategoryName = "T-shirt" },
            new CategoryEntity { Id = 10, CategoryName = "Bag" }
        );

        // Add initial data to the Tags table
        modelBuilder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, TagName = "sale" },
            new TagEntity { Id = 2, TagName = "new" },
            new TagEntity { Id = 3, TagName = "top" }
        );

        // Add initial data to the Sizes table
        modelBuilder.Entity<SizeEntity>().HasData(
            new SizeEntity { Id = 1, SizeName = "XS" },
            new SizeEntity { Id = 2, SizeName = "S" },
            new SizeEntity { Id = 3, SizeName = "M" },
            new SizeEntity { Id = 4, SizeName = "L" },
            new SizeEntity { Id = 5, SizeName = "XL" },
            new SizeEntity { Id = 6, SizeName = "XXL" },
            new SizeEntity { Id = 7, SizeName = "XXXL" },
            new SizeEntity { Id = 8, SizeName = "EU38" },
            new SizeEntity { Id = 9, SizeName = "EU39" },
            new SizeEntity { Id = 10, SizeName = "EU40" },
            new SizeEntity { Id = 11, SizeName = "EU41" },
            new SizeEntity { Id = 12, SizeName = "EU42" },
            new SizeEntity { Id = 13, SizeName = "EU43" },
            new SizeEntity { Id = 14, SizeName = "EU44" },
            new SizeEntity { Id = 15, SizeName = "EU45" },
            new SizeEntity { Id = 16, SizeName = "EU46" },
            new SizeEntity { Id = 17, SizeName = "0-1y" },
            new SizeEntity { Id = 18, SizeName = "1-2y" },
            new SizeEntity { Id = 19, SizeName = "2-4y" },
            new SizeEntity { Id = 20, SizeName = "4-6y" },
            new SizeEntity { Id = 21, SizeName = "6-9y" }
        );

        // Add initial data to Colors table
        modelBuilder.Entity<ColorEntity>().HasData(
            new ColorEntity { Id = 1, ColorName = "red", ColorCode = "#FF6262" },
            new ColorEntity { Id = 2, ColorName = "lightblue", ColorCode = "#63C7FF" },
            new ColorEntity { Id = 3, ColorName = "navyblue", ColorCode = "#323858" },
            new ColorEntity { Id = 4, ColorName = "black", ColorCode = "#111111" },
            new ColorEntity { Id = 5, ColorName = "beige", ColorCode = "#F8E7CD" },
            new ColorEntity { Id = 6, ColorName = "brown", ColorCode = "#82614b" },
            new ColorEntity { Id = 7, ColorName = "orange", ColorCode = "#ec7322" },
            new ColorEntity { Id = 8, ColorName = "lightgrey", ColorCode = "#c3c2c1" },
            new ColorEntity { Id = 9, ColorName = "ruby", ColorCode = "#900603" },
            new ColorEntity { Id = 10, ColorName = "yellow", ColorCode = "#edc729" },
            new ColorEntity { Id = 11, ColorName = "forestgreen", ColorCode = "#667a65" },
            new ColorEntity { Id = 12, ColorName = "white", ColorCode = "#ffffff" },
            new ColorEntity { Id = 13, ColorName = "lightpink", ColorCode = "#bb9195" },
            new ColorEntity { Id = 14, ColorName = "grey", ColorCode = "#75797c" }

        );

        // Add initial data to the Products table
        modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity { ArticleNumber = "HAT001", ProductName = "Stylish Hat for All Seasons", Description = "This versatile and fashionable hat is the perfect accessory to complete your look. Crafted with high-quality materials, it offers both style and protection from the elements. Whether you're heading out for a casual day or a special occasion, this hat will be your go-to choice.", Price = (decimal)19.99, Discount = (decimal?)16.99, },
            new ProductEntity { ArticleNumber = "JEANS002", ProductName = "Classic Denim Jeans for Every Wardrobe", Description = "Elevate your fashion game with these classic denim jeans. Tailored for comfort and durability, these jeans are a wardrobe essential for any occasion.", Price = (decimal)49.99, Discount = (decimal?)44.99 },
            new ProductEntity { ArticleNumber = "KIDHAT003", ProductName = "Cozy Kids' Warm Hat - Stay Toasty in Style", Description = "Keep your little ones warm and stylish with this adorable kids' warm hat. Crafted with love and care, it's perfect for colder days. Your child will be both snug and cute in this cozy accessory.", Price = (decimal)12.99, Discount = (decimal?)10.99 },
            new ProductEntity { ArticleNumber = "SNEAKERS005", ProductName = "Nike Sneakers - Step into Style and Comfort", Description = "Get ready to walk in style with these Nike sneakers. Designed for both fashion and performance, these shoes offer the best of both worlds. Elevate your footwear game with these iconic kicks.", Price = (decimal)79.99, Discount = (decimal?)74.99 },
            new ProductEntity { ArticleNumber = "OWLHAT007", ProductName = "Owl Hat for Kids - Cute and Cuddly Headwear", Description = "Your little one will adore this adorable owl hat. Designed to keep them warm and looking cute, it's the perfect accessory for your child. Let your kid show off their unique style with this charming hat.", Price = (decimal)14.99, Discount = (decimal?)9.99 },
            new ProductEntity { ArticleNumber = "BEACHSHOES016", ProductName = "Beach Shoes - Step into Paradise", Description = "Make a statement on the beach with these stylish and comfortable beach shoes. Crafted for sandy adventures, they provide the perfect blend of fashion and function.", Price = (decimal)8.99, Discount = (decimal?)3.49 },
            new ProductEntity { ArticleNumber = "SNEAKERS009", ProductName = "Sneakers - A Step in the Right Direction", Description = "These sneakers are your go-to choice for both style and comfort. Crafted with care, they are perfect for everyday wear. Whether you're running errands or going for a walk, these sneakers have got you covered.", Price = (decimal)59.99, Discount = (decimal?)50 },
            new ProductEntity { ArticleNumber = "KNITTED004", ProductName = "Knitted Shirt - Comfort and Elegance Combined", Description = "Embrace the perfect blend of comfort and style with this knitted shirt. Crafted with soft, breathable fabric, it's a versatile addition to your wardrobe. Ideal for a casual day out or dressing up for a special occasion.", Price = (decimal)34.99 },
            new ProductEntity { ArticleNumber = "KIDPANTS006", ProductName = "Orange Kids' Pants - Vibrant and Comfy Bottoms", Description = "These vibrant orange kids' pants are a delightful addition to your child's wardrobe. Designed with comfort in mind, they provide both style and ease of movement. Make your child stand out with this eye-catching piece.", Price = (decimal)29.99 },
            new ProductEntity { ArticleNumber = "HANDBAG008", ProductName = "Red Handbag - Elegance Meets Functionality", Description = "Elevate your style with this chic red handbag. Perfect for any occasion, this handbag combines elegance with functionality. Carry your essentials in style with this stunning accessory.", Price = (decimal)39.99 },
            new ProductEntity { ArticleNumber = "STRIPEDSHIRT010", ProductName = "Striped Shirt for Kids - Stylish and Playful", Description = "Dress your child in this playful and stylish striped shirt. Made with quality materials, it ensures both comfort and fashion for your little one. Ideal for any casual occasion.", Price = (decimal)19.99 },
            new ProductEntity { ArticleNumber = "SUMMERDRESS011", ProductName = "Summer Dress - Stay Cool and Elegant", Description = "Beat the heat in style with this stunning summer dress. Perfect for sunny days and special events, this dress is designed to keep you cool and looking elegant.", Price = (decimal)49.99 },
            new ProductEntity { ArticleNumber = "VANSSHOES012", ProductName = "Vans Canvas Shoes - Classic Comfort and Style", Description = "Step into the classic world of Vans with these canvas shoes. Known for their timeless appeal and comfort, these shoes are a must-have for any sneaker enthusiast.", Price = (decimal)89.99 },
            new ProductEntity { ArticleNumber = "KIDSBODYSUIT013", ProductName = "White Bodysuit for Kids - Pure Comfort and Style", Description = "Keep your child comfortable and stylish with this white bodysuit. Crafted with care, it's perfect for all-day wear. Your little one will look adorable in this classic piece.", Price = (decimal)8.99 },
            new ProductEntity { ArticleNumber = "WHITETEE014", ProductName = "White T-Shirt - The Wardrobe Essential ", Description = "This white t-shirt is a wardrobe essential that combines versatility and style. Whether you're dressing up or down, this t-shirt is a timeless choice.", Price = (decimal)9.99 },
            new ProductEntity { ArticleNumber = "MENSWHITETEE015", ProductName = "White T-Shirt for Men - Classic and Comfy", Description = "This classic white t-shirt for men offers both style and comfort. A versatile addition to your wardrobe, it's perfect for casual outings and everyday wear.", Price = (decimal)14.99 },
            new ProductEntity { ArticleNumber = "BEIGEPANTS017", ProductName = "Beige Pants - Timeless Elegance ", Description = "Elevate your style with these timeless beige pants. Crafted for comfort and sophistication, they are a versatile addition to your wardrobe.", Price = (decimal)39.99 },
            new ProductEntity { ArticleNumber = "BLACKSNEAKERS018", ProductName = "Black Sneakers - Bold and Versatile Footwear", Description = "Step out in style with these bold black sneakers. They are designed to enhance your fashion game while providing comfort. A must-have for sneaker enthusiasts.", Price = (decimal)69.99 },
            new ProductEntity { ArticleNumber = "BLACKTEE019", ProductName = "Black T-Shirt - The Classic Wardrobe Staple", Description = "This black t-shirt is a classic wardrobe staple that combines style and versatility. Whether you're dressing up or keeping it casual, this t-shirt is the perfect choice.", Price = (decimal)9.99 },
            new ProductEntity { ArticleNumber = "BLACKWARMHAT020", ProductName = "Black Warm Hat - Cozy and Fashionable", Description = "Stay warm and fashionable with this black warm hat. Crafted with soft materials, it's perfect for colder days. Add a touch of style to your winter wardrobe.", Price = (decimal)14.99 },
            new ProductEntity { ArticleNumber = "KIDBLUEDRESS021", ProductName = "Blue Dress for Kids - Playful and Elegant", Description = "Dress your child in this playful and elegant blue dress. Made with care, it's perfect for special occasions and casual outings. Your little one will shine in this lovely piece.", Price = (decimal)17.99 },
            new ProductEntity { ArticleNumber = "BROWNHANDBAG022", ProductName = "Brown Shoulder Handbag - Sophisticated and Practical", Description = "Elevate your style with this sophisticated brown shoulder handbag. Crafted for both fashion and functionality, it's the ideal accessory for any occasion.", Price = (decimal)38.99 },
            new ProductEntity { ArticleNumber = "CHECKEREDHANDBAG023", ProductName = "Checkered Handbag - Trendy and Chic", Description = "Add a touch of trendiness to your outfit with this checkered handbag. Perfect for elevating your style, it's designed to keep you chic and organized.", Price = (decimal)29.99 },
            new ProductEntity { ArticleNumber = "CHECKEREDKIDSDRESS024", ProductName = "Checkered Kids' Dress - Playful Patterns for Little Ones", Description = "Dress your child in this playful checkered dress. Crafted with love and care, it's perfect for your little one's adventures. Let them stand out with this unique piece.", Price = (decimal)24.99 },
            new ProductEntity { ArticleNumber = "COLORFULKIDSDRESS025", ProductName = "Colorful Kids' Dress - Vibrant and Charming", Description = "Dress your child in this vibrant and charming dress. Made with quality materials, it ensures both comfort and style for your little one. Ideal for any special occasion.", Price = (decimal)35.99 },
            new ProductEntity { ArticleNumber = "DENIMSHORTS026", ProductName = "Denim Shorts - Casual Comfort with a Stylish Twist", Description = "Stay comfortable and stylish with these denim shorts. Designed for ease of movement, they are the perfect choice for casual days.", Price = (decimal)24.99 },
            new ProductEntity { ArticleNumber = "GREENKIDSSHOES027", ProductName = "Green Shoes for Kids - Fun and Practical Footwear", Description = "Add a pop of color to your child's outfit with these fun and practical green shoes. Crafted for comfort and style, they're perfect for everyday adventures.", Price = (decimal)19.99 },
            new ProductEntity { ArticleNumber = "GREYWOMENSTEE028", ProductName = "Grey T-Shirt for Women - Effortless Elegance", Description = "This grey t-shirt for women offers both style and comfort. A versatile addition to your wardrobe, it's perfect for casual outings and everyday wear.", Price = (decimal)14.99 }
        );

        // Add initial data to the ProductTags table
        modelBuilder.Entity<ProductTagEntity>().HasData(
            new ProductTagEntity { ProductId = "HAT001", TagId = 1 },
            new ProductTagEntity { ProductId = "JEANS002", TagId = 1 },
            new ProductTagEntity { ProductId = "KIDHAT003", TagId = 1 },
            new ProductTagEntity { ProductId = "SNEAKERS005", TagId = 1 },
            new ProductTagEntity { ProductId = "OWLHAT007", TagId = 1 },
            new ProductTagEntity { ProductId = "BEACHSHOES016", TagId = 1 },
            new ProductTagEntity { ProductId = "SNEAKERS009", TagId = 1 },
            new ProductTagEntity { ProductId = "KNITTED004", TagId = 2 },
            new ProductTagEntity { ProductId = "KIDPANTS006", TagId = 2 },
            new ProductTagEntity { ProductId = "HANDBAG008", TagId = 3 },
            new ProductTagEntity { ProductId = "BEIGEPANTS017", TagId = 3 },
            new ProductTagEntity { ProductId = "CHECKEREDHANDBAG023", TagId = 2 },
            new ProductTagEntity { ProductId = "GREENKIDSSHOES027", TagId = 2 },
            new ProductTagEntity { ProductId = "GREYWOMENSTEE028", TagId = 3 }
        );

        // Add initial data to the ProductCategories table
        modelBuilder.Entity<ProductCategoryEntity>().HasData(
            new ProductCategoryEntity { ProductId = "HAT001", CategoryId = 5 },
            new ProductCategoryEntity { ProductId = "JEANS002", CategoryId = 8 },
            new ProductCategoryEntity { ProductId = "KIDHAT003", CategoryId = 5 },
            new ProductCategoryEntity { ProductId = "KIDHAT003", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "SNEAKERS005", CategoryId = 7 },
            new ProductCategoryEntity { ProductId = "SNEAKERS005", CategoryId = 1 },
            new ProductCategoryEntity { ProductId = "OWLHAT007", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "OWLHAT007", CategoryId = 5 },
            new ProductCategoryEntity { ProductId = "BEACHSHOES016", CategoryId = 7 },
            new ProductCategoryEntity { ProductId = "SNEAKERS009", CategoryId = 7 },
            new ProductCategoryEntity { ProductId = "SNEAKERS009", CategoryId = 4 },
            new ProductCategoryEntity { ProductId = "KNITTED004", CategoryId = 2 },
            new ProductCategoryEntity { ProductId = "KIDPANTS006", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "KIDPANTS006", CategoryId = 8 },
            new ProductCategoryEntity { ProductId = "HANDBAG008", CategoryId = 5 },
            new ProductCategoryEntity { ProductId = "HANDBAG008", CategoryId = 10 },
            new ProductCategoryEntity { ProductId = "STRIPEDSHIRT010", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "SUMMERDRESS011", CategoryId = 6 },
            new ProductCategoryEntity { ProductId = "SUMMERDRESS011", CategoryId = 2 },
            new ProductCategoryEntity { ProductId = "VANSSHOES012", CategoryId = 7 },
            new ProductCategoryEntity { ProductId = "KIDSBODYSUIT013", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "WHITETEE014", CategoryId = 9 },
            new ProductCategoryEntity { ProductId = "WHITETEE014", CategoryId = 2 },
            new ProductCategoryEntity { ProductId = "MENSWHITETEE015", CategoryId = 9 },
            new ProductCategoryEntity { ProductId = "MENSWHITETEE015", CategoryId = 1 },
            new ProductCategoryEntity { ProductId = "BEIGEPANTS017", CategoryId = 8 },
            new ProductCategoryEntity { ProductId = "BEIGEPANTS017", CategoryId = 2 },
            new ProductCategoryEntity { ProductId = "BLACKSNEAKERS018", CategoryId = 7 },
            new ProductCategoryEntity { ProductId = "BLACKSNEAKERS018", CategoryId = 4 },
            new ProductCategoryEntity { ProductId = "BLACKSNEAKERS018", CategoryId = 1 },
            new ProductCategoryEntity { ProductId = "BLACKTEE019", CategoryId = 9 },
            new ProductCategoryEntity { ProductId = "BLACKWARMHAT020", CategoryId = 5 },
            new ProductCategoryEntity { ProductId = "KIDBLUEDRESS021", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "KIDBLUEDRESS021", CategoryId = 6 },
            new ProductCategoryEntity { ProductId = "BROWNHANDBAG022", CategoryId = 5 },
            new ProductCategoryEntity { ProductId = "BROWNHANDBAG022", CategoryId = 10 },
            new ProductCategoryEntity { ProductId = "CHECKEREDHANDBAG023", CategoryId = 5 },
            new ProductCategoryEntity { ProductId = "CHECKEREDHANDBAG023", CategoryId = 10 },
            new ProductCategoryEntity { ProductId = "CHECKEREDKIDSDRESS024", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "CHECKEREDKIDSDRESS024", CategoryId = 6 },
            new ProductCategoryEntity { ProductId = "COLORFULKIDSDRESS025", CategoryId = 6 },
            new ProductCategoryEntity { ProductId = "COLORFULKIDSDRESS025", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "DENIMSHORTS026", CategoryId = 8 },
            new ProductCategoryEntity { ProductId = "DENIMSHORTS026", CategoryId = 2 },
            new ProductCategoryEntity { ProductId = "GREENKIDSSHOES027", CategoryId = 3 },
            new ProductCategoryEntity { ProductId = "GREENKIDSSHOES027", CategoryId = 7 },
            new ProductCategoryEntity { ProductId = "GREYWOMENSTEE028", CategoryId = 2 },
            new ProductCategoryEntity { ProductId = "GREYWOMENSTEE028", CategoryId = 9 }
        );

        // Add initial data to the Images table for products
        modelBuilder.Entity<ImageEntity>().HasData(
            new ImageEntity { Id = new Guid("521d06b5-d524-4a9e-bf99-4e3e4896790d"), ImageName = "beach shoes", ImageUrl = "/images/products/beach-shoes.jpg" },
            new ImageEntity { Id = new Guid("e80d078e-7405-4d04-8d85-90a8c3d1bfe7"), ImageName = "beige pants", ImageUrl = "/images/products/beige-pants.jpg" },
            new ImageEntity { Id = new Guid("8b58ee69-119b-4efc-9b80-92c78c6d6f1a"), ImageName = "black sneakers", ImageUrl = "/images/products/black-sneakers.jpg" },
            new ImageEntity { Id = new Guid("2fcf10b4-9a25-4c9b-a7c1-8a4c05a30fc6"), ImageName = "black t-shirt", ImageUrl = "/images/products/black-tshirt.jpg" },
            new ImageEntity { Id = new Guid("33d33f47-5b7b-4f29-98c6-c3e51edc1b0c"), ImageName = "black warm hat", ImageUrl = "/images/products/black-warm-hat.jpg" },
            new ImageEntity { Id = new Guid("b67f013c-87d9-42ef-8922-cdc0f0ee0075"), ImageName = "blue dress for kids", ImageUrl = "/images/products/blue-dress-kids.jpg" },
            new ImageEntity { Id = new Guid("74220f01-6d1f-4e24-ba98-3b01704aeb86"), ImageName = "brown shoulder handbag", ImageUrl = "/images/products/brown-shoulder-handbag.jpg" },
            new ImageEntity { Id = new Guid("d1b5b5f3-46ce-4a24-b86c-f79937df44b6"), ImageName = "checkered handbag", ImageUrl = "/images/products/checkered-handbag.jpg" },
            new ImageEntity { Id = new Guid("81b1a8e6-3211-487a-bab5-3c2825d108d7"), ImageName = "checkered dress for kids", ImageUrl = "/images/products/checkered-kidsdress.jpg" },
            new ImageEntity { Id = new Guid("3a37d8c5-5c36-4f68-a256-22d24ca88576"), ImageName = "colorful dress for kids", ImageUrl = "/images/products/colorful-kidsdress.jpg" },
            new ImageEntity { Id = new Guid("6c1321f8-7c17-4e63-938c-1b6eab1d83aa"), ImageName = "denim shorts", ImageUrl = "/images/products/denim-shorts.jpg" },
            new ImageEntity { Id = new Guid("f226f5d4-9c33-45c0-9531-d540ef06c168"), ImageName = "green shoes for kids", ImageUrl = "/images/products/green-shoes-kids.jpg" },
            new ImageEntity { Id = new Guid("8e0ee96a-773b-4be5-b907-e3da505f9ca4"), ImageName = "grey t-shirt for women", ImageUrl = "/images/products/grey-tshirt-women.jpg" },
            new ImageEntity { Id = new Guid("9b59db9a-7c0d-4880-9c60-5575ef1e5b85"), ImageName = "hat", ImageUrl = "/images/products/hat.jpg" },
            new ImageEntity { Id = new Guid("25c8d39e-cc8b-44b4-b3e4-76872d3f22b5"), ImageName = "jeans", ImageUrl = "/images/products/jeans.jpg" },
            new ImageEntity { Id = new Guid("d5a0abf6-34d5-4ed3-9c31-d73f25640b1d"), ImageName = "warm hat for kids", ImageUrl = "/images/products/kids-warm-hat.jpg" },
            new ImageEntity { Id = new Guid("b3a41c96-17d2-4649-9d8c-28448a29ce7c"), ImageName = "knitted shirt", ImageUrl = "/images/products/knitted-shirt.jpg" },
            new ImageEntity { Id = new Guid("8d0bd08c-9930-4e0c-8f15-88cde5d8490b"), ImageName = "nike sneakers", ImageUrl = "/images/products/nike-sneakers.jpg" },
            new ImageEntity { Id = new Guid("041e3b6f-1a52-44ca-9981-88c785c7c9e7"), ImageName = "orange pants for kids", ImageUrl = "/images/products/orange-kidspants.jpg" },
            new ImageEntity { Id = new Guid("f88c17b0-6111-4620-bc3a-284bca392176"), ImageName = "funny owl hat for kids", ImageUrl = "/images/products/owl-hat-kids.jpg" },
            new ImageEntity { Id = new Guid("4d4a7df3-6ed1-4ef0-8ea7-4fc92ea31de2"), ImageName = "red handbag", ImageUrl = "/images/products/red-handbag.jpg" },
            new ImageEntity { Id = new Guid("2e5247f9-3d88-48d0-8c47-9939e6e7eaa4"), ImageName = "sneakers", ImageUrl = "/images/products/sneakers.jpg" },
            new ImageEntity { Id = new Guid("98363f68-96c9-44ab-b3d3-e32ac25ea6ac"), ImageName = "striped shirt for kids", ImageUrl = "/images/products/striped-shirt-kids.jpg" },
            new ImageEntity { Id = new Guid("1b172b64-5462-4a20-bef3-8c6f04c62e87"), ImageName = "vans canvas shoes", ImageUrl = "/images/products/vans-canvas-shoes.jpg" },
            new ImageEntity { Id = new Guid("35acca4d-0ff1-4d9c-b5d3-6db3ca5c7c13"), ImageName = "white body for kids", ImageUrl = "/images/products/white-body-kids.jpg" },
            new ImageEntity { Id = new Guid("b03f66c5-6c50-487b-b620-37e9da2c2b33"), ImageName = "summer dress", ImageUrl = "/images/products/summer-dress.jpg" },
            new ImageEntity { Id = new Guid("02f03e93-4e4e-4c9d-8620-e8a40a986b36"), ImageName = "white t-shirt", ImageUrl = "/images/products/white-tshirt.jpg" },
            new ImageEntity { Id = new Guid("679f8dd5-9f41-4773-8f57-3bf99f06cd9b"), ImageName = "white t-shirt for men", ImageUrl = "/images/products/white-tshirt-men.jpg" },
            new ImageEntity { Id = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3"), ImageName = "extra product image", ImageUrl = "/images/products/extra-product-image.png" }
        );

        // Add initial data to the ProductImages table
        modelBuilder.Entity<ProductImageEntity>().HasData(
            new ProductImageEntity { ProductId = "BEACHSHOES016", ImageId = new Guid("521d06b5-d524-4a9e-bf99-4e3e4896790d") },
            new ProductImageEntity { ProductId = "BEIGEPANTS017", ImageId = new Guid("e80d078e-7405-4d04-8d85-90a8c3d1bfe7") },
            new ProductImageEntity { ProductId = "BLACKSNEAKERS018", ImageId = new Guid("8b58ee69-119b-4efc-9b80-92c78c6d6f1a") },
            new ProductImageEntity { ProductId = "BLACKTEE019", ImageId = new Guid("2fcf10b4-9a25-4c9b-a7c1-8a4c05a30fc6") },
            new ProductImageEntity { ProductId = "BLACKWARMHAT020", ImageId = new Guid("33d33f47-5b7b-4f29-98c6-c3e51edc1b0c") },
            new ProductImageEntity { ProductId = "KIDBLUEDRESS021", ImageId = new Guid("b67f013c-87d9-42ef-8922-cdc0f0ee0075") },
            new ProductImageEntity { ProductId = "BROWNHANDBAG022", ImageId = new Guid("74220f01-6d1f-4e24-ba98-3b01704aeb86") },
            new ProductImageEntity { ProductId = "CHECKEREDHANDBAG023", ImageId = new Guid("d1b5b5f3-46ce-4a24-b86c-f79937df44b6") },
            new ProductImageEntity { ProductId = "CHECKEREDKIDSDRESS024", ImageId = new Guid("81b1a8e6-3211-487a-bab5-3c2825d108d7") },
            new ProductImageEntity { ProductId = "COLORFULKIDSDRESS025", ImageId = new Guid("3a37d8c5-5c36-4f68-a256-22d24ca88576") },
            new ProductImageEntity { ProductId = "DENIMSHORTS026", ImageId = new Guid("6c1321f8-7c17-4e63-938c-1b6eab1d83aa") },
            new ProductImageEntity { ProductId = "GREENKIDSSHOES027", ImageId = new Guid("f226f5d4-9c33-45c0-9531-d540ef06c168") },
            new ProductImageEntity { ProductId = "GREYWOMENSTEE028", ImageId = new Guid("8e0ee96a-773b-4be5-b907-e3da505f9ca4") },
            new ProductImageEntity { ProductId = "HAT001", ImageId = new Guid("9b59db9a-7c0d-4880-9c60-5575ef1e5b85") },
            new ProductImageEntity { ProductId = "JEANS002", ImageId = new Guid("25c8d39e-cc8b-44b4-b3e4-76872d3f22b5") },
            new ProductImageEntity { ProductId = "KIDHAT003", ImageId = new Guid("d5a0abf6-34d5-4ed3-9c31-d73f25640b1d") },
            new ProductImageEntity { ProductId = "KNITTED004", ImageId = new Guid("b3a41c96-17d2-4649-9d8c-28448a29ce7c") },
            new ProductImageEntity { ProductId = "SNEAKERS005", ImageId = new Guid("8d0bd08c-9930-4e0c-8f15-88cde5d8490b") },
            new ProductImageEntity { ProductId = "KIDPANTS006", ImageId = new Guid("041e3b6f-1a52-44ca-9981-88c785c7c9e7") },
            new ProductImageEntity { ProductId = "OWLHAT007", ImageId = new Guid("f88c17b0-6111-4620-bc3a-284bca392176") },
            new ProductImageEntity { ProductId = "HANDBAG008", ImageId = new Guid("4d4a7df3-6ed1-4ef0-8ea7-4fc92ea31de2") },
            new ProductImageEntity { ProductId = "SNEAKERS009", ImageId = new Guid("2e5247f9-3d88-48d0-8c47-9939e6e7eaa4") },
            new ProductImageEntity { ProductId = "STRIPEDSHIRT010", ImageId = new Guid("98363f68-96c9-44ab-b3d3-e32ac25ea6ac") },
            new ProductImageEntity { ProductId = "VANSSHOES012", ImageId = new Guid("1b172b64-5462-4a20-bef3-8c6f04c62e87") },
            new ProductImageEntity { ProductId = "KIDSBODYSUIT013", ImageId = new Guid("35acca4d-0ff1-4d9c-b5d3-6db3ca5c7c13") },
            new ProductImageEntity { ProductId = "SUMMERDRESS011", ImageId = new Guid("b03f66c5-6c50-487b-b620-37e9da2c2b33") },
            new ProductImageEntity { ProductId = "WHITETEE014", ImageId = new Guid("02f03e93-4e4e-4c9d-8620-e8a40a986b36") },
            new ProductImageEntity { ProductId = "MENSWHITETEE015", ImageId = new Guid("679f8dd5-9f41-4773-8f57-3bf99f06cd9b") },


            // An extra product image on all products, to show functionality of multiple images on a product
            new ProductImageEntity { ProductId = "BEACHSHOES016", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "BEIGEPANTS017", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "BLACKSNEAKERS018", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "BLACKTEE019", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "BLACKWARMHAT020", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "KIDBLUEDRESS021", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "BROWNHANDBAG022", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "CHECKEREDHANDBAG023", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "CHECKEREDKIDSDRESS024", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "COLORFULKIDSDRESS025", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "DENIMSHORTS026", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "GREENKIDSSHOES027", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "GREYWOMENSTEE028", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "HAT001", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "JEANS002", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "KIDHAT003", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "KNITTED004", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "SNEAKERS005", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "KIDPANTS006", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "OWLHAT007", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "HANDBAG008", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "SNEAKERS009", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "STRIPEDSHIRT010", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "VANSSHOES012", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "KIDSBODYSUIT013", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "SUMMERDRESS011", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "WHITETEE014", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") },
            new ProductImageEntity { ProductId = "MENSWHITETEE015", ImageId = new Guid("9e1ef4b4-2b99-49e5-b1f3-483e18c650f3") }
        );

        // Add initial data to the ProductReviews table (note that not all products have reviews yet and it's intended to be that way)
        modelBuilder.Entity<ProductReviewEntity>().HasData(
            new ProductReviewEntity { Id = new Guid("a7ef79fb-4a19-46f3-8300-8b17a9715b0d"), Rating = 5, Comment = "This product is a true gem. The quality is exceptional, and it has quickly become a favorite in my wardrobe. The attention to detail in the craftsmanship is evident, and it's incredibly comfortable to wear. I can confidently say that I would recommend it to anyone seeking a versatile and high-quality addition to their collection. The value you get from this item is unmatched, making it a fantastic investment.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "BEIGEPANTS017" },
            new ProductReviewEntity { Id = new Guid("6d0a69eb-51a7-4c21-bba6-780de40bc3ca"), Rating = 5, Comment = "This item is fantastic!", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "BEIGEPANTS017" },
            new ProductReviewEntity { Id = new Guid("f7e0ecf2-0da4-49a2-980a-9b8a703b34cb"), Rating = 4, Comment = "These kids' clothes are perfect for playdates and parties. They are stylish and practical, allowing children to look their best while having fun. While they may have minor room for improvement, they're a solid choice.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "KIDBLUEDRESS021" },
            new ProductReviewEntity { Id = new Guid("0ce7d3f6-0c8e-46a2-8e70-7a9a86e2a00d"), Rating = 5, Comment = "Kids' fashion should be fun and functional, and these clothes deliver on both fronts. The designs are playful and appealing to children, while the quality ensures they last through playdates and adventures. A must-have for young fashionistas!", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "KIDBLUEDRESS021" },
            new ProductReviewEntity { Id = new Guid("e499542e-83e5-4a11-b1c3-184c3be4a8a4"), Rating = 5, Comment = "Shopping for kids' clothes can be a joy when you find items like these. The designs are adorable, and the durability is a big plus. These clothes can withstand the wear and tear of active little ones while keeping them looking stylish.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "KIDBLUEDRESS021" },
            new ProductReviewEntity { Id = new Guid("d78a5d59-3d22-4d24-9a72-9a0c5d64e962"), Rating = 2, Comment = "I had high hopes for these kids' clothes, but they fell short of my expectations. The quality is disappointing, and they didn't hold up well to regular use. I wouldn't recommend them.", UserId = "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", ProductArticleNumber = "KIDBLUEDRESS021" },
            new ProductReviewEntity { Id = new Guid("ccedf9cd-4fb4-4a07-98f6-853d165a85cd"), Rating = 4, Comment = "I recently bought a pair of green kids' shoes for my child, and they've proven to be a fun and practical choice. The green color is eye-catching and adds a playful touch to their outfits. These shoes are well-constructed and offer good support for little feet. They are suitable for both outdoor play and casual outings. While they're not perfect, they strike a good balance between style and functionality, making them a solid option for active kids.", UserId = "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3", ProductArticleNumber = "GREENKIDSSHOES027" },
            new ProductReviewEntity { Id = new Guid("e99881b5-90e6-4a15-91ec-2c1c3a685c0e"), Rating = 3, Comment = "They are rather average in terms of design and quality. The green color is nice, and they do serve their purpose as everyday shoes. However, they lack the standout features or exceptional comfort that I was hoping for. If you're looking for basic green shoes for your child, these might fit the bill, but don't expect anything extraordinary.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "GREENKIDSSHOES027" },
            new ProductReviewEntity { Id = new Guid("48c3f19f-2eeb-4e15-8f75-6d1e2dd408c9"), Rating = 5, Comment = "I couldn't be happier with my choice. The vibrant green color immediately caught my eye, and it's just as stylish in person. These shoes are not only fashionable but also incredibly comfortable for my little one to wear all day long. The quality is top-notch, and I appreciate the attention to detail in their design. These green shoes have quickly become a favorite in our child's wardrobe. I highly recommend them to parents looking for both style and comfort in kids' footwear.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "GREENKIDSSHOES027" },
            new ProductReviewEntity { Id = new Guid("2b17df60-c61d-4fb3-9f2b-27132d57d2d3"), Rating = 4, Comment = "These green kids' shoes are stylish and comfy", UserId = "8c5b75a1-6c17-4c7b-a5d7-562eaf1c3284", ProductArticleNumber = "GREENKIDSSHOES027" },
            new ProductReviewEntity { Id = new Guid("7a9a4502-3f42-4c0e-95e3-774fe9d1a96c"), Rating = 3, Comment = "Overall, this product is good. It serves its purpose and offers good value for the price.", UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", ProductArticleNumber = "GREENKIDSSHOES027" },
            new ProductReviewEntity { Id = new Guid("0ad7551d-9a60-43ce-b475-7a19e0e1d18a"), Rating = 4, Comment = "This product is dependable and stylish. It fulfills its purpose effectively and features an appealing design. While it's not without minor flaws, it's a solid choice for those seeking reliability and style.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "BROWNHANDBAG022" },
            new ProductReviewEntity { Id = new Guid("d7d8b2ef-e7dd-45c5-9a77-9d5695d2b6f1"), Rating = 5, Comment = "I highly recommend this product. It's a standout choice and is worth every penny.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "JEANS002" },
            new ProductReviewEntity { Id = new Guid("e4f2f0ff-85a6-40c9-8c14-962d2a28ff75"), Rating = 2, Comment = "I'm not impressed. It didn't live up to my expectations, and there were some issues.", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "JEANS002" },
            new ProductReviewEntity { Id = new Guid("f4242cc7-7dd3-4b7d-91f3-85d6cfe24222"), Rating = 4, Comment = "It's a solid pick. It's reliable and serves its purpose effectively. There are some areas for improvement, but it's a good choice.", UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", ProductArticleNumber = "JEANS002" },
            new ProductReviewEntity { Id = new Guid("18a2a186-631f-475a-8d83-190c16f9c525"), Rating = 4, Comment = "I'm very impressed with this purchase. It exceeded my expectations.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "JEANS002" },
            new ProductReviewEntity { Id = new Guid("34f7c62e-d7d9-4bd3-98ad-8c6c3b16839f"), Rating = 3, Comment = "The quality is decent for the price. It serves its purpose.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "VANSSHOES012" },
            new ProductReviewEntity { Id = new Guid("631a44dd-7f0e-44e9-9fa6-08e2c4ee8ecb"), Rating = 5, Comment = "This product offers great value. It's a must-buy.", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "VANSSHOES012" },
            new ProductReviewEntity { Id = new Guid("15d775e1-6ed2-487a-81d4-d7ca9e6f4e9a"), Rating = 4, Comment = "A good product overall. It's worth considering", UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", ProductArticleNumber = "SNEAKERS009" },
            new ProductReviewEntity { Id = new Guid("a15e3c6a-691d-443e-82b6-cffce1dc3dc3"), Rating = 3, Comment = "This is an average purchase. It's neither exceptional nor disappointing.", UserId = "7d75c0ea-3c5e-443b-b29b-6c3e9ecbc2d3", ProductArticleNumber = "MENSWHITETEE015" },
            new ProductReviewEntity { Id = new Guid("4f8c9c3c-ae0d-44e9-82c9-899cead3e8c8"), Rating = 4, Comment = "I'm delighted with this purchase. It's a great product considering the price. The quality is good, and it serves its intended purpose well. While there's room for improvement, it's still a solid choice for those looking for a reliable and budget-friendly option.", UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", ProductArticleNumber = "MENSWHITETEE015" },
            new ProductReviewEntity { Id = new Guid("c7b8c9ae-2a8f-4c11-9f5d-8f95e9728ff1"), Rating = 2, Comment = "I'm not satisfied with this item. It didn't meet my expectations, and I've encountered several problems. The quality is disappointing, and I would caution against purchasing it.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "DENIMSHORTS026" },
            new ProductReviewEntity { Id = new Guid("b2e4f8ec-1e88-47b3-9f43-850b9ad37e1f"), Rating = 4, Comment = "I'm delighted with this purchase. It's a great product considering the price. The quality is good, and it serves its intended purpose well. While there's room for improvement, it's still a solid choice for those looking for a reliable and budget-friendly option.", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "DENIMSHORTS026" },
            new ProductReviewEntity { Id = new Guid("7cc7cf7a-e8a7-46ef-9e17-c4ac3b74a9bc"), Rating = 5, Comment = "This product is absolutely amazing. The quality, design, and overall performance exceed all expectations. It's a versatile addition to any collection and offers exceptional value for its price. I highly recommend it to anyone seeking a top-tier product.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "STRIPEDSHIRT010" },
            new ProductReviewEntity { Id = new Guid("6e6a4be1-0b08-4c18-ae90-3ec1d2cf30cb"), Rating = 4, Comment = "A good product overall. It's worth considering.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "STRIPEDSHIRT010" },
            new ProductReviewEntity { Id = new Guid("6f9a4c8f-6cc3-49db-9a79-c6fe3a29fc3d"), Rating = 3, Comment = "This is an average purchase. It's neither exceptional nor disappointing.", UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", ProductArticleNumber = "STRIPEDSHIRT010" },
            new ProductReviewEntity { Id = new Guid("f3ecfaec-8eb5-4e60-af1b-7f2a4d3d08ca"), Rating = 3, Comment = "This product falls in the 'acceptable' range for me. It serves its purpose decently, but I believe there is room for improvement. The quality is average, and while it gets the job done, it doesn't particularly stand out. If you're seeking a basic, budget-friendly option, this might work for you. However, I'd be more inclined to explore other alternatives for a more satisfactory experience.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "WHITETEE014" },
            new ProductReviewEntity { Id = new Guid("218e882b-ae56-4a9a-8fc0-1f5da0f7f2c5"), Rating = 4, Comment = "Overall, this product is good. It serves its purpose and offers good value for the price.", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "BLACKWARMHAT020" },
            new ProductReviewEntity { Id = new Guid("4a9c16d5-3e61-4a07-bffe-c24f21a2aabb"), Rating = 4, Comment = "It's a solid pick. It's reliable and serves its purpose effectively. There are some areas for improvement, but it's a good choice.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "BLACKWARMHAT020" },
            new ProductReviewEntity { Id = new Guid("7b9d3e7c-c4ed-44d2-8dcd-d5a0c3b4f7ed"), Rating = 5, Comment = "This product is simply outstanding.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "SUMMERDRESS011" },
            new ProductReviewEntity { Id = new Guid("0e9eddba-88db-480f-8a12-2e8ebaf9bde8"), Rating = 3, Comment = "This product is rather ordinary. It doesn't have any standout features but gets the job done. The quality is average, and it's suitable for everyday use.", UserId = "0a43d58a-cb53-4c60-b4f3-8b88e84dd26d", ProductArticleNumber = "KIDSBODYSUIT013" },
            new ProductReviewEntity { Id = new Guid("3bce2f0d-1d42-4b11-af2a-8d59ac6b87f7"), Rating = 4, Comment = "This product is reliable and affordable. It's a good choice for those seeking a budget-friendly option.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "KIDSBODYSUIT013" },
            new ProductReviewEntity { Id = new Guid("c2b1bf4a-8cc4-4a59-9361-710c4eef7b45"), Rating = 4, Comment = "These kids' clothes strike a great balance between affordability and trendiness. They allow your children to stay fashionable without breaking the bank. The quality is good, making them suitable for everyday wear.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "KIDSBODYSUIT013" },
            new ProductReviewEntity { Id = new Guid("1cb6f65d-1f22-4c14-9c6b-3fc7a4f9b8ed"), Rating = 5, Comment = "I wholeheartedly recommend this product. It's an outstanding addition to any wardrobe. The craftsmanship is top-notch, and it's incredibly comfortable to wear, even for extended periods. The attention to detail in the design is commendable, and the versatility of this item is unparalleled. It's worth every penny, and the value you receive far exceeds the price. If you're searching for a product that consistently delivers excellence, look no further.", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "HANDBAG008" },
            new ProductReviewEntity { Id = new Guid("0c2bd56c-2ec9-4a27-8b25-c51ca5e6f6db"), Rating = 5, Comment = "Highly recommended! It's a worthwhile addition to your collection.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "HANDBAG008" },
            new ProductReviewEntity { Id = new Guid("3b4b3c38-5eb6-4e36-8a23-1bba8ed82f3d"), Rating = 5, Comment = "Kids' fashion should be fun and functional, and these clothes deliver on both fronts. The designs are playful and appealing to children, while the quality ensures they last through playdates and adventures. A must-have for young fashionistas!", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "OWLHAT007" },
            new ProductReviewEntity { Id = new Guid("b20cd82f-8f11-4a13-b0fc-d71dd9f4b9eb"), Rating = 4, Comment = "This product is dependable and stylish. It fulfills its purpose effectively and features an appealing design. While it's not without minor flaws, it's a solid choice for those seeking reliability and style.", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "HAT001" },
            new ProductReviewEntity { Id = new Guid("7d8c89db-4ea3-4e3f-8a47-3e2ea1b6e4bc"), Rating = 4, Comment = "These kids' clothes are perfect for playdates and parties. They are stylish and practical, allowing children to look their best while having fun. While they may have minor room for improvement, they're a solid choice.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "KIDPANTS006" },
            new ProductReviewEntity { Id = new Guid("d3dd10e3-8f3d-49ea-92ec-8f7cd2b5b0cd"), Rating = 5, Comment = "Highly recommended! It's a worthwhile addition to your collection.", UserId = "3b21a87a-aa26-4c90-9a2d-4c81205a0721", ProductArticleNumber = "GREYWOMENSTEE028" },
            new ProductReviewEntity { Id = new Guid("e8cf3f5c-1c7d-45ed-9ea6-cac3c4db07e1"), Rating = 5, Comment = "This product is a true gem. The quality is exceptional, and it has quickly become a favorite in my wardrobe. The attention to detail in the craftsmanship is evident, and it's incredibly comfortable to wear. I can confidently say that I would recommend it to anyone seeking a versatile and high-quality addition to their collection. The value you get from this item is unmatched, making it a fantastic investment.", UserId = "1f75883b-125b-49b9-a3f1-931b83d05199", ProductArticleNumber = "GREYWOMENSTEE028" },
            new ProductReviewEntity { Id = new Guid("1edf8dc8-07ea-41e4-8c1f-8a1f7ff0e0d7"), Rating = 5, Comment = "This product offers great value. It's a must-buy.", UserId = "f1a46d0e-07a1-4e31-8cc3-4f2e28e4f984", ProductArticleNumber = "GREYWOMENSTEE028" }
        );

        // Add initial data to the ProductVariants table
        modelBuilder.Entity<ProductVariantEntity>().HasData(
            new ProductVariantEntity { Id = new Guid("834a820f-0b4b-49b3-a05c-1e7c131c5883"), ProductArticleNumber = "HAT001", Quantity = 5, ColorId = 5, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("29c17a1a-3a27-4e1d-8a0e-9674d7e5f8d2"), ProductArticleNumber = "JEANS002", Quantity = 2, ColorId = 4, SizeId = 1 },
            new ProductVariantEntity { Id = new Guid("6d6f7dbd-8d94-43bf-a56e-4a6e4d9c7f9c"), ProductArticleNumber = "JEANS002", Quantity = 2, ColorId = 3, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("48c1b5e8-6a91-478d-9c0d-85f6946c6b33"), ProductArticleNumber = "JEANS002", Quantity = 2, ColorId = 4, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("f5d131ab-9353-421c-9e25-19e9c7d9d3c1"), ProductArticleNumber = "JEANS002", Quantity = 2, ColorId = 3, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("7080b9b1-6f92-4ee1-8a57-0329a226d0f7"), ProductArticleNumber = "JEANS002", Quantity = 2, ColorId = 3, SizeId = 5 },
            new ProductVariantEntity { Id = new Guid("72e2ff20-0ea6-4e2a-9c4c-e5e1f1692e5a"), ProductArticleNumber = "KIDHAT003", Quantity = 9, ColorId = 4, SizeId = 19 },
            new ProductVariantEntity { Id = new Guid("e2b91a7a-0e02-4f18-a6c4-5ef42491b4ca"), ProductArticleNumber = "KNITTED004", Quantity = 2, ColorId = 6, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("347f12a5-d8b1-4565-8c6d-0a5c8edc2c26"), ProductArticleNumber = "KNITTED004", Quantity = 5, ColorId = 6, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("5640a6f3-4312-4a2f-aa8e-f5f17a01e262"), ProductArticleNumber = "KNITTED004", Quantity = 1, ColorId = 6, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("c3430e76-6df9-4c9d-8d8b-655e22db6f53"), ProductArticleNumber = "SNEAKERS005", Quantity = 2, ColorId = 2, SizeId = 11 },
            new ProductVariantEntity { Id = new Guid("0a83d9c2-67c5-4432-9e8d-ee02a8fb3bf0"), ProductArticleNumber = "SNEAKERS005", Quantity = 2, ColorId = 2, SizeId = 12 },
            new ProductVariantEntity { Id = new Guid("d4c1815f-42e1-47c2-9c4b-ff5c22771f0e"), ProductArticleNumber = "SNEAKERS005", Quantity = 2, ColorId = 2, SizeId = 13 },
            new ProductVariantEntity { Id = new Guid("1d21d5db-0b07-490e-a2cf-9a1c8f3bf50f"), ProductArticleNumber = "SNEAKERS005", Quantity = 2, ColorId = 2, SizeId = 14 },
            new ProductVariantEntity { Id = new Guid("943b4ff9-4b16-42ab-8d63-3ddcc741c73e"), ProductArticleNumber = "SNEAKERS005", Quantity = 2, ColorId = 2, SizeId = 15 },
            new ProductVariantEntity { Id = new Guid("81d22c44-12e5-4e79-9f2b-13a63e1e7601"), ProductArticleNumber = "KIDPANTS006", Quantity = 1, ColorId = 7, SizeId = 19 },
            new ProductVariantEntity { Id = new Guid("6f8f3a5e-00a4-4c7b-8dd3-7efbb3a6f99e"), ProductArticleNumber = "KIDPANTS006", Quantity = 2, ColorId = 7, SizeId = 20 },
            new ProductVariantEntity { Id = new Guid("27b94599-398f-48f6-935c-8ebf181fcbbd"), ProductArticleNumber = "KIDPANTS006", Quantity = 4, ColorId = 7, SizeId = 21 },
            new ProductVariantEntity { Id = new Guid("39246b6e-433b-4571-8f3a-49a2b8c3dace"), ProductArticleNumber = "OWLHAT007", Quantity = 2, ColorId = 8, SizeId = 18 },
            new ProductVariantEntity { Id = new Guid("e82c1f57-656b-4bde-92a6-0f4151a9e6e2"), ProductArticleNumber = "OWLHAT007", Quantity = 2, ColorId = 8, SizeId = 19 },
            new ProductVariantEntity { Id = new Guid("9c31d8ed-463e-4c76-8a2c-c99fc8219fb1"), ProductArticleNumber = "HANDBAG008", Quantity = 3, ColorId = 9, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("4f9d61a2-927d-4901-bb6e-c4e2bf20d87b"), ProductArticleNumber = "SNEAKERS009", Quantity = 3, ColorId = 10, SizeId = 10 },
            new ProductVariantEntity { Id = new Guid("e9f23d6a-fdcd-44f9-a163-35a67b1d9905"), ProductArticleNumber = "SNEAKERS009", Quantity = 2, ColorId = 10, SizeId = 13 },
            new ProductVariantEntity { Id = new Guid("6e427f7d-982e-4f3b-ba79-5d0f17f73dfc"), ProductArticleNumber = "SNEAKERS009", Quantity = 2, ColorId = 10, SizeId = 14 },
            new ProductVariantEntity { Id = new Guid("cfb38a58-792e-45b2-8b1c-8e6317e512ca"), ProductArticleNumber = "STRIPEDSHIRT010", Quantity = 2, ColorId = 9, SizeId = 18 },
            new ProductVariantEntity { Id = new Guid("a75c4a16-5a16-457f-8e5a-77c6e9b309cb"), ProductArticleNumber = "STRIPEDSHIRT010", Quantity = 5, ColorId = 9, SizeId = 19 },
            new ProductVariantEntity { Id = new Guid("4a5bd9c6-6b89-45ce-a8e5-69dfec2d2a1f"), ProductArticleNumber = "STRIPEDSHIRT010", Quantity = 1, ColorId = 9, SizeId = 21 },
            new ProductVariantEntity { Id = new Guid("2a8e03c1-7252-45f9-9f5c-56ab9bf3c11b"), ProductArticleNumber = "SUMMERDRESS011", Quantity = 5, ColorId = 10, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("d3b7b08d-1c65-4d01-8e9a-69ac6d977972"), ProductArticleNumber = "SUMMERDRESS011", Quantity = 3, ColorId = 10, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("51fb2941-879a-4ea6-a7d2-0cbac775e636"), ProductArticleNumber = "SUMMERDRESS011", Quantity = 4, ColorId = 10, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("f9d1d88f-864a-4d19-a91d-8a4a4e2d34e6"), ProductArticleNumber = "SUMMERDRESS011", Quantity = 2, ColorId = 10, SizeId = 5 },
            new ProductVariantEntity { Id = new Guid("0f251c6c-02ce-4b97-a352-5692d23cc8e0"), ProductArticleNumber = "VANSSHOES012", Quantity = 6, ColorId = 10, SizeId = 8 },
            new ProductVariantEntity { Id = new Guid("4e2f3d45-6210-4c84-ae22-83a7454697ea"), ProductArticleNumber = "VANSSHOES012", Quantity = 4, ColorId = 10, SizeId = 9 },
            new ProductVariantEntity { Id = new Guid("791cb653-7e36-47b1-8a19-eb9cfaf0e84b"), ProductArticleNumber = "KIDSBODYSUIT013", Quantity = 2, ColorId = 12, SizeId = 17 },
            new ProductVariantEntity { Id = new Guid("8e548b7f-6a08-432d-b9b5-5c8b7fc2da59"), ProductArticleNumber = "KIDSBODYSUIT013", Quantity = 8, ColorId = 12, SizeId = 18 },
            new ProductVariantEntity { Id = new Guid("7b4d8a99-3b8e-47c7-89d1-e01a7c19d5e4"), ProductArticleNumber = "WHITETEE014", Quantity = 4, ColorId = 12, SizeId = 1 },
            new ProductVariantEntity { Id = new Guid("3b8da2e1-964b-4ff2-aa65-4f67b69de2b0"), ProductArticleNumber = "WHITETEE014", Quantity = 2, ColorId = 12, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("16c9f4d8-9c41-4a02-9e78-dfe328efb6fc"), ProductArticleNumber = "WHITETEE014", Quantity = 5, ColorId = 12, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("45ed8f8d-c5e3-4623-ba85-d3a8ecdbf78c"), ProductArticleNumber = "WHITETEE014", Quantity = 3, ColorId = 12, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("8a79e5a1-621c-4f0e-b3d9-4c4f6e67f52e"), ProductArticleNumber = "WHITETEE014", Quantity = 1, ColorId = 12, SizeId = 5 },
            new ProductVariantEntity { Id = new Guid("a6d9c3f8-9c25-4b79-a76d-2f09a8c6f71e"), ProductArticleNumber = "WHITETEE014", Quantity = 2, ColorId = 12, SizeId = 6 },
            new ProductVariantEntity { Id = new Guid("0e83f6a7-97c1-4b4a-8d0a-10b8f9d2d1af"), ProductArticleNumber = "MENSWHITETEE015", Quantity = 2, ColorId = 12, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("d3c2f9b4-0e6a-42a3-9dfe-8f8ea1c8b3f2"), ProductArticleNumber = "MENSWHITETEE015", Quantity = 6, ColorId = 12, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("9b51f7e6-49d0-40e5-bc27-2c8d2efc5f01"), ProductArticleNumber = "MENSWHITETEE015", Quantity = 3, ColorId = 12, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("7e21c4d9-8ca5-464e-9b23-4a7e3c6d8d59"), ProductArticleNumber = "MENSWHITETEE015", Quantity = 5, ColorId = 12, SizeId = 5 },
            new ProductVariantEntity { Id = new Guid("84f7cde0-7b9e-4f17-af2a-d0d0ef3a7d9c"), ProductArticleNumber = "MENSWHITETEE015", Quantity = 1, ColorId = 12, SizeId = 6 },
            new ProductVariantEntity { Id = new Guid("1c3bd0e2-8b7f-4c58-9f0e-7e5e0cf19fb1"), ProductArticleNumber = "BEACHSHOES016", Quantity = 5, ColorId = 10, SizeId = 8 },
            new ProductVariantEntity { Id = new Guid("65b9c2f0-413a-4f98-9f92-ef2a7c2b1c84"), ProductArticleNumber = "BEACHSHOES016", Quantity = 2, ColorId = 10, SizeId = 9 },
            new ProductVariantEntity { Id = new Guid("e5a4d6c1-7c8d-44c9-81a4-8b27f0e3a45d"), ProductArticleNumber = "BEACHSHOES016", Quantity = 3, ColorId = 10, SizeId = 11 },
            new ProductVariantEntity { Id = new Guid("4b18d5e7-9e32-4a0b-a8a2-efdc7f3d4b2e"), ProductArticleNumber = "BEIGEPANTS017", Quantity = 2, ColorId = 5, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("728c3e5b-9d4f-4bf1-8c87-6b4b6a7a3c91"), ProductArticleNumber = "BEIGEPANTS017", Quantity = 1, ColorId = 5, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("43f8e1c0-6d21-4cda-9e7c-2c6a9bf7a8f5"), ProductArticleNumber = "BEIGEPANTS017", Quantity = 1, ColorId = 5, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("10b5e2c4-7f96-46a2-8cfa-5d85a6d0e4f2"), ProductArticleNumber = "BLACKSNEAKERS018", Quantity = 1, ColorId = 4, SizeId = 10 },
            new ProductVariantEntity { Id = new Guid("6a4d3f0e-3d7b-4bdc-9a1a-3a9e6d0f4e1b"), ProductArticleNumber = "BLACKSNEAKERS018", Quantity = 6, ColorId = 4, SizeId = 12 },
            new ProductVariantEntity { Id = new Guid("9e0f7ca2-4a1b-41d5-ae9c-8bca0f8d39f2"), ProductArticleNumber = "BLACKSNEAKERS018", Quantity = 3, ColorId = 4, SizeId = 13 },
            new ProductVariantEntity { Id = new Guid("81d2f5a9-48c1-4a86-a79b-d39bf4c8d5e6"), ProductArticleNumber = "BLACKTEE019", Quantity = 4, ColorId = 4, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("2d8c4f3a-4a7d-42b8-8e0f-1e5b7c6d0f4a"), ProductArticleNumber = "BLACKTEE019", Quantity = 3, ColorId = 4, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("7b6f2d8c-0a9e-4bf5-8c7e-6e8c4b9d2a8e"), ProductArticleNumber = "BLACKTEE019", Quantity = 2, ColorId = 4, SizeId = 6 },
            new ProductVariantEntity { Id = new Guid("49b8e2c1-7a2d-4b89-8f1e-d6b7f0c2e3a4"), ProductArticleNumber = "BLACKWARMHAT020", Quantity = 4, ColorId = 4, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("a4c9d1f7-0b7e-4a23-9e8f-8d7e1c5b3f0d"), ProductArticleNumber = "BLACKWARMHAT020", Quantity = 1, ColorId = 4, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("6d8b3f2a-4f6e-49c1-a7d0-8f5e2a9c1b7d"), ProductArticleNumber = "KIDBLUEDRESS021", Quantity = 2, ColorId = 3, SizeId = 19 },
            new ProductVariantEntity { Id = new Guid("e1d4b7c0-8c2a-43f5-b9d2-7f6e8d3a1c5b"), ProductArticleNumber = "KIDBLUEDRESS021", Quantity = 3, ColorId = 3, SizeId = 20 },
            new ProductVariantEntity { Id = new Guid("8c9e1a4d-0f6b-49a2-9c5d-1f3e8b2d4c1a"), ProductArticleNumber = "BROWNHANDBAG022", Quantity = 4, ColorId = 6, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("0d8b1c3e-4f5a-42d1-9c7e-8b6d2f1a4c9e"), ProductArticleNumber = "CHECKEREDHANDBAG023", Quantity = 8, ColorId = 6, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("4e5d2c9f-7b6c-4d8a-8e9f-2a1c8d9e0f6b"), ProductArticleNumber = "CHECKEREDKIDSDRESS024", Quantity = 7, ColorId = 4, SizeId = 18 },
            new ProductVariantEntity { Id = new Guid("a3f1e8d2-6c9b-4a5d-8e2f-9d4c1b7a0e6d"), ProductArticleNumber = "CHECKEREDKIDSDRESS024", Quantity = 2, ColorId = 4, SizeId = 19 },
            new ProductVariantEntity { Id = new Guid("2a8f7e3d-6c4a-4d1b-8e5d-9f1c2a4b7c8e"), ProductArticleNumber = "COLORFULKIDSDRESS025", Quantity = 4, ColorId = 13, SizeId = 19 },
            new ProductVariantEntity { Id = new Guid("d7f5c3e0-8b2a-4d1c-9f7e-6c5a8d1b4e9f"), ProductArticleNumber = "COLORFULKIDSDRESS025", Quantity = 6, ColorId = 13, SizeId = 20 },
            new ProductVariantEntity { Id = new Guid("6d2c4b7f-9a1e-4c8d-8b7e-2f3a1c9b0e5d"), ProductArticleNumber = "DENIMSHORTS026", Quantity = 2, ColorId = 2, SizeId = 1 },
            new ProductVariantEntity { Id = new Guid("1f7e6c8a-4d5b-49e2-9c3a-2b7f0d4e1a5c"), ProductArticleNumber = "DENIMSHORTS026", Quantity = 1, ColorId = 2, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("8d9f4c2e-6a3d-4f1b-9c7a-0e5f7c8b2a1d"), ProductArticleNumber = "DENIMSHORTS026", Quantity = 2, ColorId = 2, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("7a4e5f1c-8c9b-4d3f-9a7e-1b2d0e6f5c8a"), ProductArticleNumber = "DENIMSHORTS026", Quantity = 1, ColorId = 2, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("44f05c4e-3b60-4c53-84c9-3b16d8b5c020"), ProductArticleNumber = "GREENKIDSSHOES027", Quantity = 1, ColorId = 11, SizeId = 17 },
            new ProductVariantEntity { Id = new Guid("6d7ea51e-9f40-48d1-a75d-0ef47b46311c"), ProductArticleNumber = "GREENKIDSSHOES027", Quantity = 6, ColorId = 11, SizeId = 18 },
            new ProductVariantEntity { Id = new Guid("8c245f6a-6e6d-43e3-9d0e-45f67aaf2e31"), ProductArticleNumber = "GREYWOMENSTEE028", Quantity = 4, ColorId = 14, SizeId = 1 },
            new ProductVariantEntity { Id = new Guid("faa2e4a3-739c-41e7-82d4-2489d2c25ba6"), ProductArticleNumber = "GREYWOMENSTEE028", Quantity = 3, ColorId = 14, SizeId = 2 },
            new ProductVariantEntity { Id = new Guid("37e9ac13-08a2-4902-ae3f-55f6f2b8790e"), ProductArticleNumber = "GREYWOMENSTEE028", Quantity = 2, ColorId = 14, SizeId = 3 },
            new ProductVariantEntity { Id = new Guid("db8a6f0d-d7c5-4eeb-9404-91a6eac0377d"), ProductArticleNumber = "GREYWOMENSTEE028", Quantity = 1, ColorId = 14, SizeId = 4 },
            new ProductVariantEntity { Id = new Guid("9a48bcf9-afcd-4b1b-8df1-6fc1ec5f17b7"), ProductArticleNumber = "GREYWOMENSTEE028", Quantity = 2, ColorId = 14, SizeId = 5 }
        );

        // Add initial data to the StatusCodes table
        modelBuilder.Entity<StatusCodeEntity>().HasData(
            new StatusCodeEntity { Id = 1, StatusName = "Order being processed" },
            new StatusCodeEntity { Id = 2, StatusName = "Shipping" },
            new StatusCodeEntity { Id = 3, StatusName = "Delivered" },
            new StatusCodeEntity { Id = 4, StatusName = "Canceled" }
            );

    }
}
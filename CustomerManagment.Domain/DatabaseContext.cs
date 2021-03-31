using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    internal class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext //, IDatabaseContext
    {
        #region Solution (1)
        //public DatabaseContext() : base()
        //{
        //}

        //protected override void OnConfiguring
        //	(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        //{
        //	base.OnConfiguring(optionsBuilder);

        //	if (optionsBuilder.IsConfigured == false)
        //	{
        //		// using Microsoft.EntityFrameworkCore;
        //		optionsBuilder
        //			.UseSqlServer(connectionString: "Password=1234512345;Persist Security Info=True;User ID=SA;Initial Catalog=DtxTripleA;Data Source=.");
        //	}
        //}
        #endregion /Solution (1)

        #region Solution (2)
        public DatabaseContext
            (Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion /Solution (2)

        #region Solution (3)
        /// <summary>
        /// Using Migrations!
        /// </summary>
        //public DatabaseContext
        //	(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options)
        //{
        //}
        #endregion /Solution (3)

        // **********

        public virtual DbSet<AreaGeoTbl> AreaGeoTbls { get; set; }
        public virtual DbSet<AreaInfoTbl> AreaInfoTbls { get; set; }
        public virtual DbSet<AttributeFormatTypeInfo> AttributeFormatTypeInfos { get; set; }
        public virtual DbSet<AttributeInfoTbl> AttributeInfoTbls { get; set; }
        public virtual DbSet<AttributeItemTbl> AttributeItemTbls { get; set; }
        public virtual DbSet<CategoryInfoTbl> CategoryInfoTbls { get; set; }
        public virtual DbSet<CityTbl> CityTbls { get; set; }
        public virtual DbSet<CustomerAddressTbl> CustomerAddressTbls { get; set; }
        public virtual DbSet<CustomerAttributeItemTbl> CustomerAttributeItemTbls { get; set; }
        public virtual DbSet<CustomerAttributeTbl> CustomerAttributeTbls { get; set; }
        public virtual DbSet<CustomerInfoTbl> CustomerInfoTbls { get; set; }
        public virtual DbSet<CustomerOrderTbl> CustomerOrderTbls { get; set; }
        public virtual DbSet<CustomerPhoneTbl> CustomerPhoneTbls { get; set; }
        public virtual DbSet<CustomerPreOrderInfoTbl> CustomerPreOrderInfoTbls { get; set; }
        public virtual DbSet<CustomerPreOrderItemsTbl> CustomerPreOrderItemsTbls { get; set; }
        public virtual DbSet<PageCategoryTbl> PageCategoryTbls { get; set; }
        public virtual DbSet<PageInfoTbl> PageInfoTbls { get; set; }
        public virtual DbSet<PageRolePermissionTbl> PageRolePermissionTbls { get; set; }
        public virtual DbSet<ProductInfoTbl> ProductInfoTbls { get; set; }
        public virtual DbSet<ProvinceTbl> ProvinceTbls { get; set; }
        public virtual DbSet<RoleInfoTbl> RoleInfoTbls { get; set; }
        public virtual DbSet<StoreAreaTbl> StoreAreaTbls { get; set; }
        public virtual DbSet<StoreCustomeTimeSheetTbl> StoreCustomeTimeSheetTbls { get; set; }
        public virtual DbSet<StoreInActiveTbl> StoreInActiveTbls { get; set; }
        public virtual DbSet<StoreInfoTbl> StoreInfoTbls { get; set; }
        public virtual DbSet<StoreProductTbl> StoreProductTbls { get; set; }
        public virtual DbSet<StoreTimeSheetTbl> StoreTimeSheetTbls { get; set; }
        public virtual DbSet<SystemMessageTbl> SystemMessageTbls { get; set; }
        public virtual DbSet<UserGeoTrackTbl> UserGeoTrackTbls { get; set; }
        public virtual DbSet<UserInfoTbl> UserInfoTbls { get; set; }
        public virtual DbSet<UserRoleTbl> UserRoleTbls { get; set; }

        protected override void OnModelCreating
            (Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AreaGeoTbl>(entity =>
            {
                entity.ToTable("AreaGeoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.AreaGeoTbls)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_AreaGeoTbl_AreaInfoTbl");
            });

            modelBuilder.Entity<AreaInfoTbl>(entity =>
            {
                entity.ToTable("AreaInfoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AreaInfoTbls)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_AreaInfoTbl_CityTbl");
            });

            modelBuilder.Entity<AttributeFormatTypeInfo>(entity =>
            {
                entity.ToTable("AttributeFormatTypeInfo");

                entity.Property(e => e.AttributeFormatName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.AttributeFormatType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AttributeInfoTbl>(entity =>
            {
                entity.ToTable("AttributeInfoTbl");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AttributeType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<AttributeItemTbl>(entity =>
            {
                entity.ToTable("AttributeItemTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.AttributeItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributeItemTbls)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributeItemTbl_AttributeInfoTbl");
            });

            modelBuilder.Entity<CategoryInfoTbl>(entity =>
            {
                entity.ToTable("CategoryInfoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<CityTbl>(entity =>
            {
                entity.ToTable("CityTbl");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.CityTbls)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_CityTbl_ProvinceTbl");
            });

            modelBuilder.Entity<CustomerAddressTbl>(entity =>
            {
                entity.ToTable("CustomerAddressTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressValue)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddressTbls)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerAddressTbl_CustomerInfoTbl");
            });

            modelBuilder.Entity<CustomerAttributeItemTbl>(entity =>
            {
                entity.ToTable("CustomerAttributeItemTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.AttributeValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.CustomerAttributeItemTbls)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_CustomerAttributeItemTbl_CustomerAttributeTbl");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAttributeItemTbls)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerAttributeItemTbl_CustomerInfoTbl");
            });

            modelBuilder.Entity<CustomerAttributeTbl>(entity =>
            {
                entity.ToTable("CustomerAttributeTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
            });

            modelBuilder.Entity<CustomerInfoTbl>(entity =>
            {
                entity.ToTable("CustomerInfoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerGroupId).HasColumnName("CustomerGroupID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeID");

                entity.Property(e => e.RegisterDate).HasColumnType("date");

                entity.Property(e => e.RegisterTime).HasColumnType("time(0)");

                entity.Property(e => e.RegisterTypeId).HasColumnName("RegisterTypeID");
            });

            modelBuilder.Entity<CustomerOrderTbl>(entity =>
            {
                entity.ToTable("CustomerOrderTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderItems).IsRequired();

                entity.Property(e => e.OrderTime).HasColumnType("time(0)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrderTbls)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerOrderTbl_CustomerInfoTbl");
            });

            modelBuilder.Entity<CustomerPhoneTbl>(entity =>
            {
                entity.ToTable("CustomerPhoneTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPhoneTbls)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerPhoneTbl_CustomerInfoTbl");
            });

            modelBuilder.Entity<CustomerPreOrderInfoTbl>(entity =>
            {
                entity.ToTable("CustomerPreOrderInfoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderTime).HasColumnType("time(0)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPreOrderInfoTbls)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerPreOrderInfoTbl_CustomerInfoTbl");
            });

            modelBuilder.Entity<CustomerPreOrderItemsTbl>(entity =>
            {
                entity.ToTable("CustomerPreOrderItemsTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CustomerPreOrderItemsTbls)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_CustomerPreOrderItemsTbl_CustomerPreOrderInfoTbl");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CustomerPreOrderItemsTbls)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CustomerPreOrderItemsTbl_ProductInfoTbl");
            });

            modelBuilder.Entity<PageCategoryTbl>(entity =>
            {
                entity.ToTable("PageCategoryTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PageInfoTbl>(entity =>
            {
                entity.ToTable("PageInfoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NavbarLink)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageCategoryId).HasColumnName("PageCategoryID");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PageCategory)
                    .WithMany(p => p.PageInfoTbls)
                    .HasForeignKey(d => d.PageCategoryId)
                    .HasConstraintName("FK_PageInfoTbl_PageCategoryTbl");
            });

            modelBuilder.Entity<PageRolePermissionTbl>(entity =>
            {
                entity.ToTable("PageRolePermissionTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PageRolePermissionTbls)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("FK_PageRolePermissionTbl_PageInfoTbl");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PageRolePermissionTbls)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_PageRolePermissionTbl_RoleInfoTbl");
            });

            modelBuilder.Entity<ProductInfoTbl>(entity =>
            {
                entity.ToTable("ProductInfoTbl");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CategotyId).HasColumnName("CategotyID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Categoty)
                    .WithMany(p => p.ProductInfoTbls)
                    .HasForeignKey(d => d.CategotyId)
                    .HasConstraintName("FK_ProductInfoTbl_CategoryInfoTbl");
            });

            modelBuilder.Entity<ProvinceTbl>(entity =>
            {
                entity.ToTable("ProvinceTbl");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<RoleInfoTbl>(entity =>
            {
                entity.ToTable("RoleInfoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StoreAreaTbl>(entity =>
            {
                entity.ToTable("StoreAreaTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.StoreAreaTbls)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_StoreAreaTbl_AreaInfoTbl");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreAreaTbls)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreAreaTbl_StoreInfoTbl");
            });

            modelBuilder.Entity<StoreCustomeTimeSheetTbl>(entity =>
            {
                entity.ToTable("StoreCustomeTimeSheetTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FromTime).HasColumnType("time(0)");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ToTime).HasColumnType("time(0)");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreCustomeTimeSheetTbls)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreCustomeTimeSheetTbl_StoreInfoTbl");
            });

            modelBuilder.Entity<StoreInActiveTbl>(entity =>
            {
                entity.ToTable("StoreInActiveTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.FromTime).HasColumnType("time(0)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.ToTime).HasColumnType("time(0)");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInActiveTbls)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreInActiveTbl_StoreInfoTbl");
            });

            modelBuilder.Entity<StoreInfoTbl>(entity =>
            {
                entity.HasKey(e => e.StoreCode);

                entity.ToTable("StoreInfoTbl");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.StoreAddress).HasMaxLength(1000);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StorePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoreProductTbl>(entity =>
            {
                entity.ToTable("StoreProductTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreProductTbls)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_StoreProductTbl_ProductInfoTbl");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreProductTbls)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreProductTbl_StoreInfoTbl");
            });

            modelBuilder.Entity<StoreTimeSheetTbl>(entity =>
            {
                entity.ToTable("StoreTimeSheetTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StartTime).HasColumnType("time(0)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ToTime).HasColumnType("time(0)");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreTimeSheetTbls)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreTimeSheetTbl_StoreInfoTbl");
            });

            modelBuilder.Entity<SystemMessageTbl>(entity =>
            {
                entity.ToTable("SystemMessageTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MessageValue)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<UserGeoTrackTbl>(entity =>
            {
                entity.ToTable("UserGeoTrackTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGeoTrackTbls)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserGeoTrackTbl_UserInfoTbl");
            });

            modelBuilder.Entity<UserInfoTbl>(entity =>
            {
                entity.ToTable("UserInfoTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<UserRoleTbl>(entity =>
            {
                entity.ToTable("UserRoleTbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleTbls)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoleTbl_RoleInfoTbl");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleTbls)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoleTbl_UserInfoTbl");
            });

        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

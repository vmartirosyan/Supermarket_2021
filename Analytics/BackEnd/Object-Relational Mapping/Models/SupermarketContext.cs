using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Supermarket.Models
{
    public partial class SupermarketContext : DbContext
    {
        public SupermarketContext()
        {
        }

        public SupermarketContext(DbContextOptions<SupermarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressLocation> AddressLocations { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Cashbox> Cashboxes { get; set; }
        public virtual DbSet<CashboxTransaction> CashboxTransactions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CellProduct> CellProducts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual DbSet<Deliveryman> Deliverymen { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DisposableProductsHistory> DisposableProductsHistories { get; set; }
        public virtual DbSet<DisposePackage> DisposePackages { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LogSession> LogSessions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPackage> ProductPackages { get; set; }
        public virtual DbSet<Proffesion> Proffesions { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<SpecialCare> SpecialCares { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TransactionProduct> TransactionProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SAM1399;Database=Supermarket;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AddressLocation>(entity =>
            {
                entity.ToTable("address_location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apartment)
                    .HasMaxLength(25)
                    .HasColumnName("apartment");

                entity.Property(e => e.BuildingNumber).HasColumnName("building_number");

                entity.Property(e => e.City)
                    .HasMaxLength(25)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .HasMaxLength(25)
                    .HasColumnName("district");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.Street)
                    .HasMaxLength(25)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branch");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FreezerVolume).HasColumnName("freezer_volume");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.StorageVolume).HasColumnName("storage_volume");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__branch__location__49C3F6B7");
            });

            modelBuilder.Entity<Cashbox>(entity =>
            {
                entity.ToTable("cashbox");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Money)
                    .HasColumnType("money")
                    .HasColumnName("money");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Cashboxes)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__cashbox__branch___4AB81AF0");
            });

            modelBuilder.Entity<CashboxTransaction>(entity =>
            {
                entity.ToTable("cashbox_transaction");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CashboxId).HasColumnName("cashbox_id");

                entity.Property(e => e.Cashier).HasColumnName("cashier");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("date");

                entity.HasOne(d => d.Cashbox)
                    .WithMany(p => p.CashboxTransactions)
                    .HasForeignKey(d => d.CashboxId)
                    .HasConstraintName("FK__cashbox_t__cashb__4CA06362");

                entity.HasOne(d => d.CashierNavigation)
                    .WithMany(p => p.CashboxTransactions)
                    .HasForeignKey(d => d.Cashier)
                    .HasConstraintName("FK__cashbox_t__cashi__4BAC3F29");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<CellProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cell_products");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.DepQuantity).HasColumnName("dep_quantity");

                entity.Property(e => e.MaxQuantity).HasColumnName("max_quantity");

                entity.Property(e => e.OptimalQuantity).HasColumnName("optimal_quantity");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__cell_prod__branc__4D94879B");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__cell_prod__produ__4E88ABD4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone_number")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__customer__addres__5070F446");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__customer__id__4F7CD00D");
            });

            modelBuilder.Entity<DeliveryStatus>(entity =>
            {
                entity.ToTable("delivery_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Deliveryman>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("deliveryman");

                entity.Property(e => e.CarModel)
                    .HasMaxLength(15)
                    .HasColumnName("car_model");

                entity.Property(e => e.CarNumber)
                    .HasMaxLength(7)
                    .HasColumnName("car_number");

                entity.Property(e => e.CarType)
                    .HasMaxLength(20)
                    .HasColumnName("car_type");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__deliverym__emplo__5165187F");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DisposableProductsHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("disposable_products_history");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RefoundStatus).HasColumnName("refound_status");

                entity.Property(e => e.RefundPrice).HasColumnName("refund_price");

                entity.Property(e => e.RefunderId).HasColumnName("refunder_id");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__disposable_p__id__52593CB8");

                entity.HasOne(d => d.Refunder)
                    .WithMany()
                    .HasForeignKey(d => d.RefunderId)
                    .HasConstraintName("FK__disposabl__refun__534D60F1");
            });

            modelBuilder.Entity<DisposePackage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dispose_package");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Volume).HasColumnName("volume");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__dispose_p__branc__5535A963");

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__dispose_p__prod___5441852A");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.FirstdayDate)
                    .HasColumnType("date")
                    .HasColumnName("firstday_date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone_number")
                    .IsFixedLength(true);

                entity.Property(e => e.ProfessionId).HasColumnName("profession_id");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");

                entity.Property(e => e.StartingSalary)
                    .HasColumnType("money")
                    .HasColumnName("starting_salary");

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__employee__addres__571DF1D5");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__employee__branch__59FA5E80");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__employee__depart__59063A47");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__employee__id__5629CD9C");

                entity.HasOne(d => d.Profession)
                    .WithMany()
                    .HasForeignKey(d => d.ProfessionId)
                    .HasConstraintName("FK__employee__profes__5812160E");
            });

            modelBuilder.Entity<LogSession>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("log_sessions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LogIn)
                    .HasColumnType("datetime")
                    .HasColumnName("log_in");

                entity.Property(e => e.LogOut)
                    .HasColumnType("datetime")
                    .HasColumnName("log_out");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__log_sessions__id__5AEE82B9");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Delivered)
                    .HasColumnType("datetime")
                    .HasColumnName("delivered");

                entity.Property(e => e.DeliveryManId).HasColumnName("delivery_man_id");

                entity.Property(e => e.DeliveryStatusId).HasColumnName("delivery_status_id");

                entity.Property(e => e.OrderDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("order_description");

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.Property(e => e.PeymentStatus)
                    .HasColumnName("peyment_status")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__order__branch_id__5FB337D6");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__order__customer___5BE2A6F2");

                entity.HasOne(d => d.DeliveryMan)
                    .WithMany(p => p.OrderDeliveryMen)
                    .HasForeignKey(d => d.DeliveryManId)
                    .HasConstraintName("FK__order__delivery___5EBF139D");

                entity.HasOne(d => d.DeliveryStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryStatusId)
                    .HasConstraintName("FK__order__delivery___5CD6CB2B");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK__order__order_sta__5DCAEF64");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("order_product");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__order_pro__order__60A75C0F");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__order_pro__produ__619B8048");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(8)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Refunded).HasColumnName("refunded");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__6383C8BA");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__product__supplie__628FA481");
            });

            modelBuilder.Entity<ProductPackage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("product_package");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.DepQuantity).HasColumnName("dep_quantity");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ShippingId).HasColumnName("shipping_id");

                entity.Property(e => e.Volume).HasColumnName("volume");

                entity.Property(e => e.WarehouseQuantity).HasColumnName("warehouse_quantity");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__product_p__branc__656C112C");

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__product_p__prod___66603565");

                entity.HasOne(d => d.Shipping)
                    .WithMany()
                    .HasForeignKey(d => d.ShippingId)
                    .HasConstraintName("FK__product_p__shipp__6477ECF3");
            });

            modelBuilder.Entity<Proffesion>(entity =>
            {
                entity.ToTable("proffesion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProfName)
                    .HasMaxLength(50)
                    .HasColumnName("prof_name");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("shipping");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArrivedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("arrived_at");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("sent_at");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__shipping__branch__6754599E");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__shipping__suppli__68487DD7");
            });

            modelBuilder.Entity<SpecialCare>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("special_care");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.MaxTemp).HasColumnName("max_temp");

                entity.Property(e => e.MinTemp).HasColumnName("min_temp");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__special_c__prod___693CA210");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(25)
                    .HasColumnName("contact_email");

                entity.Property(e => e.ContactNum).HasColumnName("contact_num");

                entity.Property(e => e.ContractExpDate)
                    .HasColumnType("date")
                    .HasColumnName("contract_exp_date");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__supplier__locati__6A30C649");
            });

            modelBuilder.Entity<TransactionProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transaction_product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__transacti__produ__6C190EBB");

                entity.HasOne(d => d.Transaction)
                    .WithMany()
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__transacti__trans__6B24EA82");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Passwd)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("passwd")
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wish_list");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__wish_list__custo__6E01572D");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__wish_list__produ__6D0D32F4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

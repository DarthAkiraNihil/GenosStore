using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace GenosStore.Model.Context {
	public class GenosStoreDatabaseContext : DbContext {
		public GenosStoreDatabaseContext() : base("name=genos_store") { }

		// enum



		// char class

		public DbSet<Definition> Definitions { get; set; }
		public DbSet<Vendor> Vendors { get; set; }

		// computer components

		public DbSet<CPU> CPUs { get; set; }
		public DbSet<RAM> RAMs { get; set; }
		public DbSet<Motherboard> Motherboards { get; set; }
		public DbSet<GraphicsCard> GraphicsCards { get; set; }
		public DbSet<PowerSupply> PowerSupplys { get; set; }
		public DbSet<SataSSD> SataSSDs { get; set; }
		public DbSet<NVMeSSD> NVMeSSDs { get; set; }
		public DbSet<HDD> HDDs { get; set; }
		public DbSet<Display> Displays { get; set; }
		public DbSet<ComputerCase> ComputerCases { get; set; }
		public DbSet<Keyboard> Keyboards { get; set; }
		public DbSet<Mouse> Mouses { get; set; }
		public DbSet<CPUCooler> CPUCoolers { get; set; }

		public DbSet<PreparedAssembly> PreparedAssemblies { get; set; }

		// simple computer components

		public DbSet<MotherboardChipset> MotherboardChipsets { get; set; }
		public DbSet<AudioChipset> AudioChipsets { get; set; }
		public DbSet<NetworkAdapter> NetworkAdapters { get; set; }
		public DbSet<SSDController> SSDControllers { get; set; }
		public DbSet<CPUCore> CPUCores { get; set; }
		public DbSet<GPU> GPUs { get; set; }

		// user

		public DbSet<User> Users { get; set; }
		public DbSet<Administrator> Administrators { get; set; }
		public DbSet<IndividualEntity> IndividualEntities { get; set; }
		public DbSet<LegalEntity> LegalEntities { get; set; }

		// order

		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderedItem> OrderedItems { get; set; }
		public DbSet<Discount> Discounts { get; set; }
		public DbSet<ActiveDiscount> ActiveDiscounts { get; set; }
		public DbSet<BankCard> BankCards { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {

			modelBuilder.HasDefaultSchema("public");

			List<Type> allFieldsRequiredIn = new List<Type>() {
				typeof(Definition),
				typeof(Vendor),
				typeof(CPU),
				typeof(RAM),
				typeof(Motherboard),
				typeof(GraphicsCard),
				typeof(PowerSupply),
				typeof(SataSSD),
				typeof(NVMeSSD),
				typeof(HDD),
				typeof(Display),
				typeof(ComputerCase),
				typeof(Keyboard),
				typeof(Mouse),
				typeof(CPUCooler),
				//
				typeof(MotherboardChipset),
				typeof(AudioChipset),
				typeof(NetworkAdapter),
				typeof(SSDController),
				typeof(CPUCore),
				typeof(GPU),
				//
				typeof(User),
				typeof(IndividualEntity),
				typeof(LegalEntity),
				typeof(Order),
				typeof(OrderedItem),
				//typeof(Discount),
				typeof(ActiveDiscount),
				typeof(BankCard),
			};

			foreach (var entity in allFieldsRequiredIn) {
				modelBuilder
					.Properties()
					.Where(
						p => p.DeclaringType == entity
					)
					.Configure(
						c => c.IsRequired()
					);


			}

			modelBuilder.Entity<Item>().
				HasOptional (i => i.ActiveDiscount);

			modelBuilder.Entity<PreparedAssembly>()
				.HasOptional(a => a.Display);

			modelBuilder.Entity<PreparedAssembly>()
				.HasOptional(a => a.Keyboard);
			modelBuilder.Entity<PreparedAssembly>()
				.HasOptional(a => a.Mouse);

			modelBuilder.Entity<PreparedAssembly>()
				.HasMany(a => a.RAM)
				.WithMany(r => r.PreparedAssemblies); //

			modelBuilder.Entity<PreparedAssembly>()
				.HasMany(a => a.Disks)
				.WithMany(d => d.PreparedAssemblies); //

			modelBuilder.Entity<Order>()
				.HasMany(o => o.Items)
				.WithMany(i => i.Orders);

			modelBuilder.Entity<Customer>()
				.HasMany(c => c.Orders);

			modelBuilder.Entity<Cart>()
				.HasKey(c => c.CustomerId);

			modelBuilder.Entity<Customer>()
				.HasRequired(c => c.Cart)
				.WithRequiredPrincipal(c => c.Customer);

			base.OnModelCreating(modelBuilder);
		}
	}
}
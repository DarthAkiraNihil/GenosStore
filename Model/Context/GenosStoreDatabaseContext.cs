using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Item.Characteristic;
using GenosStore.Model.Entity.Item.ComputerComponent;
using GenosStore.Model.Entity.Item.SimpleComputerComponent;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using GenosStore.Model.Entity.Base;

namespace GenosStore.Model.Context {
	public class GenosStoreDatabaseContext : DbContext {
		public GenosStoreDatabaseContext() : base("name=genos_store") { }

		// enum

		public DbSet<Certificate80Plus> Certificates80Plus { get; set; }
		public DbSet<ComputerCaseTypesize> ComputerCaseTypesize { get; set; }
		public DbSet<CoolerMaterial> ColerMaterials { get; set; }
		public DbSet<CPUSocket> CPUSockets { get; set; }
		public DbSet<KeyboardTypesize> KeyboardTypesizes { get; set; }
		public DbSet<KeyboardType> KeyboardTypes { get; set; }
		public DbSet<MatrixType> MatrixTypes { get; set; }
		public DbSet<MotherboardFormFactor> MotherboardFormFactors { get; set; }
		public DbSet<PCIEVersion> PCIEVersions { get; set; }
		public DbSet<RAMType> RAMTypes { get; set; }
		public DbSet<Underlight> Underlights { get; set; }
		public DbSet<VesaSize> VesaSizes { get; set; }
		public DbSet<VideoPort> VideoPorts { get; set; }
		
		public DbSet<SimpleComputerComponentType> SimpleComputerComponentTypes { get; set; }
		
		public DbSet<BankSystem> BankSystems { get; set; }
		
		// char class

		public DbSet<Definition> Definitions { get; set; }
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<DPIMode> DPIModes { get; set; }

		// computer components

		public DbSet<CPU> CPUs { get; set; }
		public DbSet<RAM> RAMs { get; set; }
		public DbSet<Motherboard> Motherboards { get; set; }
		public DbSet<GraphicsCard> GraphicsCards { get; set; }
		public DbSet<PowerSupply> PowerSupplies { get; set; }
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
		public DbSet<OrderItems> OrderedItems { get; set; }
		public DbSet<ActiveDiscount> ActiveDiscounts { get; set; }
		public DbSet<BankCard> BankCards { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {

			modelBuilder.HasDefaultSchema("public");
			
			//modelBuilder.Entity<Named>().HasRequired(n => n.Name);
			//modelBuilder.Entity<WithModel>().HasRequired(w => w.Model);
			
			modelBuilder.Entity<Item>().
				HasOptional (i => i.ActiveDiscount);
			
			var preparedAssemblyEntity = modelBuilder.Entity<PreparedAssembly>();

			preparedAssemblyEntity.HasRequired(a => a.CPU);
			preparedAssemblyEntity.HasRequired(a => a.Motherboard);
			preparedAssemblyEntity.HasRequired(a => a.GraphicsCard);
			preparedAssemblyEntity.HasRequired(a => a.PowerSupply);
			preparedAssemblyEntity.HasRequired(a => a.ComputerCase);
			preparedAssemblyEntity.HasRequired(a => a.CPUCooler);
			
			preparedAssemblyEntity.HasOptional(a => a.Display);
			preparedAssemblyEntity.HasOptional(a => a.Keyboard);
			preparedAssemblyEntity.HasOptional(a => a.Mouse);

			preparedAssemblyEntity
				.HasMany(a => a.RAM)
				.WithMany(r => r.PreparedAssemblies);

			preparedAssemblyEntity
				.HasMany(a => a.Disks)
				.WithMany(d => d.PreparedAssemblies);



			modelBuilder.Entity<ComputerComponent>().HasRequired(c => c.Vendor);
			
			
			
			var computerCaseEntity = modelBuilder.Entity<ComputerCase>();
			
			computerCaseEntity.HasRequired(cc => cc.ComputerCaseTypesize);
			computerCaseEntity.HasMany(cc => cc.SupportedMotherboardFormFactors)
			                  .WithMany(mbff => mbff.ComputerCases);
			
			
			
			var cpuEntity = modelBuilder.Entity<CPU>();

			cpuEntity.HasRequired(c => c.CPUCore);
			cpuEntity.HasRequired(c => c.CPUSocket);
			cpuEntity.HasMany(c => c.SupportedRamType)
			         .WithMany(r => r.CPUs);
			
			
			
			var cpuCoolerEntity = modelBuilder.Entity<CPUCooler>();

			cpuCoolerEntity.HasRequired(c => c.FoundationMaterial);
			cpuCoolerEntity.HasRequired(c => c.RadiatorMaterial);
			
			
			
			var displayEntity = modelBuilder.Entity<Display>();

			displayEntity.HasRequired(d => d.Definition);
			displayEntity.HasRequired(d => d.MatrixType);
			displayEntity.HasRequired(d => d.Underlight);
			displayEntity.HasRequired(d => d.VesaSize);
			
			
			
			var graphicsCardEntity = modelBuilder.Entity<GraphicsCard>();

			graphicsCardEntity.HasRequired(g => g.GPU);
			graphicsCardEntity.HasMany(g => g.VideoPorts)
			                  .WithMany(v => v.GraphicsCards);
			
			
			
			var keyboardEntity = modelBuilder.Entity<Keyboard>();
			
			keyboardEntity.HasRequired(k => k.KeyboardType);
			keyboardEntity.HasRequired(k => k.Typesize);
			
			
			
			var motherboardEntity = modelBuilder.Entity<Motherboard>();

			motherboardEntity.HasRequired(m => m.FormFactor);
			motherboardEntity.HasRequired(m => m.CPUSocket);
			motherboardEntity.HasRequired(m => m.MotherboardChipset);
			
			motherboardEntity.HasMany(m=>m.SupportedCPUCores)
			                 .WithMany(c => c.Motherboards);
			motherboardEntity.HasMany(m=>m.SupportedRAMTypes)
			                 .WithMany(r => r.Motherboards);
			motherboardEntity.HasMany(m=>m.VideoPorts)
			                 .WithMany(v => v.Motherboards);

			motherboardEntity.HasRequired(m => m.PCIEVersion);
			motherboardEntity.HasRequired(m => m.AudioChipset);
			motherboardEntity.HasRequired(m=>m.NetworkAdapter);



			var mouseEntity = modelBuilder.Entity<Mouse>();
			
			mouseEntity.HasMany(m=>m.DPIModes)
			           .WithMany(m => m.Mouses);
			
			
			var powerSupplyEntity = modelBuilder.Entity<PowerSupply>();

			powerSupplyEntity.HasRequired(p => p.Certificate80Plus);
			
			
			
			var ramEntity = modelBuilder.Entity<RAM>();
			
			ramEntity.HasRequired(r => r.RAMType);
			
			
			
			var ssdEntity = modelBuilder.Entity<SSD>();

			ssdEntity.HasRequired(s => s.SSDController);
			
			
			
			var simpleComputerComponentEntity = modelBuilder.Entity<SimpleComputerComponent>();
			
			simpleComputerComponentEntity.HasRequired(s => s.Type);
			
			
			var cpuCoreEntity = modelBuilder.Entity<CPUCore>();

			cpuCoreEntity.HasRequired(c => c.Vendor);
			
			
			
			var gpuEntity = modelBuilder.Entity<GPU>();

			gpuEntity.HasRequired(g => g.Vendor);



			var bankCardEntity = modelBuilder.Entity<BankCard>();

			bankCardEntity.HasRequired(c => c.BankSystem);
			
			modelBuilder.Entity<Cart>()
			            .HasKey(c => c.CustomerId);
			
			modelBuilder.Entity<Customer>()
			            .HasRequired(c => c.Cart)
			            .WithRequiredPrincipal(c => c.Customer);
			
			modelBuilder.Entity<Customer>()
			            .HasMany(c => c.Orders);

			modelBuilder.Entity<Order>()
			            .HasMany(o => o.Items);

			var orderItemsEntity = modelBuilder.Entity<OrderItems>();
			
			orderItemsEntity.HasRequired(o => o.Order);
			orderItemsEntity.HasRequired(o=>o.Item);
			
			base.OnModelCreating(modelBuilder);
		}
	}
}
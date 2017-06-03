﻿namespace Filer.EntityFrameworkCore
{
	using Filer.Core;
	using Filer.EntityFrameworkCore.Mappings;
	using Microsoft.EntityFrameworkCore;

	internal class FileStoreContext : DbContext
	{
		private const string DefaultConnectionString =
			"Server=(localdb)\\mssqllocaldb;Database=filer;Trusted_Connection=True;MultipleActiveResultSets=true";

		public FileStoreContext()
			: base(new DbContextOptionsBuilder().UseSqlServer(DefaultConnectionString).Options)
		{
		}

		public FileStoreContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<FileData> FileData { get; set; }

		public DbSet<File> Files { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.AddConfiguration(new FileMap());
			modelBuilder.AddConfiguration(new FileDataMap());
		}
	}
}
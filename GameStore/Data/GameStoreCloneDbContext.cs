using System;
using System.Collections.Generic;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public partial class GameStoreCloneDbContext : DbContext
{
    public GameStoreCloneDbContext()
    {
    }

    public GameStoreCloneDbContext(DbContextOptions<GameStoreCloneDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JTP2UM0\\SQL2019;Initial Catalog=GameStoreDbClone1;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Album__3214EC07F94BC029");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC07E6E0E5D0");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts).HasConstraintName("FK_Cart_To_Customer");

            entity.HasOne(d => d.Game1Navigation).WithMany(p => p.CartGame1Navigations).HasConstraintName("FK_Cart_To_Game_1");

            entity.HasOne(d => d.Game2Navigation).WithMany(p => p.CartGame2Navigations).HasConstraintName("FK_Cart_To_Game_2");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC071FA42C86");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();
            entity.Property(e => e.Password).IsFixedLength();

            entity.HasOne(d => d.Cart).WithMany(p => p.Customers).HasConstraintName("FK_Cart_To_Game");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07C4F8C045");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();
            entity.Property(e => e.Password).IsFixedLength();
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC0716DD0AB3");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Category).IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();
            entity.Property(e => e.Publisher).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

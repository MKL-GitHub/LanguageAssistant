using System;
using System.Collections.Generic;
using LanguageAssistant.Models;
using Microsoft.EntityFrameworkCore;

namespace LanguageAssistant.Data;

public partial class LaDbContext : DbContext
{
    public LaDbContext()
    {
    }

    public LaDbContext(DbContextOptions<LaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Collocation> Collocations { get; set; }

    public virtual DbSet<FamiliarCollocation> FamiliarCollocations { get; set; }

    public virtual DbSet<FamiliarWord> FamiliarWords { get; set; }

    public virtual DbSet<LearnedCollocation> LearnedCollocations { get; set; }

    public virtual DbSet<LearnedWord> LearnedWords { get; set; }

    public virtual DbSet<ReadText> ReadTexts { get; set; }

    public virtual DbSet<Text> Texts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchivement> UserAchivements { get; set; }

    public virtual DbSet<UserLibrary> UserLibraries { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; initial catalog=LA_db; trusted_connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Collocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Collocat__3214EC07D51A406D");

            entity.HasOne(d => d.FamiliarCollocation).WithMany(p => p.Collocations).HasConstraintName("FK__Collocati__Famil__4E88ABD4");

            entity.HasOne(d => d.LearnedCollocation).WithMany(p => p.Collocations).HasConstraintName("FK__Collocati__Learn__4D94879B");
        });

        modelBuilder.Entity<FamiliarCollocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Familiar__3214EC07E23FBD30");

            entity.HasOne(d => d.UserAchivement).WithMany(p => p.FamiliarCollocations).HasConstraintName("FK__FamiliarC__UserA__4AB81AF0");
        });

        modelBuilder.Entity<FamiliarWord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Familiar__3214EC07F7CDE6D3");

            entity.HasOne(d => d.UserAchivement).WithMany(p => p.FamiliarWords).HasConstraintName("FK__FamiliarW__UserA__44FF419A");
        });

        modelBuilder.Entity<LearnedCollocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LearnedC__3214EC072D1DB595");

            entity.HasOne(d => d.UserAchivement).WithMany(p => p.LearnedCollocations).HasConstraintName("FK__LearnedCo__UserA__47DBAE45");
        });

        modelBuilder.Entity<LearnedWord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LearnedW__3214EC072FC67A44");

            entity.HasOne(d => d.UserAchivement).WithMany(p => p.LearnedWords).HasConstraintName("FK__LearnedWo__UserA__4222D4EF");
        });

        modelBuilder.Entity<ReadText>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReadText__3214EC07C410813E");

            entity.HasOne(d => d.UserAchivement).WithMany(p => p.ReadTexts).HasConstraintName("FK__ReadText__UserAc__5165187F");
        });

        modelBuilder.Entity<Text>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Text__3214EC073178A9E9");

            entity.HasOne(d => d.ReadText).WithMany(p => p.Texts).HasConstraintName("FK__Text__ReadTextId__5535A963");

            entity.HasOne(d => d.UserLibrary).WithMany(p => p.Texts).HasConstraintName("FK__Text__UserLibrar__5441852A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07652820D3");
        });

        modelBuilder.Entity<UserAchivement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAchi__3214EC078593A2CB");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchivements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserAchiv__UserI__3F466844");
        });

        modelBuilder.Entity<UserLibrary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLibr__3214EC07CD69AFEB");

            entity.Property(e => e.FamiliarCollocationQuantity).HasDefaultValueSql("((0))");
            entity.Property(e => e.FamiliarWordQuantity).HasDefaultValueSql("((0))");
            entity.Property(e => e.LearnedCollocationQuantity).HasDefaultValueSql("((0))");
            entity.Property(e => e.LearnedWordQuantity).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.User).WithMany(p => p.UserLibraries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserLibra__UserI__38996AB5");
        });

        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Word__3214EC07EF16D678");

            entity.HasOne(d => d.Collocation).WithMany(p => p.Words).HasConstraintName("FK__Word__Collocatio__5BE2A6F2");

            entity.HasOne(d => d.FamiliarWord).WithMany(p => p.Words).HasConstraintName("FK__Word__FamiliarWo__5AEE82B9");

            entity.HasOne(d => d.LearnedWord).WithMany(p => p.Words).HasConstraintName("FK__Word__LearnedWor__59FA5E80");

            entity.HasOne(d => d.Text).WithMany(p => p.Words).HasConstraintName("FK__Word__TextId__5812160E");

            entity.HasOne(d => d.UserLibrary).WithMany(p => p.Words).HasConstraintName("FK__Word__UserLibrar__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

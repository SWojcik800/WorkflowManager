using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StorageManager.App.Commons;
using StorageManager.App.Commons.IoC;
using StorageManager.App.Models;

namespace StorageManager.App.Database;

public partial class AppDbContext : DbContext, ISingleton
{
    private string _connectionString;
    public AppDbContext()
    {
        var creds = DbConnectionFactory.GetFromRegistry();
        _connectionString = DbConnectionFactory.GetConnectionString(creds);
    }

    public AppDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public virtual DbSet<Dictionary> Dictionaries { get; set; }

    public virtual DbSet<DictionaryItem> DictionaryItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    public virtual DbSet<UserUserGroup> UserUserGroups { get; set; }

    public virtual DbSet<UserWorkflow> UserWorkflows { get; set; }

    public virtual DbSet<UserWorkflowFieldValue> UserWorkflowFieldValues { get; set; }

    public virtual DbSet<Workflow> Workflows { get; set; }

    public virtual DbSet<WorkflowField> WorkflowFields { get; set; }

    public virtual DbSet<WorkflowStage> WorkflowStages { get; set; }

    public virtual DbSet<WorkflowStageField> WorkflowStageFields { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dictionary>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<DictionaryItem>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.Dictionary).WithMany(p => p.DictionaryItems)
                .HasForeignKey(d => d.DictionaryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DictionaryItems_Dictionaries");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Login).HasMaxLength(150);
            entity.Property(e => e.MiddleName).HasMaxLength(150);
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<UserUserGroup>(entity =>
        {
            entity.HasOne(d => d.UserGroup).WithMany(p => p.UserUserGroups)
                .HasForeignKey(d => d.UserGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserUserGroups_UserGroups");

            entity.HasOne(d => d.User).WithMany(p => p.UserUserGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserUserGroups_Users");
        });

        modelBuilder.Entity<UserWorkflow>(entity =>
        {
            entity.Property(e => e.CompletionTime).HasColumnType("datetime");
            entity.Property(e => e.CreationTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserWorkflowFieldValue>(entity =>
        {
            entity.Property(e => e.FieldCode).HasMaxLength(150);
            entity.Property(e => e.FieldValue).HasMaxLength(150);

            entity.HasOne(d => d.UserWorkflow).WithMany(p => p.UserWorkflowFieldValues)
                .HasForeignKey(d => d.UserWorkflowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWorkflowFieldValues_UserWorkflows");
        });

        modelBuilder.Entity<Workflow>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<WorkflowField>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.DisplayName).HasMaxLength(150);

            entity.HasOne(d => d.Workflow).WithMany(p => p.WorkflowFields)
                .HasForeignKey(d => d.WorkflowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkflowFields_Workflows");
        });

        modelBuilder.Entity<WorkflowStage>(entity =>
        {
            entity.ToTable("WorkflowStage");

            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.StageIndex).HasDefaultValue(0);
        });

        modelBuilder.Entity<WorkflowStageField>(entity =>
        {
            entity.Property(e => e.FieldCode).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public void Upsert<TEntity>(IEntity entity) where TEntity : class
    {
        var dbSet = Set<TEntity>();

        if (entity.Id == 0)
            dbSet.Add((TEntity)entity);
        else
            dbSet.Update((TEntity)entity);

    }
}

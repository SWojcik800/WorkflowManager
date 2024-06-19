﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorageManager.App.Database;

#nullable disable

namespace WorkflowManager.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240615065435_userWorkflowHistoryEntries")]
    partial class userWorkflowHistoryEntries
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StorageManager.App.Models.Dictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Dictionaries");
                });

            modelBuilder.Entity("StorageManager.App.Models.DictionaryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DictionaryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DictionaryId");

                    b.ToTable("DictionaryItems");
                });

            modelBuilder.Entity("StorageManager.App.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Groups")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserUserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserUserGroups");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserWorkflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CompletionTime")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("CurrentStageAssignedToUserId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentStageId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowDictStatus")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentStageId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("UserWorkflows");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserWorkflowFieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FieldCode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FieldValue")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserWorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserWorkflowId");

                    b.ToTable("UserWorkflowFieldValues");
                });

            modelBuilder.Entity("StorageManager.App.Models.Workflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupsThatCanStart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("StorageManager.App.Models.WorkflowField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DisplayData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FieldType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("WorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("WorkflowFields");
                });

            modelBuilder.Entity("StorageManager.App.Models.WorkflowStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignedEntityId")
                        .HasColumnType("int");

                    b.Property<int>("AssignedEntityType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("StageIndex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("WorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("WorkflowStage", (string)null);
                });

            modelBuilder.Entity("StorageManager.App.Models.WorkflowStageField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FieldCode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsEditable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<int>("WorkflowStageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowStageId");

                    b.ToTable("WorkflowStageFields");
                });

            modelBuilder.Entity("WorkflowManager.App.Models.UserWorkflowHistoryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<int>("ActionUserId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserWorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActionUserId");

                    b.HasIndex("UserWorkflowId");

                    b.ToTable("UserWorkflowHistoryEntries");
                });

            modelBuilder.Entity("StorageManager.App.Models.DictionaryItem", b =>
                {
                    b.HasOne("StorageManager.App.Models.Dictionary", "Dictionary")
                        .WithMany("DictionaryItems")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DictionaryItems_Dictionaries");

                    b.Navigation("Dictionary");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserUserGroup", b =>
                {
                    b.HasOne("StorageManager.App.Models.UserGroup", "UserGroup")
                        .WithMany("UserUserGroups")
                        .HasForeignKey("UserGroupId")
                        .IsRequired()
                        .HasConstraintName("FK_UserUserGroups_UserGroups");

                    b.HasOne("StorageManager.App.Models.User", "User")
                        .WithMany("UserUserGroups")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserUserGroups_Users");

                    b.Navigation("User");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserWorkflow", b =>
                {
                    b.HasOne("StorageManager.App.Models.WorkflowStage", "CurrentStage")
                        .WithMany()
                        .HasForeignKey("CurrentStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorageManager.App.Models.Workflow", "Workflow")
                        .WithMany()
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentStage");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserWorkflowFieldValue", b =>
                {
                    b.HasOne("StorageManager.App.Models.UserWorkflow", "UserWorkflow")
                        .WithMany("UserWorkflowFieldValues")
                        .HasForeignKey("UserWorkflowId")
                        .IsRequired()
                        .HasConstraintName("FK_UserWorkflowFieldValues_UserWorkflows");

                    b.Navigation("UserWorkflow");
                });

            modelBuilder.Entity("StorageManager.App.Models.WorkflowField", b =>
                {
                    b.HasOne("StorageManager.App.Models.Workflow", "Workflow")
                        .WithMany("WorkflowFields")
                        .HasForeignKey("WorkflowId")
                        .HasConstraintName("FK_WorkflowFields_Workflows");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("StorageManager.App.Models.WorkflowStage", b =>
                {
                    b.HasOne("StorageManager.App.Models.Workflow", "Workflow")
                        .WithMany("WorkflowStage")
                        .HasForeignKey("WorkflowId");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("StorageManager.App.Models.WorkflowStageField", b =>
                {
                    b.HasOne("StorageManager.App.Models.WorkflowStage", null)
                        .WithMany("StageFields")
                        .HasForeignKey("WorkflowStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkflowManager.App.Models.UserWorkflowHistoryEntry", b =>
                {
                    b.HasOne("StorageManager.App.Models.User", "ActionUser")
                        .WithMany()
                        .HasForeignKey("ActionUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorageManager.App.Models.UserWorkflow", "UserWorkflow")
                        .WithMany("HistoryEntries")
                        .HasForeignKey("UserWorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionUser");

                    b.Navigation("UserWorkflow");
                });

            modelBuilder.Entity("StorageManager.App.Models.Dictionary", b =>
                {
                    b.Navigation("DictionaryItems");
                });

            modelBuilder.Entity("StorageManager.App.Models.User", b =>
                {
                    b.Navigation("UserUserGroups");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserGroup", b =>
                {
                    b.Navigation("UserUserGroups");
                });

            modelBuilder.Entity("StorageManager.App.Models.UserWorkflow", b =>
                {
                    b.Navigation("HistoryEntries");

                    b.Navigation("UserWorkflowFieldValues");
                });

            modelBuilder.Entity("StorageManager.App.Models.Workflow", b =>
                {
                    b.Navigation("WorkflowFields");

                    b.Navigation("WorkflowStage");
                });

            modelBuilder.Entity("StorageManager.App.Models.WorkflowStage", b =>
                {
                    b.Navigation("StageFields");
                });
#pragma warning restore 612, 618
        }
    }
}
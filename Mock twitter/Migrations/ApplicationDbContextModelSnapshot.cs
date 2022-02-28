﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mock_twitter.Data_Access;

namespace Mock_twitter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mock_twitter.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Friendship", b =>
                {
                    b.Property<int>("TargetUserId")
                        .HasColumnType("int");

                    b.Property<int>("FriendUserId")
                        .HasColumnType("int");

                    b.HasKey("TargetUserId", "FriendUserId");

                    b.HasIndex("FriendUserId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Mock_twitter.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Admin", b =>
                {
                    b.HasBaseType("Mock_twitter.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Publisher", b =>
                {
                    b.HasBaseType("Mock_twitter.Entities.User");

                    b.HasDiscriminator().HasValue("Publisher");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Comment", b =>
                {
                    b.HasOne("Mock_twitter.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Friendship", b =>
                {
                    b.HasOne("Mock_twitter.Entities.Publisher", "FriendUser")
                        .WithMany("Friendships")
                        .HasForeignKey("FriendUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mock_twitter.Entities.Publisher", "TargetUser")
                        .WithMany("MainFriendships")
                        .HasForeignKey("TargetUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FriendUser");

                    b.Navigation("TargetUser");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Post", b =>
                {
                    b.HasOne("Mock_twitter.Entities.Publisher", "Publisher")
                        .WithMany("Posts")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Mock_twitter.Entities.Publisher", b =>
                {
                    b.Navigation("Friendships");

                    b.Navigation("MainFriendships");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
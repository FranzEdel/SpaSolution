// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Database;

#nullable disable

namespace Core.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220315003409_FirstM")]
    partial class FirstM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Model.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Model.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("ClientID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Model.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailID"), 1L, 1);

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("Model.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProductID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Model.Order", b =>
                {
                    b.HasOne("Model.Client", "Client")
                        .WithMany("Items")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Model.OrderDetail", b =>
                {
                    b.HasOne("Model.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.Client", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Model.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Model.Product", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

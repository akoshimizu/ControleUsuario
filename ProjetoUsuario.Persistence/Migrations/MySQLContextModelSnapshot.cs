﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoUsuario.Persistence.Context;

#nullable disable

namespace ProjetoUsuario.Persistence.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("DescricaoPerfil")
                        .HasColumnType("longtext")
                        .HasColumnName("descricao_perfil");

                    b.Property<bool>("IndicadorPerfil")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("indicador_perfil");

                    b.HasKey("Id");

                    b.ToTable("perfil");
                });

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CodMesa")
                        .HasColumnType("int")
                        .HasColumnName("codigo_mesa");

                    b.Property<int>("CodPerfil")
                        .HasColumnType("int")
                        .HasColumnName("codigo_perfil");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("IndicadorUsuarioAtivo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("indicador_usuario");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("longtext")
                        .HasColumnName("nome_usuario");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}

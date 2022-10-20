﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoUsuario.Persistence.Context;

#nullable disable

namespace ProjetoUsuario.Persistence.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20221020161335_DadosNoDb")]
    partial class DadosNoDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataDeCriacaoMesa")
                        .HasColumnType("datetime")
                        .HasColumnName("data_criacao_mesa");

                    b.Property<DateTime>("DataUltimaAlteracaoMesa")
                        .HasColumnType("datetime")
                        .HasColumnName("data_ultima_alteracao_mesa");

                    b.Property<string>("DescricaoMesa")
                        .HasColumnType("longtext")
                        .HasColumnName("descricao_mesa");

                    b.Property<bool>("IndicadorMesaAtiva")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("indicador_mesa");

                    b.HasKey("Id");

                    b.ToTable("mesa");
                });

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.MesaUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("MesaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("mesa_usuario");
                });

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCriacaoPerfil")
                        .HasColumnType("datetime")
                        .HasColumnName("data_criacao_perfil");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnType("datetime")
                        .HasColumnName("data_ultima_atualizacao_pefil");

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

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<bool>("IndicadorUsuarioAtivo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("indicador_usuario");

                    b.Property<int?>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("longtext")
                        .HasColumnName("nome_usuario");

                    b.Property<int?>("PerfilId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.HasIndex("PerfilId");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.MesaUsuario", b =>
                {
                    b.HasOne("ProjetoUsuario.Domain.Entidades.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId");

                    b.HasOne("ProjetoUsuario.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("MesasdoUsuario")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Mesa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.Usuario", b =>
                {
                    b.HasOne("ProjetoUsuario.Domain.Entidades.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId");

                    b.HasOne("ProjetoUsuario.Domain.Entidades.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId");

                    b.Navigation("Mesa");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("ProjetoUsuario.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("MesasdoUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}

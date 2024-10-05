﻿// <auto-generated />
using System;
using Fiap.Health.Med.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fiap.Health.Med.Infrastructure.Migrations
{
    [DbContext(typeof(HealthDbContext))]
    partial class HealthDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.AgendaMedico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DiaSemana")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("HoraFim")
                        .HasColumnType("interval")
                        .HasColumnName("hora_fim");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("interval")
                        .HasColumnName("hora_inicio");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("agendas_medico", (string)null);
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Agendamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraAtendimento")
                        .HasColumnType("datetime");

                    b.Property<Guid>("EspecialidadeMedicoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uuid");

                    b.Property<int>("StatusAgendamento")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeMedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("agendamento", (string)null);
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Especialidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descricao")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("especialidade", (string)null);
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.EspecialidadeMedico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("datetime")
                        .HasColumnName("dataRegistro");

                    b.Property<Guid>("EspecialidadeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.HasIndex("MedicoId");

                    b.ToTable("especialidadeMedico", (string)null);
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar")
                        .HasColumnName("cep");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("cpf");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("crm");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("endereco");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("estado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("medico", (string)null);
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar")
                        .HasColumnName("cep");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("endereco");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("estado");

                    b.Property<string>("Idade")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar")
                        .HasColumnName("idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("paciente", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.AgendaMedico", b =>
                {
                    b.HasOne("Fiap.Health.Med.Domain.Entity.Medico", "Medico")
                        .WithMany("AgendasMedico")
                        .HasForeignKey("MedicoId")
                        .IsRequired();

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Agendamento", b =>
                {
                    b.HasOne("Fiap.Health.Med.Domain.Entity.EspecialidadeMedico", "EspecialidadeMedico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("EspecialidadeMedicoId")
                        .IsRequired();

                    b.HasOne("Fiap.Health.Med.Domain.Entity.Paciente", "Paciente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PacienteId")
                        .IsRequired();

                    b.Navigation("EspecialidadeMedico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.EspecialidadeMedico", b =>
                {
                    b.HasOne("Fiap.Health.Med.Domain.Entity.Especialidade", "Especialidade")
                        .WithMany("EspecialidadeMedicos")
                        .HasForeignKey("EspecialidadeId")
                        .IsRequired();

                    b.HasOne("Fiap.Health.Med.Domain.Entity.Medico", "Medico")
                        .WithMany("EspecialidadesMedicos")
                        .HasForeignKey("MedicoId")
                        .IsRequired();

                    b.Navigation("Especialidade");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Especialidade", b =>
                {
                    b.Navigation("EspecialidadeMedicos");
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.EspecialidadeMedico", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Medico", b =>
                {
                    b.Navigation("AgendasMedico");

                    b.Navigation("EspecialidadesMedicos");
                });

            modelBuilder.Entity("Fiap.Health.Med.Domain.Entity.Paciente", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Pokedex.Model.Connection;

namespace Pokedex.Model.Migrations
{
    [DbContext(typeof(PokedexContext))]
    [Migration("20220106131203_AlterTableAddColumnIsCreatedByTheUser")]
    partial class AlterTableAddColumnIsCreatedByTheUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21");

            modelBuilder.Entity("Pokedex.Model.Entities.AbilityDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("Pokedex.Model.Entities.AbilityPokemonDB", b =>
                {
                    b.Property<int>("AbilityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AbilityId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("AbilityPokemonDB");
                });

            modelBuilder.Entity("Pokedex.Model.Entities.MoveDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("Pokedex.Model.Entities.MovePokemonDB", b =>
                {
                    b.Property<int>("MoveId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MoveId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("MovePokemonDB");
                });

            modelBuilder.Entity("Pokedex.Model.Entities.PokemonDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseExperience")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hp")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCreatedByTheUser")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sprite")
                        .HasColumnType("TEXT");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Pokedex.Model.Entities.TypeDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Pokedex.Model.Entities.TypePokemonDB", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TypeId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("TypePokemonDB");
                });

            modelBuilder.Entity("Pokedex.Model.Entities.AbilityPokemonDB", b =>
                {
                    b.HasOne("Pokedex.Model.Entities.AbilityDB", "Ability")
                        .WithMany("Pokemons")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokedex.Model.Entities.PokemonDB", "Pokemon")
                        .WithMany("Abilities")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pokedex.Model.Entities.MovePokemonDB", b =>
                {
                    b.HasOne("Pokedex.Model.Entities.MoveDB", "Move")
                        .WithMany("Pokemons")
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokedex.Model.Entities.PokemonDB", "Pokemon")
                        .WithMany("Moves")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pokedex.Model.Entities.TypePokemonDB", b =>
                {
                    b.HasOne("Pokedex.Model.Entities.PokemonDB", "Pokemon")
                        .WithMany("Types")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokedex.Model.Entities.TypeDB", "Type")
                        .WithMany("Pokemons")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

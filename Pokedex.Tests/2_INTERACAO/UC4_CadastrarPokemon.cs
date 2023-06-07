using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._2_INTERACAO
{
    [Collection("Database")]
    public class UC4_CadastrarPokemon
    {
        [Fact]
        public async void CadastrandoNovoPokemonComDadosValidos()
        {

            var pokemon = new PokemonDB()
            {
                Name = "PokemonTest",
                Hp = 100,
                Attack = 100,
                Defense = 100,
                Height = 100,
                SpecialAttack = 100,
                SpecialDefense = 100,
                Speed = 100,
                BaseExperience = 100,
                IsComplete = true,
                IsCreatedByTheUser = true,
            };

            await pokemon.AddAbility("Ability Test");
            await pokemon.AddMove("Move Test");
            await pokemon.AddType("Type1 Test");
            await pokemon.AddType("Type2 Test");

            await pokemon.SetId();

            //Act
            await new PokemonService().RegisterIsCreatedByUser(pokemon);

            //Assert
            var pokemonObtido = await new PokemonService().FindById(pokemon.Id);
            var pokemonEsperado = pokemon;

            Assert.Equal(pokemonEsperado, pokemonObtido);
        }

        [Fact]
        public async void CadastrandoNovoPokemonComDadosInvalidos()
        {
            var pokemon = new PokemonDB()
            {
                // Dados inválidos
                Name = null, // Nome nulo
                Hp = -10, // HP negativo
                Attack = 0, // Ataque zero
                Defense = 2000, // Defesa alta demais
                Height = -1, // Altura negativa
                SpecialAttack = 50,
                SpecialDefense = 50,
                Speed = 50,
                BaseExperience = 50,
                IsComplete = true,
                IsCreatedByTheUser = true,
            };

            await pokemon.AddAbility("Ability Test");
            await pokemon.AddMove("Move Test");
            await pokemon.AddType("Type1 Test");
            await pokemon.AddType("Type2 Test");

            await pokemon.SetId();

            // Act
            await new PokemonService().RegisterIsCreatedByUser(pokemon);

            // Assert
            var pokemonObtido = await new PokemonService().FindById(pokemon.Id);

            // Verifique se o Pokémon obtido é nulo, indicando que não foi registrado corretamente
            Assert.Null(pokemonObtido);
        }
    }
}

using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._4_INTERACAO
{
    [Collection("Database")]
    public class RQ1_CrudBancoDeDados
    {
        [Fact]
        public async void Create()
        {
            //Arrange
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

            PokemonDAO pokemonDAO = new PokemonDAO();

            //Act
            await pokemonDAO.Add(pokemon);

            //Assert
            var pokemonEsperado = pokemon;
            var pokemonObtido = await pokemonDAO.FindByName(pokemon.Name);

            Assert.Equal(pokemonEsperado, pokemonObtido);
        }

        [Theory]
        [InlineData("Pokemon Test 1")]
        [InlineData("Pokemon Test 2")]
        [InlineData("Pokemon Test 3")]
        public async void Read(string nameTeste) 
        {
            //Arrange 
            var pokemonAdicionado = new PokemonDB() { Name = nameTeste };
            PokemonDAO pokemonDAO = new PokemonDAO();
            await pokemonDAO.Add(pokemonAdicionado);

            //Act
            var pokemonEsperado = await pokemonDAO.FindByName(nameTeste);

            //Assert
            Assert.Equal(pokemonAdicionado.Name, pokemonEsperado.Name);
        }

        [Theory]
        [InlineData("Pokemon Test Update")]
        public async void Update(string nameTeste)
        {
            //Arrange 
            var pokemon = new PokemonDB() { Name = nameTeste };
            PokemonDAO pokemonDAO = new PokemonDAO();
            await pokemonDAO.Add(pokemon);

            //Act
            var pokemonNaoModificado = await pokemonDAO.FindByName(nameTeste);
            pokemonNaoModificado.Name = "Change Pokemon Test Update";

            await pokemonDAO.Update(pokemonNaoModificado);

            var pokemonModificado  = await pokemonDAO.FindById(pokemonNaoModificado.Id);

            //Assert
            Assert.Equal(pokemonModificado.Name, pokemonNaoModificado.Name);
        }

        [Fact]
        public async void Delete() 
        {
            //Arrange 
            var nameTeste = "Dalete Pokemon Test";

            var pokemonExistente = new PokemonDB() { Name = nameTeste };
            PokemonDAO pokemonDAO = new PokemonDAO();
            await pokemonDAO.Add(pokemonExistente);

            //Act
            await pokemonDAO.Delete(pokemonExistente);        

            var pokemonEsperado = await pokemonDAO.FindByName(pokemonExistente.Name);

            //Assert
            Assert.Null(pokemonEsperado);
        }
    }
}

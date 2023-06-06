using Pokedex.Model.Exceptions;
using Pokedex.Model.Service;
using Pokedex.Tests.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._1_INTERACAO
{
    [Collection("Database")]
    public class UC1_BuscaPeloNome
    {

        [Fact]
        public void BuscarPokemonExistente()
        {
            //Arrange
            var name = "pikachu";
            var service = new PokemonService();

            //Act
            var pokemon = service.FindByName(name).Result;

            //Assert
            var valorEsperado = name;
            var valorObtido = pokemon.Name;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void BuscarPokemonNaoExistenteLanceNotFoundException()
        {
            //arrange
            var name = "hojaosjsd";
            var service = new PokemonService();

            // act & assert
            Assert.ThrowsAsync<PokemonNotFoundException>(async () => await service.FindByName(name));
        }
    }
}

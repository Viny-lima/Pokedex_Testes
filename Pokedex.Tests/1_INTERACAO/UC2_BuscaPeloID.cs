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
    public class UC2_BuscaPeloID
    {
        [Fact]
        public void BuscarPokemonComIDExistente()
        {
            //Arrange
            var id = 25;
            var service = new PokemonService();

            //Act
            var pokemon = service.FindById(id).Result;

            //Assert
            var valorEsperado = id;
            var valorObtido = pokemon.Id;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void BuscarPokemonComIDNaoExistenteLancePokemonNotFoundException()
        {
            //arrange
            var id = -1;
            var service = new PokemonService();

            // act & assert
            Assert.ThrowsAsync<PokemonNotFoundException>(async () => await service.FindById(id));
        }

    }
}

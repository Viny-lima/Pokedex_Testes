using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._4_INTERACAO
{
    public class RQ2_BuscaPokemonDaApi
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void BuscaPorNomeComEntradaInvalida(String search)
        {
            //Arrange
            String idOrName = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(idOrName);

            //Assert
            var resultadoObtido = pokemonAPI;

            Assert.Null(resultadoObtido);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(9000000)]
        [InlineData(-100)]
        public void BuscaPorIDComEntradaInvalida(int search)
        {
            //Arrange
            var id = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(id);

            //Assert
            var resultadoObtido = pokemonAPI;

            Assert.Null(resultadoObtido);
        }



        [Theory]
        [InlineData("pikachu")]
        public void BuscaPorNome(string search)
        {
            //Arrange
            var name = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(name);

            //Assert
            var resultadoEsperado = search;
            var resultadoObtido = pokemonAPI.Name;

            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

        [Theory]
        [InlineData(25)]
        [InlineData(100)]
        [InlineData(10001)]
        public void BuscaPorID(int search)
        {
            //Arrange
            var id = search;

            //Act
            var pokemonAPI = ApiRequest.GetPokemon(id);

            //Assert
            var resultadoEsperado = search;
            var resultadoObtido = pokemonAPI.Id;

            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(5, 7)]
        [InlineData(890, 10)]
        public void RetornarQuantidadeInformada(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            Assert.Equal(_quantidade, resultado.Count);
        }

        [Theory]
        [InlineData(-10, 10)]
        [InlineData(10001, 7)]
        public void RetornarListaVaziaQuandoNaoExistirNaApi(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            var esperado = 0;
            Assert.Equal(esperado, resultado.Count);
        }

        [Theory]
        [InlineData(1, -100)]
        [InlineData(100, -1000)]
        public void RetornarQtdApiMenosQtdInformadaQuandoQuantidadeForNegativa(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;
            var totalDePokemonsDaApi = ApiRequest.GetPokemonCount();

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            var esperado = totalDePokemonsDaApi + _quantidade;
            Assert.Equal(esperado, resultado.Count);
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(100, 110)]
        [InlineData(0, 110)]
        [InlineData(897, 1)]
        public void UltimoPokemonDeveTerIdIgualQtdMaisInicio(int inicio, int quantidade)
        {
            //Arrange
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = ApiRequest.GetPokemonsList(_inicio, _quantidade);

            //Assert
            var esperado = _inicio + _quantidade;
            Assert.Equal(esperado, resultado.Last().Id);
        }
        
    }
}

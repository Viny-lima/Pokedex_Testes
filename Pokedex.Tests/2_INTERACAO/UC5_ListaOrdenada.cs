using Pokedex.Model.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._2_INTERACAO
{
    [Collection("Database")]
    public class UC5_ListaOrdenada
    {

        [Fact]
        public async void VerificarListaDePokemonsEmOrdem()
        {
            //Arrange
            var service = new PokemonService();
            var _inicio = 1;
            var _quantidade = 890;

            //Act
            var listaDePokemons = await service.FindAllById(_inicio, _quantidade);
            var IDs = new List<int>();

            foreach (var pokemon in listaDePokemons)
            {
                IDs.Add(pokemon.Id);
            }

            //Assert
            Assert.True(AreIdsOrdered(IDs));
        }

        public bool AreIdsOrdered(List<int> ids)
        {
            for (int i = 0; i < ids.Count - 1; i++)
            {
                if (ids[i] > ids[i + 1])
                {
                    // IDs estão fora de ordem crescente
                    return false;
                }
            }

            // IDs estão em ordem crescente ou vazios
            return true;
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(5, 7)]
        [InlineData(890, 10)]
        public async void VerificarQuatidadeEspecificada(int inicio, int quantidade)
        {
            //Arrange
            var service = new PokemonService();
            var _quantidade = quantidade;
            var _inicio = inicio;

            //Act
            var resultado = await service.FindAllById(_inicio, _quantidade);

            //Assert
            Assert.Equal(_quantidade, resultado.Count);
        }

    }
}

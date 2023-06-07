using Pokedex.Model.DAO;
using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._4_INTERACAO
{
    [Collection("Database")]
    public class RQ3_SePokemonNaoEstaNoBancoDeDadosBuscarNaAPI
    {
        [Fact]
        public async void BuscaPorPokemonNaoPresenteNoBancoDeDados()
        {
            //Arrange
            int IdDebusca = 15;
            PokemonDAO pokemonDAO = new PokemonDAO();
            PokemonService pokemonService = new PokemonService();   

            //Act
            var pokemonNaoEncontrado = await pokemonDAO.FindById(IdDebusca);

            var buscaNaApiESalvoNoBD = await pokemonService.FindById(IdDebusca);

            var pokemonSalvoNoBD = await pokemonDAO.FindById(IdDebusca);

            //Assert
            Assert.Null(pokemonNaoEncontrado);
            Assert.NotNull(pokemonSalvoNoBD);
        }
    }
}

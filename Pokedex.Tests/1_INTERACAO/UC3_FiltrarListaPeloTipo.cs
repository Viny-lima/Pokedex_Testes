using Pokedex.Model.Enums;
using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._1_INTERACAO
{
    [Collection("Database")]
    public class UC3_FiltrarListaPeloTipo
    {
        [Theory]
        [InlineData(TypeNames.normal, 130)]
        [InlineData(TypeNames.fighting, 78)]
        [InlineData(TypeNames.flying, 135)]
        [InlineData(TypeNames.dragon, 78)]
        public void BuscarTodosOsPokemonsDaqueleTipo(TypeNames type, int quantidade)
        {
            //Arrange
            var service = new PokemonService();
            var _type = type;
            var _quantidade = quantidade;

            //Act
            var resultado = service.FindAllByType(_type, 1, _quantidade).Result;

            //Assert

            foreach(var pokemon in resultado)
            {
                var typesOfPokemons = pokemon.Types;

                foreach(var typeContent in typesOfPokemons)
                {
                    var pokemonIsType = typeContent.Type.Name == _type.ToString();
                    Assert.True(pokemonIsType);
                }
            }
        }        

        [Theory]
        [InlineData(TypeNames.normal, "rattata")]
        [InlineData(TypeNames.fighting, "tyrogue")]
        [InlineData(TypeNames.flying, "pidgey")]
        [InlineData(TypeNames.dragon, "dratini")]
        public void BuscarPeloTipoEVerificarSePokemonComumAqueleTipoEstarPresente(TypeNames nome, string nomePokemon)
        {
            //Arrange
            var service = new PokemonService();
            var _nome = nome;
            var _nomePokemon = nomePokemon;

            //Act
            var resultado = service.FindAllByType(_nome, 1, 10).Result;

            //Assert
            Assert.Contains(resultado, p => p.Name == _nomePokemon);
        }        
    }
}

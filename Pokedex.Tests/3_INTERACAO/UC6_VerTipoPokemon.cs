using Pokedex.Model.Enums;

using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._3_INTERACAO
{
    [Collection("Database")]
    public class UC6_VerTipoPokemon
    {
        [Theory(DisplayName ="Buscar os tipos do pokemon de acordo com o nome dele")]
        [InlineData("pikachu", TypeNames.electric)]
        [InlineData("squirtle", TypeNames.water)]
        [InlineData("articuno", TypeNames.ice)]
        [InlineData("mewtwo", TypeNames.psychic)]
        [InlineData("dragonite", TypeNames.dragon)]
        [InlineData("lapras", TypeNames.water)]
        [InlineData("charmander", TypeNames.fire)]
        [InlineData("bulbasaur", TypeNames.grass)]
        [InlineData("jigglypuff", TypeNames.normal)]
        [InlineData("meowth", TypeNames.normal)]
        [InlineData("psyduck", TypeNames.water)]
        [InlineData("snorlax", TypeNames.normal)]
        [InlineData("eevee", TypeNames.normal)]
        [InlineData("gengar", TypeNames.ghost)]
        [InlineData("machamp", TypeNames.fighting)]
        [InlineData("vaporeon", TypeNames.water)]
        [InlineData("flareon", TypeNames.fire)]
        [InlineData("jolteon", TypeNames.electric)]
        [InlineData("mew", TypeNames.psychic)]
        [InlineData("zapdos", TypeNames.electric)]
        public void BuscarTiposPokemon(string nome, TypeNames tipo)
        {
            var name = nome;
            var service = new PokemonService();

            var valorObtido = service.FindByName(name).Result.Types;

            var valorEsperado = tipo;

            Assert.Contains(valorObtido, p => p.Type.Name == valorEsperado.ToString());
        }
    }

}

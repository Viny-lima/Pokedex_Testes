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
        [InlineData("charmander", TypeNames.fire)]
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

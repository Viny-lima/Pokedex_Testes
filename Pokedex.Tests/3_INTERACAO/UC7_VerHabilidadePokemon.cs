using Pokedex.Model.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests._3_INTERACAO
{
    [Collection("Database")]
    public class UC7_VerHabilidadePokemon
    {
        [Theory(DisplayName = "Ver habilidades do pokemon pelo nome fornecido")]
        [InlineData("pikachu", "lightning-rod", "static")]
        [InlineData("charmander", "blaze", "solar-p")]
        [InlineData("metapod", "shed-skin")]
        [InlineData("golbat", "inner-focus", "infiltrator")]
        public void VerHabilidadePokemon(string nome, params string[] skills)
        {
            var name = nome;
            var service = new PokemonService();
            var skill = skills;

            var pokemon = service.FindByName(name).Result.Abilities;

            Assert.Contains(pokemon, p => skills.Contains(p.Ability.Name.ToString()));
        }
    }
}

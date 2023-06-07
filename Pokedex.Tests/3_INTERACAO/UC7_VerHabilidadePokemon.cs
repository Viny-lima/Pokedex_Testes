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
        [InlineData("bulbasaur", "overgrow", "chlorophyll")]
        [InlineData("squirtle", "torrent", "rain-dish")]
        [InlineData("jigglypuff", "cute-charm", "competitive")]
        [InlineData("meowth", "pickup", "technician")]
        [InlineData("psyduck", "damp", "cloud-nine")]
        [InlineData("snorlax", "immunity", "thick-fat")]
        [InlineData("eevee", "run-away", "adaptability")]
        [InlineData("dragonite", "inner-focus", "multiscale")]
        [InlineData("gengar", "cursed-body", "levitate")]
        [InlineData("machamp", "guts", "no-guard")]
        [InlineData("lapras", "water-absorb", "shell-armor")]
        [InlineData("vaporeon", "water-absorb", "hydration")]
        [InlineData("flareon", "flash-fire", "guts")]
        [InlineData("jolteon", "volt-absorb", "quick-feet")]
        [InlineData("mewtwo", "pressure", "unnerve")]
        [InlineData("mew", "synchronize")]
        [InlineData("zapdos", "pressure", "static")]
        [InlineData("articuno", "pressure", "snow-cloak")]
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

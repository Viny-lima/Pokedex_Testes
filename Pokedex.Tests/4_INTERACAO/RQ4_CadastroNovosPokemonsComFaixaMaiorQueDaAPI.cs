using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
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
    public class RQ4_CadastroNovosPokemonsComFaixaMaiorQueDaAPI
    {

        [Fact]
        public async void CadastrandoPokemonComIDMaiorQueDaAPI()
        {
            var faixaDeValoresDeCadastrados = 100000;
            PokemonService pokemonService = new PokemonService();

            var pokemon = new PokemonDB()
            {
                Name = "PokemonTest",
                Hp = 100,
                Attack = 100,
                Defense = 100,
                Height = 100,
                SpecialAttack = 100,
                SpecialDefense = 100,
                Speed = 100,
                BaseExperience = 100,
                IsComplete = true,
                IsCreatedByTheUser = true,
            };

            await pokemon.AddAbility("Ability Test");
            await pokemon.AddMove("Move Test");
            await pokemon.AddType("Type1 Test");
            await pokemon.AddType("Type2 Test");

            await pokemon.SetId();

            //Act
            await new PokemonService().RegisterIsCreatedByUser(pokemon);

            //Assert
            var pokemonObtido = await pokemonService.FindById(pokemon.Id);

            Assert.True(pokemonObtido.Id > faixaDeValoresDeCadastrados);
        }
    }
}

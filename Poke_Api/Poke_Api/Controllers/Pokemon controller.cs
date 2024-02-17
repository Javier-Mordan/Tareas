using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Poke_Api.Model;
using Poke_Api.Negocio;
using System.Xml.Linq;

namespace Poke_Api.Controllers
{
    [ApiController]
    [Route("Pokemon")]
    public class Pokemon_controller : ControllerBase, Interface
    {
        public Actions action = new Actions();
        public ApiActions apiAction = new ApiActions();

        [HttpGet]
        [Route("Reach")]
        public dynamic ListPokemon(string reach)
        {
            Pokemon pokemon = action.ReachPokemon(reach);
            return pokemon;
        }
                
        [HttpGet]
        [Route("Save")]
        public dynamic SavePokemonbyname(string name)
        {
            try
            {
                Pokemon pokemon = new Pokemon();
                pokemon = action.Save(name);

                return pokemon;
            }
            catch (Exception e)
            {
                return new
                {
                    problem = "No se pudo guardar el pokemon",
                    last = "Intente de nuevo",
                };
            }

        }

        [HttpPost]
        [Route("SaveAll")]

        public dynamic SaveAll(string name, string latitud, string longitud, string favoriteFood, string bloodType, DateTime dateTime)
        {
            try
            {
                Pokemon pokemon = action.SaveUser(name, latitud, longitud, favoriteFood, bloodType, dateTime);

                return pokemon;
            }
            catch
            {
                return new
                {
                    problem = "Es posible que el pokemon no exista, vuelva a intentarlo",
                };
            }
        }

        [HttpGet]
        [Route("ByMonth")]

        public dynamic GetByMonth(int month)
        {
            try
            {
                List<Pokemon> pokemons = apiAction.ReachByMonth(month);

                return pokemons;
            }catch
            {
                return new
                {
                    aja = "",
                };
            }
        }

        [HttpGet]
        [Route("GetTypes")]

        public dynamic GetTypes()
        {
            try
            {
                var type = apiAction.ShowTypes();

                return type;
                
            }
            catch
            {
                

                return new
                {
                    Type = "mkjm",
                };
            }
        }

        [HttpGet]
        [Route("GetFood")]

        public dynamic GetFood()
        {
            try
            {
                var type = apiAction.ShowFood();

                return type;

            }
            catch
            {


                return new
                {
                    Type = "mkjm",
                };
            }
        }
    }
}





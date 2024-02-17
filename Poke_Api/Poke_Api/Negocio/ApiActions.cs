using Newtonsoft.Json;
using Poke_Api.Model;
using System.Collections.Generic;

namespace Poke_Api.Negocio
{
    public class ApiActions
    {

        private const string jsonFilePath = "Arch.json";

        #region
        public dynamic ReachByMonth(int month)
        {


            List<Pokemon> pokemons = new List<Pokemon>();
            List < Pokemon > pokemonByMonth = new List<Pokemon>();

            string json = File.ReadAllText(jsonFilePath);
            pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(json);

            pokemonByMonth = (List<Pokemon>)pokemons.Where(poke => poke.Date.Month == month).ToList();

            Console.WriteLine(pokemons);

            return pokemonByMonth;

        }
        #endregion


        #region
        public dynamic ShowTypes()
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            string json = File.ReadAllText(jsonFilePath);
            pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(json);            

            Dictionary<string, List<Pokemon>> pokemonsByTypes = new Dictionary<string, List<Pokemon>>();

            foreach (var pokemon in pokemons)
            {
                if (!pokemonsByTypes.ContainsKey(pokemon.Type))
                {
                    pokemonsByTypes[pokemon.Type] = new List<Pokemon>();
                }
                pokemonsByTypes[pokemon.Type].Add(pokemon);
            }
            List<string> types = new List<string>();

            foreach (var kvp in pokemonsByTypes)
            {

                List<Pokemon> pokemon = kvp.Value;
                types.Add($"Pokémon del tipo {kvp.Key} {pokemon.Count()}");
            }


            return types;

        }
        #endregion

        #region
        public dynamic ShowFood ()
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            string json = File.ReadAllText(jsonFilePath);
            pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(json);

            //var fire = (List<Pokemon>)pokemons.Where(x => x.Type =="fire").ToList();

            Dictionary<string, List<Pokemon>> pokemonsByTypes = new Dictionary<string, List<Pokemon>>();

            foreach (var pokemon in pokemons)
            {
                if (!pokemonsByTypes.ContainsKey(pokemon.Type))
                {
                    pokemonsByTypes[pokemon.Type] = new List<Pokemon>();
                }
                pokemonsByTypes[pokemon.Type].Add(pokemon);
            }
            List<string> types = new List<string>();

            foreach (var kvp in pokemonsByTypes)
            {
                types.Add($"Las comidas favorita de los tipo {kvp.Key} son");
                foreach (var pokemon in kvp.Value)
                {
                    types.Add(pokemon.FavoriteFood);
                }
            }

            return types;
        }
        #endregion
    }
}

using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using Poke_Api.Model;
using System;
using Newtonsoft.Json;
using System.Threading;

namespace Poke_Api.Negocio
{
    public class Actions
    {

        private const string jsonFilePath = "Arch.json";

        #region Save Pokemon
        public dynamic Save(string Buscar)
        {
            using (var client = new HttpClient())
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/";

                url += Buscar;

                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;

                dynamic poke = JObject.Parse(res);
                dynamic name = poke.name.ToString();
                dynamic order = poke.order.ToString();
                dynamic type = poke.types[0].type.name.ToString();                
                int weight = Convert.ToInt32(poke.weight.ToString());

                Pokemon pokemon = new Pokemon
                {
                    Id = Convert.ToInt32(order),
                    Name = name,
                    Type = type,
                    FavoriteFood = "",
                    Location = "",
                    BloodType = "",
                    Date = DateTime.Now,
                    Weight = weight,
                };

                List<Pokemon> pokemons1 = new List<Pokemon>();

                if (File.Exists(jsonFilePath))
                {
                     string json = File.ReadAllText(jsonFilePath);
                     pokemons1 = JsonConvert.DeserializeObject<List<Pokemon>>(json);
                     pokemons1.Add(pokemon);
                     var json1 = JsonConvert.SerializeObject(pokemons1, Formatting.Indented);
                     File.WriteAllText(jsonFilePath, json1);
                }               
                
                return pokemon;
            }
        }
        #endregion

        #region Reach Pokemon
        public dynamic ReachPokemon(string name)
        {
            List<Pokemon> pokemons;
            string json = File.ReadAllText(jsonFilePath);
            pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(json);

            Pokemon pokemon = pokemons.FirstOrDefault(x => x.Name == name);
            return pokemon;
        }
        #endregion

        #region Save Pokemon by User
        public dynamic SaveUser(string name, string latitud, string longitud, string favoriteFood, string bloodType, DateTime date)
        {

            using (HttpClient client = new HttpClient())
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/";

                url += name;

                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;                
                dynamic poke = JObject.Parse(res);
                dynamic Name = poke.name.ToString();
                dynamic order = Convert.ToInt32(poke.order.ToString().ToString());
                dynamic type = poke.types[0].type.name.ToString();
                int weight = Convert.ToInt32(poke.weight.ToString());
                dynamic sprite = poke.sprites.front_default.ToString();

                if (Name is not null )
                {
                    Pokemon pokemon = new Pokemon
                    {
                        Id = order,
                        Name = name,
                        Type = type,
                        FavoriteFood = favoriteFood,
                        Location = latitud + longitud,
                        BloodType = bloodType,
                        Date = date,
                        Weight = weight,
                        Sprite = sprite,
                    };

                    List<Pokemon> pokemons1 = new List<Pokemon>();

                    if (File.Exists(jsonFilePath))
                    {
                        string json = File.ReadAllText(jsonFilePath);
                        pokemons1 = JsonConvert.DeserializeObject<List<Pokemon>>(json);
                        pokemons1.Add(pokemon);
                        var json1 = JsonConvert.SerializeObject(pokemons1, Formatting.Indented);
                        File.WriteAllText(jsonFilePath, json1);
                    }
                    return pokemon;
                }

                return new
                {
                    aja = "Emty",
                };
            }
        }

        #endregion

    }
}

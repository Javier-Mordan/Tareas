namespace Poke_Api
{
    public interface Interface
    {
        public dynamic ListPokemon(string reach);
        public dynamic SavePokemonbyname(string name);
        public dynamic SaveAll(string name, string latitud, string longitud, string favoriteFood, string bloodType, DateTime dateTime);
        public dynamic GetByMonth(int month);
        public dynamic GetTypes();
        public dynamic GetFood();
        

    }
}

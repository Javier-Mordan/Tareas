using System.Diagnostics.CodeAnalysis;

namespace Poke_Api.Model
{
    public class Pokemon
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string FavoriteFood { get; set; }
        public string Location { get; set; }
        public string BloodType { get; set; }
        public DateTime Date { get; set; }
        public int Weight { get; set; }
        public dynamic Sprite { get; set; } 
    }
}

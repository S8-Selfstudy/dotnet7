namespace SuperHeroAPI.Models
{
    public class SuperHero
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public bool Active { get; set; }

        public SuperHero(int id, string name, string firstName, string lastName, string place, bool active)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Place = place;
            Active = active;
        }
    }
}

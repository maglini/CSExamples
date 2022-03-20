namespace Logic.Models
{
    public class User
    {
        public int Id { get; init; }
        
        public string Name { get; init; }
        
        // Would be unique
        public string Username { get; init; }
    }
}
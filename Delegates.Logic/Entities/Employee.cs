namespace ConsoleApp6.Entities
{
    public class Employee : Person
    {
        public string Position { get; init; }
        
        public Employee(string name, Gender gender, int age, string position) 
            : base(name, gender, age)
        {
            Position = position;
        }
    }
}
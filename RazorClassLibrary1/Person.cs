namespace RazorClassLibrary1
{
    public class Person
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    public class PersonList
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public IEnumerable<Person> Results { get; set; }
    }
}

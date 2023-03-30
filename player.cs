public record Player
{
    public Player(long id, string name, string lastName)
    {
        Id = id;
        Name = name;
        Lastname = lastName;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }

}
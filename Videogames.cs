public record Videogame
{
    public Videogame(long id, string name, string overview, DateTime releaseDate, long softwareHouseId)
    {
        Id = id;
        Name = name;
        Overview = overview;
        ReleaseDate = releaseDate;
        SoftwareHouseId = softwareHouseId;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Overview { get; set; }
    public DateTime ReleaseDate { get; set; }
    public long SoftwareHouseId { get; set; }
}


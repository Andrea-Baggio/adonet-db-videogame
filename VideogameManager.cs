using System.Data.SqlClient;

public class VideogameManager
{
    private string connectionString;

    public VideogameManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Videogame? GetById(long id)
    {
        using var conn = new SqlConnection(connectionString);

        try
        {
            conn.Open();

            using var comand = new SqlCommand(VideogameQueries.SelectById, conn);
            comand.Parameters.AddWithValue("@Id", id);

            var reader = comand.ExecuteReader(); //ExecuteReader recupera il risultato

            if (reader.Read())
            {
                var name = reader.GetString(1);
                var overview = reader.GetString(2);
                var releaseDate = reader.GetDateTime(3);
                var softwareHouseId = reader.GetInt64(4);

                return new Videogame(id, name, overview, releaseDate, softwareHouseId);
            }

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }



    public static class VideogameQueries
    {
        public const string Insert = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@Name, @Overview, @ReleaseDate, @SoftwareHouseId)";
        public const string SelectById = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE Id = @Id";
        public const string SearchByString = "SELECT name FROM videogames WHERE name like @Name";
        public const string DeleteById = "DELETE FROM videogames WHERE id = @Id";
    }
}

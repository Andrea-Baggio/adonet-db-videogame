using System.Data.SqlClient;


var connStr = "Data Source=localhost;Initial Catalog=db_videogames;Integrated Security=True";

using var conn = new SqlConnection(connStr);

var players = new List<Player>();


try
{
    conn.Open();

    var query = "SELECT id, name, lastname FROM players WHERE name LIKE '%a' AND lastname LIKE '%y'";

    using var command = new SqlCommand(query, conn);
    using SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        var id = reader.GetInt64(0);
        var name = reader.GetString(1);
        var lastname = reader.GetString(2);

        var p = new Player(id, name, lastname);
        players.Add(p);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


foreach (var player in players) Console.WriteLine(player);
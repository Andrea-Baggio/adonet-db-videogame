using System.Data.SqlClient;


var connStr = "Data Source = localhost;" +
      "Initial Catalog = db_videogames; Integrated Security = True";

var conn = new SqlConnection(connStr);
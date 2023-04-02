using System.Data.SqlClient;

const string connectionString = "Data Source=localhost;Initial Catalog=db_videogames;Integrated Security=True";
var manager = new VideogameManager(connectionString);



Console.WriteLine("Scegli una di queste opzioni:");
Console.WriteLine("Inserire un nuovo videogioco (1)");
Console.WriteLine("Ricercare un videogioco per id (2)");
Console.WriteLine("Ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input (3)");
Console.WriteLine("Eliminare un videogioco (4)");


while (true)
{
    int opzione = 0;

    while (opzione is 0)
    {
        var input = Console.ReadLine();

        opzione = identificaOpzione(input);
    }

    switch (opzione)
    {
        case 1:
            {
                Console.Write("Passa il nome: ");
                var name = Console.ReadLine() ?? ""; //questo vuol dire che se arriva una risposta vuota viene messo una stringa vuota

                Console.Write("Passa l'overview: ");
                var overview = Console.ReadLine() ?? "";

                Console.Write("Passa la release date (yyyy-MM-dd): ");
                var releaseDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Passa l'id della software house: ");
                var softwareHouseId = Convert.ToInt64(Console.ReadLine());

                var videogame = new Videogame(0, name, overview, releaseDate, softwareHouseId);
                var success = manager.InsertVideogame(videogame);

                if (success) Console.WriteLine("Videogioco inserito.");
                else Console.WriteLine("Inserimento fallito.");
            }
            break;
        case 2:
            {
                Console.Write("Passa l'id: ");

                var id = Convert.ToInt64(Console.ReadLine());
                var videogame = manager.GetById(id);

                if (videogame is null) Console.WriteLine("Videogame non trovato.");
                else Console.WriteLine(videogame);
            }
            break;
        case 3:
            break;
        case 4:
            break;
    }
}

int identificaOpzione(string? input)
{
    switch (input)
    {
        case "1":
        case "inserisci":
            return 1;
        case "2":
        case "ricerca":
            return 2;
        case "3":
        case "filtra":
            return 3;
        case "4":
        case "elimina":
            return 4;
        case "5":
        case "chiudi":
            return 5;
        default:
            Console.WriteLine("Input non valido.");
            return 0;
    }
}
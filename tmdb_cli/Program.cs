// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using tmdb_cli;

Console.WriteLine("Welcome to TMDB CLI Tool");

string? apiKey = Environment.GetEnvironmentVariable("TMDB_API_KEY");

if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("Erreur : la variable d’environnement TMDB_API_KEY est manquante.");
    // return null;
}
else
{
    string? type = null;

    for (int i = 0; i < args.Length - 1; i++)
    {
        if (args[i] == "--type")
        {
            type = args[i + 1];
            break;
        }
    }

    if (string.IsNullOrEmpty(type))
    {
        Console.WriteLine(" Missing required argument '--type'.");
        Console.WriteLine("Usage: tmdb-cli.exe --type <playing|popular|top|upcoming>");
        return;
    }

    Console.WriteLine($"Retrieving data for {type}");

    var service = new TmdbService();

    string json = await service.getData(type, apiKey);

    // Console.WriteLine(json);

    MovieResponse? response ;
    try
    {
        response = JsonSerializer.Deserialize<MovieResponse>(json);
    }
    catch (Exception ex)
    {
        Console.WriteLine($" Erreur de parsing JSON : {ex.Message}");
        return;
    }

    // Vérification et affichage
    if (response?.Responses == null || response.Responses.Count == 0)
    {
        Console.WriteLine(" Aucun film trouvé.");
        return;
    }

    Console.WriteLine($"\n Films trouvés ({response.Responses.Count}) :\n");

    int index = 1;
    foreach (var movie in response.Responses)
    {
        Console.WriteLine($"#{index++} - {movie.title} ({movie.release_date})");
        Console.WriteLine($"   Langue originale : {movie.original_language}");
        Console.WriteLine($"   Note : {movie.vote_average} ({movie.vote_count} votes)");
        Console.WriteLine($"   +18 : {(movie.adult ? "Oui" : "Non")}");
        Console.WriteLine($"   Résumé : {Truncate(movie.overview, 150)}");
        Console.WriteLine();
    }

    // Méthode utilitaire pour tronquer un texte
    static string Truncate(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text)) return "(Pas de résumé)";
        return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
    }

}
using ClassCo;

var games = new List<Game>
{
    new Game("The Legend of Zelda: Breath of the Wild", "Nintendo", 2017, 97),
    new Game("God of War", "Sony", 2018, 94),
    new Game("Red Dead Redemption 2", "Rockstar Games", 2018, 97),
    new Game("The Witcher 3: Wild Hunt", "CD Projekt", 2015, 93),
};
//var highScoreGames = games.Where(g => g.MetacriticScore >= 95);
//foreach (var game in highScoreGames)
//{
//    Console.WriteLine($"{game.Title} ({game.ReleaseYear}) - Metacritic Score: {game.MetacriticScore}");
//}

//var groupedGames = games
//    .OrderByDescending(g => g.ReleaseYear)
//    .GroupBy(g => g.ReleaseYear);
//int count = 1;
//foreach (var group in groupedGames)
//    
//    foreach (var game in group)
//    {
//        Console.WriteLine($"{count++}-{game.Title} - Metacritic Score: {game.MetacriticScore}");
//    }


//var allGames = games.Select(g => g.Title).ToList();
//foreach (var title in allGames)
//{
//    Console.WriteLine(title);
//}

//var avgScore = games.Where(g => g.MetacriticScore > 98);
//foreach (var gm in avgScore)
//{
//    Console.WriteLine($"{gm.Title} - {gm.MetacriticScore}");
//}
//try
//{
//    var firstGame = games.First(g => g.MetacriticScore > 98);
//    Console.WriteLine($"First game with Metacritic score above 98: {firstGame} ");
//}
//catch (InvalidOperationException)
//{
//     Console.WriteLine("No game found with Metacritic score above 98.");
//}

//var gameExists = games.Any(g=>g.Title=="The Witcher 3: Wild Hunt");
//Console.WriteLine($"Is 'The Witcher 3: Wild Hunt' in the list? {gameExists}");

//var sortedGames = games
//    .OrderByDescending(g => g.MetacriticScore)
//    .ThenBy(g => g.ReleaseYear);
//Console.WriteLine("Games sorted by Metacritic score (descending) and Release Year (ascending:");
//int count = 1;
//foreach (var gm in sortedGames)
//{
//    Console.WriteLine($"{count++}-{gm.Title} - Metacritic Score: {gm.MetacriticScore},Release year: {gm.
//        ReleaseYear}");
//}

//var top3Games = games
//    .OrderByDescending(g => g.MetacriticScore)
//    .ThenBy(g => g.ReleaseYear)

//    .Select(g => $"{g.Title}-{g.MetacriticScore}-{g.ReleaseYear}");
//foreach (var game in top3Games)

//Console.WriteLine(game);




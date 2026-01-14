

namespace ClassCo
{
    internal class Game
    {
        
        public Game(string title, string developer, int releaseYear, int metacriticScore)
        {
            Title = title;
            Developer = developer;
            ReleaseYear = releaseYear;
            MetacriticScore = metacriticScore;
        }
        internal string Title { get; set; }
        internal string Developer { get; set; }
        internal int ReleaseYear { get; set; }
        internal int MetacriticScore { get; set; }

    }
}



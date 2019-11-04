namespace NBAStars
{
    public class Player
    {
        private string name;
        private int playerSince;
        private string position;
        private double rating;

        public Player(string name, int playerSince, string position, double rating)
        {
            this.name = name;
            this.playerSince = playerSince;
            this.position = position;
            this.rating = rating;
        }

        public string Name => this.name;

        public int PlayerSince => this.playerSince;

        public string Position => this.position;

        public double Rating => this.rating;
    }
}
namespace RawData
{
    public class Engine
    {
        private int speed;
        private int power;

        public int Speed
        {
            get => this.speed;
            private set { this.speed = value; }
        }

        public int Power
        {
            get => this.power;
            private set { this.power = value; }
        }

        public Engine(int speed,int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
    }
}

namespace FightingArena
{
    public class Stat
    {
        public Stat(int strength, int agility, int flexibility, int skills, int intelligence)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Flexibility = flexibility;
            this.Skills = skills;
            this.Intelligence = intelligence;
        }

        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Flexibility { get; private set; }
        public int Skills { get; private set; }
        public int Intelligence { get; private set; }
    }
}

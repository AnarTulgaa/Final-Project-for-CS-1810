namespace Environment
{

    public abstract class Environments
    {
        public string Description { get; protected set; } = "default";
        public ConsoleColor BackgroundColor { get; protected set; } = ConsoleColor.White;
        public abstract string BackgroundDisplay();
    }

    public class DarkEnvironment : Environments
    {
        public DarkEnvironment(string descriptionForDark)
        {
            Description = descriptionForDark;
        }
        public DarkEnvironment()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Description = "It is middle of the night.";
            BackgroundColor = ConsoleColor.Gray;
        }
        public override string BackgroundDisplay()
        {
            return Description;
        }
    }

    public class SunnyEnvironment : Environments
    {
        public SunnyEnvironment(string descriptionForSunny)
        {
            Description = descriptionForSunny;
        }

        public SunnyEnvironment()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Description = "It is middle of the day.";
            BackgroundColor = ConsoleColor.Yellow;
        }

        public override string BackgroundDisplay()
        {
            return Description;
        }
    }

    public class CastleEnvironment : Environments
    {
        public CastleEnvironment(string descriptionForInside)
        {
            Description = descriptionForInside;
        }

        public CastleEnvironment()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Description = "It is inside of the castle.";
            BackgroundColor = ConsoleColor.Blue;

        }
        public override string BackgroundDisplay()
        {
            return Description;
        }
    }
}

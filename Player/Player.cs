namespace Player;

public class Players
{
    public string Name { get; protected set; }

    public Players(string name)
    {
        Name = name;
    }
}
namespace Heroes;

public abstract class Hero
{
    public int Damage { get; protected set; }
    public int Health { get; protected set; }
    public int Armor { get; protected set; }
    public int MaxHealth { get; protected set; }
    public Hero(int damage, int health, int armor, int maxHealth)
    {
        Damage = damage;
        Health = health;
        Armor = armor;
        MaxHealth = maxHealth;
    }

    public int Attack(Hero target)
    {
        Random random = new Random();
        int rollResult = random.Next(1, 6);

        int damageTaken = Damage + rollResult - target.Armor;
        if (damageTaken < 0)
        { damageTaken = 1; }
        target.Health -= damageTaken;

        return damageTaken;
    }
}

public class Viking : Hero
{
    public Viking() : base(1, 20, 4, 20)
    { }
}

public class Spartan : Hero
{
    public Spartan() : base(5, 18, 2, 18)
    { }
}

public class MongolWarrior : Hero
{
    public MongolWarrior() : base(6, 16, 3, 16)
    { }
}

public class Samurai : Hero
{
    public Samurai() : base(5, 14, 2, 14)
    { }
}

public class AssasinOfPersia : Hero
{
    public AssasinOfPersia() : base(6, 14, 1, 14)
    { }
}
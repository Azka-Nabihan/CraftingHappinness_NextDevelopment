public abstract class Enemy
{
    public abstract void ApplyEffect(Character character);
}

public class FullDay : Enemy
{
    public override void ApplyEffect(Character character)
    {
        character.Stamina -= 20;
        character.Wish += 10;
    }
}

public class HalfDay : Enemy
{
    public override void ApplyEffect(Character character)
    {
        character.Stamina -= 10;
        character.Wish += 5;
    }
}

public static class EnemyFactory
{
    public static Enemy CreateEnemy(string type)
    {
        return type switch
        {
            "FullDay" => new FullDay(),
            "HalfDay" => new HalfDay(),
            _ => throw new ArgumentException("Invalid type")
        };
    }
}

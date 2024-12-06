public abstract class Item
{
    public int Cost { get; protected set; }
    public int HappinessBoost { get; protected set; }
    public int StaminaBoost { get; protected set; } = 0;

    public abstract void ApplyEffect();
}

public class Makanan : Item
{
    public Makanan()
    {
        Cost = 10;
        HappinessBoost = 5;
        StaminaBoost = 10;
    }

    public override void ApplyEffect()
    {
        Character character = Character.GetInstance();
        character.HappinessIndex = Math.Max(-100, character.HappinessIndex + HappinessBoost); // Allow negative happiness
        character.Stamina = Math.Min(100, character.Stamina + StaminaBoost);
        Console.WriteLine("Makanan used! Happiness increased by 5, Stamina increased by 10.");
    }
}

public class Minuman : Item
{
    public Minuman()
    {
        Cost = 5;
        HappinessBoost = 2;
        StaminaBoost = 5;
    }

    public override void ApplyEffect()
    {
        Character character = Character.GetInstance();
        character.HappinessIndex = Math.Max(-100, character.HappinessIndex + HappinessBoost); // Allow negative happiness
        character.Stamina = Math.Min(100, character.Stamina + StaminaBoost);
        Console.WriteLine("Minuman used! Happiness increased by 2, Stamina increased by 5.");
    }
}

public class PS5 : Item
{
    public PS5()
    {
        Cost = 50;
        HappinessBoost = 10;
    }

    public override void ApplyEffect()
    {
        Character character = Character.GetInstance();
        character.HappinessIndex = Math.Max(-100, character.HappinessIndex + HappinessBoost); // Allow negative happiness
        Console.WriteLine("PS5 used! Happiness increased by 10.");
    }
}

public class HangoutParty : Item
{
    public HangoutParty()
    {
        Cost = 20;
        HappinessBoost = 4;
    }

    public override void ApplyEffect()
    {
        Character character = Character.GetInstance();
        character.HappinessIndex = Math.Max(-100, character.HappinessIndex + HappinessBoost); // Allow negative happiness
        Console.WriteLine("Hangout Party used! Happiness increased by 4.");
    }
}

public class NontonBioskopBarengBuWati : Item
{
    public NontonBioskopBarengBuWati()
    {
        Cost = 10;
        HappinessBoost = 2;
    }

    public override void ApplyEffect()
    {
        Character character = Character.GetInstance();
        character.HappinessIndex = Math.Max(-100, character.HappinessIndex + HappinessBoost); // Allow negative happiness
        Console.WriteLine("Nonton Bioskop Bareng Bu Wati used! Happiness increased by 2.");
    }
}
public class Sleep : IActivity
{
    public void Execute()
    {
        Character character = Character.GetInstance();
        int staminaRestoration = 20;
        character.Stamina = Math.Min(100, character.Stamina + staminaRestoration);
        Console.WriteLine($"Pak Yon sleeps and restores {staminaRestoration} stamina. Current stamina: {character.Stamina}");
    }
}

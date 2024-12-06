public class NPC
{
    public string Name { get; }
    public List<string> Dialogues { get; }
    public int HappinessEffect { get; }
    public int SadnessEffect { get; }

    public NPC(string name, List<string> dialogues, int happinessEffect, int sadnessEffect)
    {
        Name = name;
        Dialogues = dialogues;
        HappinessEffect = happinessEffect;
        SadnessEffect = sadnessEffect;
    }

    public void Interact(Character player)
    {
        foreach (var dialogue in Dialogues)
        {
            Console.WriteLine($"{Name}: {dialogue}");
            Console.ReadLine(); // Tunggu input dari pemain untuk melanjutkan dialog
        }

        // Pengaruh ke emosi karakter
        if (HappinessEffect > 0)
        {
            player.HappinessIndex = Math.Min(100, player.HappinessIndex + HappinessEffect);
            Console.WriteLine($"You feel happier after talking to {Name}. Happiness increased by {HappinessEffect}.");
        }
        else if (SadnessEffect > 0)
        {
            player.HappinessIndex = Math.Max(-100, player.HappinessIndex - SadnessEffect);
            Console.WriteLine($"You feel sadder after talking to {Name}. Happiness decreased by {SadnessEffect}.");
        }

        player.UpdateEmotion();
    }
}
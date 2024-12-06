public class Character
{
    private static readonly Character _instance = new Character();
    public static Character GetInstance() => _instance;

    public int Stamina { get; set; }
    public int Wish { get; set; }
     public Emotion_Enum Emotion { get; private set; }
    public int HappinessIndex { get; set; }
    public JobLevel JobLevel { get; set; }
    public Inventory Inventory { get; private set; }

    private Character()
    {
        Stamina = 100;
        Wish = 0;
        HappinessIndex = 0;
        Emotion = Emotion_Enum.Neutral;
        JobLevel = JobLevel.TukangKayu;
        Inventory = new Inventory();
    }

    public void UpdateEmotion()
    {
        if (HappinessIndex > 20)
        {
            Emotion = Emotion_Enum.Happy;
            ApplyHappyEffects(); // Terapkan efek positif jika bahagia
        }
        else if (HappinessIndex > 0)
        {
            Emotion = Emotion_Enum.Neutral;
        }
        else if (HappinessIndex > -20)
        {
            Emotion = Emotion_Enum.Sad;
        }
        else
        {
            Emotion = Emotion_Enum.Depressed;
        }
    }

    private void ApplyHappyEffects()
    {
        // Terapkan efek positif jika karakter bahagia
        Stamina = Math.Min(100, Stamina + 10); // Regenerasi stamina
        Console.WriteLine("You feel happy! Stamina increased by 10.");
    }

    public int GetIncome()
    {
        return JobLevel switch
        {
            JobLevel.TukangKayu => 10,
            JobLevel.Ojek => 20,
            JobLevel.Trader => 40,
            _ => 0
        };

        // if (Emotion == Emotion_Enum.Happy)
        // {
        //     baseIncome += 5; // Peningkatan pendapatan jika bahagia
        //     Console.WriteLine("You feel happy! Income increased by 5.");
        // }
    }

    public bool CanBuyItem(Item item)
    {
        return Wish >= item.Cost;
    }

    public void BuyItem(Item item)
    {
        if (Wish >= item.Cost)
        {
            Inventory.AddItem(item);
            Wish -= item.Cost;
            Console.WriteLine($"You bought {item.GetType().Name}!");
        }
        else
        {
            Console.WriteLine("You don't have enough wish to buy this item.");
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"Stamina: {Stamina}, Wish: {Wish}, Happiness: {HappinessIndex}, Emotion: {Emotion}, Job Level: {JobLevel}");
    }
}

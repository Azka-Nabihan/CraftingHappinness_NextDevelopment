public class Character
{
    private static readonly Character _instance = new Character();
    public static Character GetInstance() => _instance;

    public int Stamina { get; set; }
    public int Wish { get; set; }
    public int HappinessIndex { get; set; }
    public JobLevel JobLevel { get; set; }
    public Inventory Inventory { get; private set; }

    private Character()
    {
        Stamina = 100;
        Wish = 0;
        HappinessIndex = 0;
        JobLevel = JobLevel.TukangKayu;
        Inventory = new Inventory();
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
        Console.WriteLine($"Stamina: {Stamina}, Wish: {Wish}, Happiness: {HappinessIndex}, Job Level: {JobLevel}");
    }
}

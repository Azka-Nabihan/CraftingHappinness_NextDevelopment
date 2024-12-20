using System.Collections.Generic;

public class Inventory
{
    public List<Item> Items { get; private set; } = new List<Item>();

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void UseItem(Item item)
    {
        item.ApplyEffect();
        Character.GetInstance().UpdateEmotion(); // Perbarui emosi setelah menggunakan item
        Items.Remove(item);
    }
}

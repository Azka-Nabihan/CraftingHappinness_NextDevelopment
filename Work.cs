public class WorkActivity : IActivity
{
    public void Execute()
    {
        Character character = Character.GetInstance();
        int income = character.GetIncome();
        int staminaCost = 10;

        if (character.Stamina >= staminaCost)
        {
            character.Stamina -= staminaCost;
            character.Wish += income;
            Console.WriteLine($"Pak Yon works and earns {income} wish. Current wish: {character.Wish}. Stamina remaining: {character.Stamina}");
        }
        else
        {
            Console.WriteLine("Pak Yon doesn't have enough stamina to work.");
        }
    }
}

public class JobLevelItem : Item
{
    private JobLevel UnlocksLevel;

    public JobLevelItem(JobLevel jobLevel, int cost)
    {
        UnlocksLevel = jobLevel;
        Cost = cost;
        HappinessBoost = 0;
    }

    public override void ApplyEffect()
    {
        Character character = Character.GetInstance();

        if (UnlocksLevel == JobLevel.Ojek && character.JobLevel == JobLevel.TukangKayu)
        {
            character.JobLevel = JobLevel.Ojek;
            Console.WriteLine("You are now an Ojek driver! Your income has increased.");
        }
        else if (UnlocksLevel == JobLevel.Trader && character.JobLevel == JobLevel.Ojek)
        {
            character.JobLevel = JobLevel.Trader;
            Console.WriteLine("You are now a Trader! Your income has significantly increased.");
        }
        else
        {
            Console.WriteLine("You cannot upgrade to this job level yet.");
        }
    }

    public JobLevel GetJobLevel()
    {
        return UnlocksLevel;
    }

    public int GetIncome()
    {
        return UnlocksLevel switch
        {
            JobLevel.Ojek => 20,
            JobLevel.Trader => 40,
            _ => 0
        };
    }
}

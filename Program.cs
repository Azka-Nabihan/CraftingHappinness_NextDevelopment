using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = GameManager.Instance;
        BattleSystem battleSystem = new BattleSystem();

        // Regular items
        List<Item> regularItems = new List<Item>
        {
            new Makanan(),
            new Minuman(),
            new PS5(),
            new HangoutParty(),
            new NontonBioskopBarengBuWati()
        };

        // Job level items
        List<JobLevelItem> jobLevelItems = new List<JobLevelItem>
        {
            new JobLevelItem(JobLevel.Ojek, 50),
            new JobLevelItem(JobLevel.Trader, 100)
        };

        gameManager.StartGame();

        bool isRunning = true;

        while (isRunning)
        {
            if (Character.GetInstance().Wish >= 100)
            {
                Console.WriteLine("\nCongratulations! You have reached 100 wish. You win the game!");
                break;
            }

            gameManager.DisplayStatus();

            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Work");
            Console.WriteLine("2. Sleep");
            Console.WriteLine("3. Buy Regular Item");
            Console.WriteLine("4. Buy Job Upgrade");
            Console.WriteLine("5. Exit Game");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    battleSystem.StartActivity(new WorkActivity());
                    break;
                case "2":
                    battleSystem.StartActivity(new Sleep());
                    break;
                case "3":
                    BuyRegularItemMenu(regularItems);
                    break;
                case "4":
                    BuyJobUpgradeMenu(jobLevelItems);
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Exiting game...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid action.");
                    break;
            }

            Console.WriteLine("\n---\n");
        }
    }

    private static void BuyRegularItemMenu(List<Item> regularItems)
    {
        Character player = Character.GetInstance();

        Console.WriteLine("Available Regular Items:");
        for (int i = 0; i < regularItems.Count; i++)
        {
            Item item = regularItems[i];
            Console.WriteLine($"{i + 1}. {item.GetType().Name} - Cost: {item.Cost} wish, Happiness Boost: {item.HappinessBoost}, Stamina Boost: {item.StaminaBoost}");
        }

        Console.Write("Choose an item to buy (enter the number): ");
        if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= regularItems.Count)
        {
            Item selectedItem = regularItems[itemChoice - 1];

            if (player.CanBuyItem(selectedItem))
            {
                player.BuyItem(selectedItem);
                player.Inventory.UseItem(selectedItem);
            }
            else
            {
                Console.WriteLine("You don't have enough wish to buy this item.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Returning to main menu.");
        }
    }

    private static void BuyJobUpgradeMenu(List<JobLevelItem> jobLevelItems)
    {
        Character player = Character.GetInstance();

        Console.WriteLine("Available Job Upgrades:");
        for (int i = 0; i < jobLevelItems.Count; i++)
        {
            JobLevelItem item = jobLevelItems[i];
            Console.WriteLine($"{i + 1}. Unlock {item.GetJobLevel()} - Cost: {item.Cost} wish, Income: {item.GetIncome()} wish");
        }

        Console.Write("Choose a job upgrade to buy (enter the number): ");
        if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= jobLevelItems.Count)
        {
            JobLevelItem selectedItem = jobLevelItems[itemChoice - 1];

            if (player.CanBuyItem(selectedItem))
            {
                player.BuyItem(selectedItem);
                player.Inventory.UseItem(selectedItem);
            }
            else
            {
                Console.WriteLine("You don't have enough wish to buy this job upgrade.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Returning to main menu.");
        }
    }
}

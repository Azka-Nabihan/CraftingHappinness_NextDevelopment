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

        // NPCs
        List<NPC> npcs = new List<NPC>
        {
            new NPC("Pak Budi", new List<string> { "Selamat datang di desa kami!", "Semoga harimu menyenangkan." }, 3, 0),
            new NPC("Bu Ani", new List<string> { "Apakah kamu butuh bantuan?", "Saya selalu ada di sini jika kamu butuh sesuatu." }, 0, 5),
            new NPC("Pak Joko", new List<string> { "Saya punya cerita menarik untukmu.", "Dengarkan baik-baik." }, 5, 0)
        };

        // Diseases
        List<Disease> diseases = new List<Disease>
        {
            // public Disease(string name, int staminaReductionPercentage, int happinessReduction, double chance)
            new Disease("Flu", 10, 9, 0.1), // 10% chance to get flu
            new Disease("Batuk", 5, 4, 0.2)  // 20% chance to get batuk
        };

        gameManager.StartGame();

        bool isRunning = true;

        while (isRunning)
        {
            Character player = Character.GetInstance();

            if (player.Wish >= 100)
            {
                Console.WriteLine("\nCongratulations! You have reached 100 wish. You win the game!");
                break;
            }

            // Check if the character is too depressed
            if (player.Emotion == Emotion_Enum.Depressed) // Perubahan terkait Emotion
            {
                Console.WriteLine("\nPak Yon is too depressed and has taken his own life. Game Over."); // Perubahan terkait Emotion
                break;
            }

            gameManager.DisplayStatus();

            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Work");
            Console.WriteLine("2. Sleep");
            Console.WriteLine("3. Buy Regular Item");
            Console.WriteLine("4. Buy Job Upgrade");
            Console.WriteLine("5. Interact with NPC"); // Tambahkan opsi untuk berinteraksi dengan NPC
            Console.WriteLine("6. Exit Game");

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
                    InteractWithNPC(npcs); // Panggil metode untuk berinteraksi dengan NPC
                    break;
                case "6":
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
                player.UpdateEmotion(); // Perubahan terkait Emotion
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
                player.UpdateEmotion(); // Perubahan terkait Emotion1
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

    private static void InteractWithNPC(List<NPC> npcs) // Metode untuk berinteraksi dengan NPC
    {
        Console.WriteLine("Available NPCs:");
        for (int i = 0; i < npcs.Count; i++)
        {
            NPC npc = npcs[i];
            Console.WriteLine($"{i + 1}. {npc.Name}");
        }

        Console.Write("Choose an NPC to interact with (enter the number): ");
        if (int.TryParse(Console.ReadLine(), out int npcChoice) && npcChoice > 0 && npcChoice <= npcs.Count)
        {
            NPC selectedNPC = npcs[npcChoice - 1];
            Character player = Character.GetInstance();
            selectedNPC.Interact(player); // Panggil metode Interact dari NPC yang dipilih
        }
        else
        {
            Console.WriteLine("Invalid choice. Returning to main menu.");
        }
    }
}

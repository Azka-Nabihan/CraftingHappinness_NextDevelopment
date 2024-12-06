using System;
using System.Collections.Generic;

public class Disease
{
    private static Random random = new Random();

    public string Name { get; }
    public int StaminaReductionPercentage { get; }
    public int HappinessReduction { get; }
    public double Chance { get; }

    public Disease(string name, int staminaReductionPercentage, int happinessReduction, double chance)
    {
        Name = name;
        StaminaReductionPercentage = staminaReductionPercentage;
        HappinessReduction = happinessReduction;
        Chance = chance;
    }

    public void ApplyEffect(Character character)
    {
        character.Stamina -= (character.Stamina * StaminaReductionPercentage) / 100;
        character.HappinessIndex = Math.Max(-100, character.HappinessIndex - HappinessReduction);
        character.UpdateEmotion();
        Console.WriteLine($"Oh no! {Name} has struck! Your stamina has plummeted by {StaminaReductionPercentage}%, and your happiness has dropped by {HappinessReduction} points.");
    }

    public static bool TryInfect(Character character, List<Disease> diseases)
    {
        foreach (var disease in diseases)
        {
            double adjustedChance = disease.Chance;

            if (character.Emotion == Emotion_Enum.Happy)
            {
                adjustedChance *= 0.3;  // 30% less likely to get sick if happy
            } else if (character.Emotion == Emotion_Enum.Depressed)
            {
                adjustedChance *= 1.5;  // 50% more likely to get sick if depressed
            }

            if (random.NextDouble() < disease.Chance)
            {
                disease.ApplyEffect(character);
                return true;
            }
        }
        return false;
    }
}
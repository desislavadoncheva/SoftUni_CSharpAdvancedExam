using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadacha_1
{
    public class Program
    {
        public static void Main()
        {
            int[] inputIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputFreshness = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(inputIngredients);
            Stack<int> freshness = new Stack<int>(inputFreshness);
            List<string> readyCoctails = new List<string>();
            int countMimosa = 0;
            int countDaiquiri = 0;
            int countMojito = 0;
            int countSunshine = 0;
            while (ingredients.Count > 0 && freshness.Count > 0) 
            {
                int currentIngredient = ingredients.Peek();
                int currentFreshness = freshness.Peek();
                int totalFreshness = currentIngredient * currentFreshness;
                if (currentIngredient == 0) 
                {
                    ingredients.Dequeue();
                    continue;
                }
                if (totalFreshness == 150)
                {
                    readyCoctails.Add("Mimosa");
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 250)
                {
                    readyCoctails.Add("Daiquiri");
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 300)
                {
                    readyCoctails.Add("Sunshine");
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 400)
                {
                    readyCoctails.Add("Mojito");
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness != 150 && totalFreshness != 250 && totalFreshness != 300 && totalFreshness != 400)
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                    continue;
                }
            }
            if (readyCoctails.Count >= 4)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }
            if (ingredients.Any()) 
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var item in readyCoctails)
            {
                switch (item)
                {
                    case "Mimosa":
                        countMimosa += 1;
                        break;
                    case "Mojito":
                        countMojito += 1;
                        break;
                    case "Daiquiri":
                        countDaiquiri += 1;
                        break;
                    case "Sunshine":
                        countSunshine += 1;
                        break;
                    default:
                        break;
                }
            }
            if (countDaiquiri >= 1) 
            {
                Console.WriteLine($" # Daiquiri --> {countDaiquiri}");
            }
            if (countMimosa >= 1)
            {
                Console.WriteLine($" # Mimosa --> {countMimosa}");
            }
            if (countMojito >= 1)
            {
                Console.WriteLine($" # Mojito --> {countMojito}");
            }
            if (countSunshine >= 1)
            {
                Console.WriteLine($" # Sunshine --> {countSunshine}");
            }
        }
    }
}

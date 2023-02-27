﻿namespace AquariumAdventure
{
    using System.Text;

    public class Fish
    {
        public Fish(string name, string color, int fins)
        {
            this.Name = name;
            this.Color = color;
            this.Fins = fins;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public int Fins { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Fish: {this.Name}");
            stringBuilder.AppendLine($"Color: {this.Color}");
            stringBuilder.AppendLine($"Number of fins: {this.Fins}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}

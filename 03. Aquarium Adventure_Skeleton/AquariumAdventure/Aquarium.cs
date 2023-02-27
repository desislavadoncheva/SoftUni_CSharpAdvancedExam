namespace AquariumAdventure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.fishInPool = new List<Fish>();
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (!this.fishInPool.Contains(fish) && this.fishInPool.Count() < this.Capacity) 
            {
                this.fishInPool.Add(fish);
            }
        }
        public bool Remove(string name)
        {
            var fish = this.fishInPool.FirstOrDefault(x => x.Name == name);
            if (this.fishInPool.Contains(fish))
            {
                this.fishInPool.Remove(fish);
                return true;
            }
            return false;
        }

        public Fish FindFish(string name)
        {
            var fish = this.fishInPool.FirstOrDefault(x => x.Name == name);
            if (!this.fishInPool.Contains(fish))
            {
                return null;
            }
            return fish;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var fish in this.fishInPool)
            {
                stringBuilder.AppendLine(fish.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}

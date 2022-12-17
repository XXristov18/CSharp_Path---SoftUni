namespace ShoeStore
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class ShoeStore
    {
        private string name;
        private int storageCapacity;
        private List<Shoe> shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            this.shoes = new List<Shoe>();
        }

        public string Name { get => this.name; set => this.name = value; }
        public int StorageCapacity { get => this.storageCapacity; set => this.storageCapacity = value; }
        public List<Shoe> Shoes { get => this.shoes;}
        public int Count { get => this.Shoes.Count; }

        public string AddShoe(Shoe shoe)
        {
            if (this.Shoes.Count == this.StorageCapacity)
            {
                return $"No more space in the storage room.";
            }
            else
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
        }
        public int RemoveShoes(string material)
        {
            List<Shoe> shoes = this.Shoes.Where(s => s.Material == material).ToList();
            if (shoes.Count==0)
            {
                return shoes.Count;
            }
            foreach (Shoe shoe in shoes)
            {
                this.Shoes.Remove(shoe);
            }
            return shoes.Count;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoes = this.Shoes.Where(s => s.Type.ToLower() == type.ToLower()).ToList();
            return shoes;
        }
        public Shoe GetShoeBySize(double size)
        {
            return this.Shoes.FirstOrDefault(s => s.Size == size);
        }
        public string StockList(double size, string type)
        {
            string result = string.Empty;
            List<Shoe> shoes = this.Shoes.Where(s => s.Size == size && s.Type == type).ToList();
            if(shoes.Count==0)
            {
                result = $"No matches found!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach(Shoe shoe in shoes)
                {
                    sb.AppendLine(shoe.ToString());
                }

                result = sb.ToString().Trim();
            }

            return result;
        }

    }
}

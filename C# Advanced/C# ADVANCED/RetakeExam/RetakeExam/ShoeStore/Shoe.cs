namespace ShoeStore
{
    using System.Text;
    public class Shoe
    {
        private string brand;
        private string type;
        private double size;
        private string material;
        public Shoe(string brand, string type, double size, string material)
        {
            this.Brand = brand;
            this.Type = type;
            this.Size = size;
            this.Material = material;
        }

        public string Brand { get => this.brand;  set => this.brand = value; }
        public string Type { get => this.type; set => this.type = value; }
        public double Size { get => this.size; set => this.size = value; }
        public string Material { get => this.material; set => this.material = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Size {this.Size}, {this.Material} {this.Brand} {this.Type} shoe.");
            return sb.ToString().Trim();
        }

    }
}

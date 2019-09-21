namespace csharp
{
    public class Item
    {
        public Item() { }
        public Item(string name)
            : this(name, 0, 0) { }

        private Item(string name, int sellIn, int quality)
        {
            this.Name = name;
            this.SellIn = sellIn;
            this.Quality = quality;
        }
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }
}

namespace budgetApp.Models {
    public class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Priority { get; set; }
        public int Rise { get; set; } // likelyhood to rise.
    }
}
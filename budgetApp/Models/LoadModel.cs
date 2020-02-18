using System.Collections.Generic;

namespace budgetApp.Models {
    public class LoadModel
    {
        public string Mode { get; set; }
        public List<Item> Budget { get; set; }
    }
}
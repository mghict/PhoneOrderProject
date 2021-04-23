using System.Collections.Generic;

namespace WebSites.Panles.Models.Map
{
    public class ElementsData
    {
        public string Status { get; set; }
        public Data Duration { get; set; }
        public Data Distance { get; set; }
    }

    public class Element
    {
        public List<ElementsData> Elements { get; set; }
    }
}

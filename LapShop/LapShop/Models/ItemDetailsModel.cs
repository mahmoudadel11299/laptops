using Domains;

namespace LapShop.Models
{
    public class ItemDetailsModel
    {
        public List<TbItemImage> Items { get; set; }
        public Tbitem item { get; set; }
        public List<Tbitem> RecommendedItems { get; set; }
    }
}

namespace api.Models
{
    public class Comment
    {
       public int? StockId{ get; set; } 
       //navigation property
       public Stock? Stock{get;set;}
    }
}
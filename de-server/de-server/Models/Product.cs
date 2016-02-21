using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace de_server.Models
{
    public class Product
    {
        public int id;
        public string name;
        public string origin;
        public string quality;
        public specification specs;
        public Product()
        {
            specs = new specification();
        }

        public Product(int id, string name, string origin, string quality, int? purity, int? moisture, int? splits, int? weeviled, int? damaged, int? foreignMatter, int? greenDamaged, int? otherColor, int? wrinkled)
        {
            this.id = id;
            this.name = name;
            this.origin = origin;
            this.quality = quality;
            specs = new specification(purity, moisture, splits,weeviled, damaged,foreignMatter, greenDamaged, otherColor, wrinkled);
        }
      

    }

    public class specification
    {
        public int? purity;
        public int? moisture;
        public int? splits;
        public int? weeviled;
        public int? damaged;
        public int? foreignMatter;
        public int? greenDamaged;
        public int? otherColor;
        public int? wrinkled;

        public specification()
        {
            this.purity = 0;
            this.moisture = 0;
            this.splits = 0;
            this.weeviled = 0;
        }

        public specification(int? purity, int? moisture,int? splits,int? weeviled, int? damaged, int? foreignMatter, int? greenDamaged, int? otherColor, int? wrinkled){
            this.purity = purity;
            this.moisture = moisture;
            this.splits = splits;
            this.weeviled = weeviled;
            this.damaged = damaged;
            this.foreignMatter = foreignMatter;
            this.greenDamaged = greenDamaged;
            this.otherColor = otherColor;
            this.wrinkled = wrinkled;
        }
    }

    public class productQuality
    {
        public string text; 
       
        public productQuality(string text){
            this.text = text;
        }
    }

    public class productDetails
    {
        public int id;
        public string name;

        public productDetails(){

        }

        public productDetails(int id, string name){
            this.id = id;
            this.name = name;
        }
    }

    public class productLastTraded
    {
        public int? id;
        public DateTime? time;
        public productLastTraded(int? id, DateTime? time)
        {
            
            this.id = id;
            this.time = time;
        }
    }

    public class ProductListItem
    {
        public int id;
        public string name;
        public string quality;
        public string origin;
        public int? t_id;
        public DateTime? t_date;

        public ProductListItem(int id, string name, string quality, string origin, int? t_id, DateTime? t_date)
        {
            this.name = name;
            this.id = id;
            this.quality = quality;
            this.origin = origin;
            this.t_id = t_id;
            this.t_date = t_date;
        }

    }

    public class ProductTagInput
    {
        public int value;
        public string text;
        public string origin;
        public string quality;
        public ProductTagInput(int val, string text, string origin, string quality)
        {
            this.value = val;
            this.text = text;
            this.origin = origin;
            this.quality = quality;
        }
    }

    
    
    
}
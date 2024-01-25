using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ProductModel
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Remaining_Stock { get; set; } // Assuming you want this property as well
        public string Product_unit { get; set; }
        public int Alert_limit { get; set; } // Changed from double to int
        public string Add_by { get; set; }
        public DateTime Add_date { get; set; }
        public decimal Product_Price { get; set; } // Changed from double to decimal
        public string Price_Unit { get; set; }
        public DateTime Price_Update_date { get; set; }
        public string Update_By { get; set; }
    }

}

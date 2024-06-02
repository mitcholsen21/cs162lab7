using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace CustomerProductClasses
{
    [XmlType("Product")] // define Type
    [XmlInclude(typeof(Clothing)), XmlInclude(typeof(Gear))]
    // I added the keyword abstract.  Ignore the IComparable for now.
    public abstract class Product : IComparable<Product>
    {
        private int id;
        private string code;
        private string description;
        private decimal unitPrice;
        private int quantity;

        protected Product() { }

        protected Product(int productId, string productCode, string desc, decimal price, int qty)
        {
            id = productId;
            code = productCode;
            description = desc;
            unitPrice = price;
            quantity = qty;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
            }
        }

        public int QuantityOnHand
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Product other = (Product)obj;
                return other.Id == Id &&
                    other.Code == Code &&
                    other.Description == Description &&
                    other.UnitPrice == UnitPrice &&
                    other.QuantityOnHand == QuantityOnHand;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * id.GetHashCode() +
                7 * code.GetHashCode() +
                7 * description.GetHashCode() +
                7 * unitPrice.GetHashCode() +
                7 * quantity.GetHashCode();
        }

        public static bool operator ==(Product p1, Product p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Product p1, Product p2)
        {
            return !p1.Equals(p2);
        }

        #region Abstract Class changes

        // This now includes the ShippingCharge ... even though I didn't write it yet!!!
        // That's ok because I know it will be there for the other classes when I call it.
        public override string ToString()
        {
            return String.Format("Id: {0} Code: {1} Description: {2} UnitPrice: {3:C} Quantity: {4} Shipping: {5:C}",
                id, code, description, unitPrice, quantity, ShippingCharge);
        }

        // this FORCES classes that are derived from Product to write a read-only property ShippingCost
        public abstract decimal ShippingCharge
        {
            get;
        }
        // I could have written this as a method instead of a property getter
        // public abstract decimal CalculateShippingCost();

        #endregion

        #region Interface changes

        // this is the required method for IComparable
        // it compares 2 Products based on their code (I pulled that out of the air!)
        // CompareTo returns 0 when the 2 products are == for sorting purposes
        // a negative if this < other and a positive if this > other
        public int CompareTo(Product other)
        {
            return String.Compare(this.code, other.code, StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace CustomerProductClasses
{
    // This is for xml serialization.  Ignore it.
    [XmlType("Clothing")]
    // Clothing "is a" Product.  Inheritance relationship
    // Product is the base class.  Clothing is the derived class.
    public class Clothing: Product
    {
        // attributes that a clothing object will have
        // these are in addition to the attributes in a product object
        private string category;
        private string gender;
        private string size;
        private string color;
        private string brand;

        // constructor for a derived class should first call the constructor for the base class.
        // in C#, base is the keyword for the parent or base class
        public Clothing() : base() { }
        // note 10 parameters, 5 for product attributes and 5 more for clothing specific attributes
        public Clothing(int id, string code, string description, decimal price, int qty, 
                        string category, string gender, string size, string color, string brand) : 
                        base (id, code, description, price, qty)
        {
            // body of the constructor assigns only the clothing specific attributes
            // the keyword this is unnecessary here
            // note that the constructor is calling property setters
            this.Category = category;
            this.Gender = gender;
            this.Brand = brand;
            this.Size = size;
            this.Color = color;
        }

        // property procedures.  There's nothing new here.
        // Notice that a clothing object has 10 properties.   5 are defined in Product.
        // Only the clothing specific properties are defined here
        public string Category
        {
             get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }

        // Replace ToString in Product with this clothing specific version of ToString
        public override string ToString()
        {
            // BUT don't redo all of the work that's done in the Product class.  Just call the Product version
            // and concatenate the new stuff.
            return base.ToString() + 
                   String.Format("\nCategory: {0} Gender: {1} Size: {2} Color: {3} Brand: {4}", category, gender, size, color, brand);
        }
        
        // Replace version in Product with clothing specific version
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Clothing other = (Clothing)obj;
                // BUT call the product version as part of this implementation
                return base.Equals(other) &&
                    other.Category == Category &&
                    other.Gender == Gender &&
                    other.Size == Size &&
                    other.Color == Color &&
                    other.Brand == Brand;
            }
        }

        // Replace version in Product with clothing specific version
        public override int GetHashCode()
        {
            // BUT call the product version as part of this implementation
            return base.GetHashCode() + 7 * category.GetHashCode() +
                7 * gender.GetHashCode() +
                7 * size.GetHashCode() +
                7 * color.GetHashCode() +
                7 * brand.GetHashCode();
        }

        // here's the implementation of the abstract property getter.  Notice that the heading has to match exactly.
        // if you comment this property out, the code will not compile
        public override decimal ShippingCharge
        {
            get
            {
                return 1M;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace CustomerProductClasses
{
    // This is for xml serialization.  Ignore it.
    [XmlType("Gear")]
    // Gear "is a" Product.  Inheritance relationship
    // Product is the base class.  Gear is the derived class.
    public class Gear : Product
    {
        // attributes that a gear object will have
        // these are in addition to the attributes in a product object 
        // NOTE:  brand is in both Gear and Clothing.  Which means it probably should have been in Product.
        // I didn't want to change the Product implementation
        private string sport;
        private string brand;
        private string feature;
        private double weight;


        // constructor for a derived class should first call the constructor for the base class.
        // in C#, base is the keyword for the parent or base class
        public Gear() : base() { }
        // note 9 parameters, 5 for product attributes and 4 more for gear specific attributes
        public Gear(int id, string code, string description, decimal price, int qty,
                        string sport, string brand, string feature, double weight) :
                        base(id, code, description, price, qty)
        {
            // body of the constructor assigns only the gear specific attributes
            // the keyword this is unnecessary here
            // note that the constructor is calling property setters
            this.Sport = sport;
            this.Brand = brand;
            this.Feature = feature;
            this.Weight = weight;
        }

        // property procedures.  There's nothing new here.
        // Notice that a gear object has 9 properties.   5 are defined in Product.
        // Only the gear specific properties are defined here
        public string Sport
        {
            get
            {
                return sport;
            }
            set
            {
                sport = value;
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

        public string Feature
        {
            get
            {
                return feature;
            }
            set
            {
                feature = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        // Replace version in Product with gear specific version
        public override string ToString()
        {
            // BUT call the product version as part of this implementation
            return base.ToString() +
                   String.Format("\nSport: {0} Brand: {1} Feature: {2} Weight: {3:n2}", sport, brand, feature, weight);
        }

        // Replace version in Product with gear specific version
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Gear other = (Gear)obj;
                // BUT call the product version as part of this implementation
                return base.Equals(other) &&
                    other.Sport == Sport &&
                    other.Feature == Feature &&
                    other.Weight == Weight &&
                    other.Brand == Brand;
            }
        }

        // Replace version in Product with gear specific version
        public override int GetHashCode()
        {
            // BUT call the product version as part of this implementation
            return base.GetHashCode() + 7 * sport.GetHashCode() +
                7 * brand.GetHashCode() +
                7 * feature.GetHashCode() +
                7 * weight.GetHashCode();
        }

        // here's the implementation of the abstract property getter.  Notice that the heading has to match exactly.
        // if you comment this property out, the code will not compile
        public override decimal ShippingCharge
        {
            get
            {
                return 1M * (decimal)Weight;
            }
        }
    }
}

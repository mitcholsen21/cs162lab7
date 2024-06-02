using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    // Nothing in this class has changed
    public class ProductList : IEnumerable<Product>
    {
        // polymorphism - can contain product, clothing or gear objects
        private List<Product> products;

        public ProductList()
        {
            products = new List<Product>();
        }

        public int Count
        {
            get
            {
                return products.Count;
            }
        }

        public void Fill()
        {
            products = ProductDB.GetProducts();
        }

        public void Save()
        {
            ProductDB.SaveProducts(products);
        }

        public void Sort()
        {
            products.Sort();
        }

        // polymorphism.  Can pass a product, clothing or gear object
        public void Add(Product product)
        {
            products.Add(product);
        }

        // this method is probably not appropriate at this point.  All products have these 5 attributes.
        // BUT clothing and gear have more.  Better to just add an object.
        /*
        public void Add(int id, string code, string description, decimal price, int quantity)
        {
            Product p = new Product(id, code, description, price, quantity);
            products.Add(p);
        }
        */

        // polymorphism.  Can pass a product, clothing or gear object
        public void Remove(Product product)
        {
            products.Remove(product);
        }

        public override string ToString()
        {
            string output = "";
            // polymorphism.  Can be a product, clothing or gear object
            foreach (Product p in products)
            {
                // calls the correct version of ToString depending on the kind of object
                output += p.ToString() + "\n";
            }
            return output;
        }

        // polymorphism.  Can return a product, clothing or gear object
        public Product this[int i]
        {
            get
            {
                return products[i];
            }
            set
            {
                products[i] = value;
            }
        }

        public Product this[string code]
        {
            get
            {
                foreach (Product p in products)
                {
                    if (p.Code == code)
                        return p;
                }
                return null;
            }
        }

        public static ProductList operator +(ProductList pl, Product p)
        {
            pl.Add(p);
            return pl;
        }

        public static ProductList operator +(Product p, ProductList pl)
        {
            pl.Add(p);
            return pl;
        }

        public static ProductList operator -(ProductList pl, Product p)
        {
            pl.Remove(p);
            return pl;
        }

        public static ProductList operator -(ProductList pl, int count)
        {
            for (int i = 1; i <= count; i++)
                pl.products.RemoveAt(0);
            return pl;
        }

        #region Abstract Classes changes

        // this is a new property.  It illustrates the use of the abstract property ShippingCharge
        public decimal ShippingCharge
        {
            get
            {
                decimal total = 0;
                foreach (Product p in products)
                    // this won't work unless ALL classes implement shippingcharge
                    total += p.ShippingCharge;

                return total;

            }
        }

        #endregion

        #region Interface changes

        public IEnumerator<Product> GetEnumerator()
        {
            return ((IEnumerable<Product>)products).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Product>)products).GetEnumerator();
        }

        #endregion
    }
}

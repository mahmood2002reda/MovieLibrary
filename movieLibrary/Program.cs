using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieLibrary ml = new MovieLibrary(100);
            ml.addProductlocal();
            
        }
    }

    abstract class Product
    {
        public string name;
        public int quantity;
        public string description;
        public float sellPrice;
        public float purchasePrice;

        public Product(string name, int quantity, string description, float sellPrice, float purchasePrice)
        {
            this.name = name;
            this.quantity = quantity;
            this.description = description;
            this.sellPrice = sellPrice;
            this.purchasePrice = purchasePrice;
        }

        public float PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                if (value > 0)
                {
                    purchasePrice = value;
                }
                else
                {
                    throw new Exception("Purchase price must be greater than zero.");
                }
            }
        }
        public abstract float ReturnTotalCost();
    }

    class LocalMovie : Product
    {
        public LocalMovie(string name, int quantity, string description, float sellPrice, float purchasePrice)
            : base(name, quantity, description, sellPrice, purchasePrice)
        {
        }

        public override float ReturnTotalCost()
        {
            return purchasePrice * 0.5f;
        }
    }

    class ImportedMovie : Product
    {
        public ImportedMovie(string name, int quantity, string description, float sellPrice, float purchasePrice)
            : base(name, quantity, description, sellPrice, purchasePrice)
        {
        }

        public override float ReturnTotalCost()
        {
            return purchasePrice * 0.2f;
        }
    }

    class MovieLibrary
    {
        private Product[] allProduct;
        private static int count = 0;

        public MovieLibrary(int size)
        {
            allProduct = new Product[size];
        }

        public Product this[int index]
        {

            set
            {
                foreach (Product item in allProduct)
                {
                    if ((item.name == value.name))
                    {
                        if (!(index < count))
                        {
                            allProduct[index].quantity++;
                        }
                        else
                        {
                            Console.WriteLine("failed!");
                        }
                    }

                    else
                    {
                        allProduct[index] = value;
                        count++;
                    }
                }


            }
            get
            {
                if (index < count)
                {
                    return allProduct[index];
                }
                else
                {
                    return null;
                }
            }
        }
        public bool CheckExistence(Product prod)
        {
            bool flag = false;
            for (int i = 0; i < allProduct.Length; i++)
            {
                if (allProduct[i].name == prod.name)
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }
        public bool checkexistence(string name, out Product prod, out int index)
        {
            bool flag = false;
            for (int i = 0; i < allProduct.Length; i++)
            {
                if (allProduct[i].name == name)
                {
                    flag = true;
                    prod = allProduct[i];
                    index = i;
                    return flag;
                }
            }
            prod = null;
            index = -1;
            return flag;
        }

       
        

        public void updateproduct(string name, int quantity, string description, float sellprice, float purprice)
        {
            Product prod;
            int index;
            if (checkexistence(name, out prod, out index))
            {
                if (prod != null)
                {
                    allProduct[index].quantity = quantity;
                    allProduct[index].description = description;
                    allProduct[index].sellPrice = sellprice;
                    allProduct[index].purchasePrice = purprice;
                    Console.WriteLine("moive edited successfully....");
                }
                else
                {
                    Console.WriteLine("moive not edited successfully....");
                }
            }
        }
        private void addProduct(string name, int quantity, string description, float sellPrice, float purchasePrice)
        {
            if (count < allProduct.Length)
            {
                allProduct[count] = new LocalMovie(name, quantity, description, sellPrice, purchasePrice);
                count++; //pointer to last item added in array;
                Console.WriteLine("Product added successfully");
            }
            else
            {
                Console.WriteLine("Product array is full");
            }
        }
        public void addProductlocal()
        {
            Console.WriteLine("Please enter the moive name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the moive quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the moive type:");
            string description = Console.ReadLine();
            Console.WriteLine("Please enter the sell price of the moive:");
            float sellPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the purchase price of the moive:");
            float purchasePrice = float.Parse(Console.ReadLine());
            LocalMovie local = new LocalMovie(name, quantity, description, sellPrice, purchasePrice);
            addProduct(local.name, local.quantity, local.description, local.sellPrice, local.PurchasePrice);
        }
        public void addProductImported()
        {

            Console.WriteLine("Please enter the moive name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the moive quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the moive type:");
            string description = Console.ReadLine();
            Console.WriteLine("Please enter the sell price of the moive:");
            float sellPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the purchase price of the moive:");
            float purchasePrice = float.Parse(Console.ReadLine());
            ImportedMovie imported = new ImportedMovie(name, quantity, description, sellPrice, purchasePrice);
            addProduct(imported.name, imported.quantity, imported.description, imported.sellPrice, imported.PurchasePrice);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp10
{
    public class Product
    {
        public int price; 
        public int id;
        public int amount; 
        public Product(int id, int price, int amount)
        {
            this.price = price;
            this.id = id;
            this.amount = amount;
        }

        public void Print()
        {
            Console.WriteLine("Идентификатор продукта: " + id + ", цена: "+ price + ", количество:" + amount);
        }
        public void NewId(int id)
        {
            this.id = id;
        }
        public void NewPrice(int price)
        {
            this.price = price;
        }
        public void NewAmount(int amount)
        {
            this.amount = amount;
        }
       
    }
    public class Inventory
    {
        private List<Product> prod;
        Product pr;
        public Inventory()
        {
            prod = new List<Product>();
        }
        //public void Sum()
        //{
        //    //foreach (var m in prod){
        //        List<decimal> pro = new List<decimal>(pr.price);
        //        decimal sum = pro.Sum();
        //        Console.WriteLine("Общая стоимость: " + sum);
        //    //}
        //    //for (int i = 0; i < prod.Count; i++)
        //    //{
        //    //    sum = sum + pr.price;
        //    //}
        //}
        public void Add(Product product)
        {
            prod.Add(product);
        }
        public void Print()
        {
            foreach (var m in prod)
            {
                m.Print();
            }
        }
        public void Delete(int id)
        {
            prod.RemoveAll(prod => prod.id == id);

        }
        public void ChangeId(int id, int newId)
        {
            Product finded = prod.Find(prod => prod.id == id);
            finded.NewId(newId);
        }
        public void ChangePrice(int id, int newPr)
        {
            Product finded = prod.Find(prod => prod.id == id);
            finded.NewPrice(newPr);
        }
        public void ChangeAmount(int id, int newAm)
        {
            Product finded = prod.Find(prod => prod.id == id);
            finded.NewAmount(newAm);
        }
        public void Find(int id)
        {
            Product finded = prod.Find(prod => prod.id == id);
            finded.Print();
        }
        public void FindPrice(int price)
        {
            List<Product> newList = prod.FindAll(prod => prod.price == price);
            foreach (var m in newList)
            {
                m.Print();
            }
        }
        public void FindAmount(int amount)
        {
            List<Product> newList = prod.FindAll(prod => prod.amount == amount);
            foreach (var m in newList)
            {
                m.Print();
            }
        }
        public void SortId()
           {
            prod.Sort((a, b) => a.id.CompareTo(b.id));
            foreach (var m in prod)
            {
                m.Print();
            }
        }
        public void SortPr()
        {
            prod.Sort((a, b) => a.price.CompareTo(b.price));
            foreach (var m in prod)
            {
                m.Print();
            }
        }
        public void SortAm()
        {
            prod.Sort((a, b) => a.amount.CompareTo(b.amount));
            foreach (var m in prod)
            {
                m.Print();
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Inventory inv = new Inventory();
            Product prod;
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Добавить товар");
                Console.WriteLine("2 - Изменить");
                Console.WriteLine("3 - Удалить");
                Console.WriteLine("4 - Поиск");
                Console.WriteLine("5 - Сортировать");
                //Console.WriteLine("6 - Общая стоимость");
                Console.WriteLine("6 - Показать список товаров");
                int r = Convert.ToInt32(Console.ReadLine());
                switch(r)
                {
                    case 1:
                        Console.WriteLine("Введите идентификатор: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите цену: ");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите количество: ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        Product pro = new Product(id, price, amount);
                        inv.Add(pro);
                        break;
                    case 2:
                        Console.WriteLine("Введите идентификатор товара, данные которого вы хотите изменить: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        inv.Find(id1);
                        //Console.WriteLine("Введите новый идентификатор товара: ");
                        //int newid = Convert.ToInt32(Console.ReadLine());
                        //inv.ChangeId(id1, newid);
                        Console.WriteLine("Введите новую цену товара: ");
                        int pr1 = Convert.ToInt32(Console.ReadLine());
                        inv.ChangePrice(id1, pr1);
                        Console.WriteLine("Введите новое количество товара: ");
                        int am = Convert.ToInt32(Console.ReadLine());
                        inv.ChangeAmount(id1, am);
                        inv.Find(id1);
                        break;
                    case 3:
                        Console.WriteLine("Введите идентификатор товара, который хотите удалить: ");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        inv.Delete(id2);
                        break;
                    case 4:
                        Console.WriteLine("Поиск по: 1 - идентификатору, 2 - цене, 3 - количеству");
                        int num = Convert.ToInt32(Console.ReadLine());
                        switch(num)
                        {
                            case 1:
                                Console.WriteLine("Введите идентификатор искомого товара: ");
                                int id3 = Convert.ToInt32(Console.ReadLine());
                                inv.Find(id3);
                                break;
                            case 2:
                                Console.WriteLine("Введите цену искомого(-ых) товара(-ов): ");
                                int pr2 = Convert.ToInt32(Console.ReadLine());
                                inv.FindPrice(pr2);
                                break;
                            case 3:
                                Console.WriteLine("Введите количество искомого(-ых) товара(-ов): ");
                                int am2 = Convert.ToInt32(Console.ReadLine());
                                inv.FindAmount(am2);
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Сортировка по: 1 - идентификатору, 2 - цене, 3 - количеству");
                        int n = Convert.ToInt32(Console.ReadLine());
                        switch (n)
                        {
                            case 1:
                                inv.SortId();
                                break;
                            case 2:
                                inv.SortPr();
                                break;
                            case 3:
                                inv.SortAm();
                                break;
                        }
                        break;
                    //case 6:
                    //    inv.Sum();
                    //    break;
                    case 6:
                        inv.Print();
                        break;
                }

            }
        }
    }
}

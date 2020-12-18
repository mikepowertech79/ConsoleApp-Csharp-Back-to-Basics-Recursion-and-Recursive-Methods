using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Csharp_Back_to_Basics___Recursion_and_Recursive_Methods
{

    //Source https://code-maze.com/csharp-basics-recursion/
    class Program
    {
        public static int CalculateSumRecursively(int n, int m)
        {
            int sum = n;
            if (n < m)
            {
                n++;
                return sum = sum + CalculateSumRecursively(n, m);
            }

            return sum;
        }




        public static int CountDivisions(double number)
        {
            int count = 0;
            if (number > 0 && number % 2 == 0)
            {
                count++;
                number /= 2;
                return count += CountDivisions(number);
            }
            return count;
        }

        static void Main(string[] args)
        {
           





            Store s = new Store();

            Console.WriteLine(
                "Welcome to the car store. First you must create some car inventory. Then you may add some cars to the shopping cart. Finally you may checkout which will give you a total value of the shopping cart \n");

            int action = chooseAction();

            while (action != 0)
            {
                Console.WriteLine("You chose " + action);

                switch (action)
                {




                    case 4:

                        Console.WriteLine("Enter number n: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter number m: ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        int sum = CalculateSumRecursively(n, m);
                        Console.WriteLine(sum);


                        break;



                    case 5:

                        
                        Console.WriteLine("Enter your number: ");
                        double number = Convert.ToDouble(Console.ReadLine());
                        int count = CountDivisions(number);
                        Console.WriteLine($"Total number of divisions: {count}");

                        break;





                    //add item to inventory
                    case 1:
                        Console.WriteLine("You choose to add a new car to the inventory ");
                        string carMake = "";
                        string carModel = "";
                        Decimal carPrice = 0;

                        Console.WriteLine("What is the car make? ford, gm, nissan etc. ");
                        carMake = Console.ReadLine();

                        Console.WriteLine("What is the car model? corvette, focus, ranger etc. ");
                        carModel = Console.ReadLine();

                        Console.WriteLine(("What is the car price? "));
                        carPrice = int.Parse(Console.ReadLine());

                        Car newCar = new Car(carMake, carModel, carPrice);
                        s.CarList.Add(newCar);

                        printInventory(s);
                        break;


                    case 2:
                        Console.WriteLine("You choose to add a car to your shopping cart ");
                        printInventory(s);
                        Console.WriteLine("Which item would you like to buy? (number) ");


                        int carChosen = int.Parse(Console.ReadLine());


                        if (s.CarList.Count! > carChosen)
                        {
                            s.ShoppingList.Add(s.CarList[carChosen]);

                            printShoppingCart(s);
                        }
                        else
                        {
                            Console.WriteLine("No such car in the Car List");
                        }

                        //Denis found https://docs.microsoft.com/ru-ru/dotnet/api/system.argumentoutofrangeexception?view=netcore-3.1#code-try-4

                        //try
                        //{
                        //    Console.WriteLine("The first item: '{0}'", list[0]);
                        //}
                        //catch (ArgumentOutOfRangeException e)
                        //{
                        //    Console.WriteLine(e.Message);
                        //}


                        break;


                    case 3:
                        printShoppingCart(s);
                        Console.WriteLine("The total cost of your items is : " + s.Checkout());

                        break;

                    default:
                        break;
                }


                action = chooseAction();





            }


            
        }








        private static void printShoppingCart(Store s)
        {
            Console.WriteLine("Cars you have chosen to buy ");
            for (int i = 0; i < s.ShoppingList.Count; i++)
            {
                Console.WriteLine("ShoppingList #: " + i + " " + s.ShoppingList[i]);
            }
        }

        private static void printInventory(Store s)
        {
            for (int i = 0; i < s.CarList.Count; i++)
            {
                Console.WriteLine("CarList #: " + i + " " + s.CarList[i]);

            }
        }

        static public int chooseAction()
        {
            int choice = 0;
            Console.WriteLine(
                "Choose an action (0) to quit (1) to add a new car to inventory (2) add car to cart (3) checkout \n" +
                "OR   (4) for Application which calculates the sum of all the numbers from n to m recursively   (Recursive Methods in C# Source Code) \n" +
                "and  (5) for Application which prints out how many times the number can be divided by 2 evenly (Recursive Methods in C# Source Code) \n");

            choice = int.Parse(Console.ReadLine());
            return choice;
        }


        public class Store
        {
            public List<Car> CarList { get; set; }
            public List<Car> ShoppingList { get; set; }

            public Store()
            {
                CarList = new List<Car>();
                ShoppingList = new List<Car>();
            }

            public decimal Checkout()
            {
                // initialize the total cost
                decimal totalCost = 0;

                foreach (var c in ShoppingList)
                {
                    totalCost = totalCost + c.Price;
                }
                ShoppingList.Clear();
                return totalCost;
            }

        }

        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public decimal Price { get; set; }



            public Car()
            {
                Make = "nothing yet ";
                Model = "nothing yet "; ;
                Price = 0.00M;
            }


            public Car(string a, string b, decimal c)
            {
                Make = a;
                Model = b;
                Price = c;
            }


            override public string ToString()
            {
                return " Make: " + Make + " Model " + Model + " Price: $ " + Price;
            }

        }

    }
}


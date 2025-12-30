using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using umlproject;

namespace umlproject
{
    abstract class User
    {
        public string User_ID { get; set; }
        public string Name { get; set; }

        public User(string user_ID, string name)
        {
            this.User_ID = user_ID;
            this.Name = name;
        }
    }

    class Student : User
    {
        List<string> Registered_Courses;

        public Student(string user_ID, string name, List<string> regestird_courses)
            : base(user_ID, name)
        {
            this.Registered_Courses = regestird_courses;
        }

        public List<string> GetRegestirdCourses()
        {
            return Registered_Courses;
        }

        public void AddCourse(string course)
        {
            Registered_Courses.Add(course);
        }

        public void Remove_Course(string course)
        {
            Registered_Courses.Remove(course);
        }

        public void Display_Courses()
        {
            Console.WriteLine("Regestird Courses:");
            foreach (var course in Registered_Courses)
            {
                Console.WriteLine(course);
            }
        }

        public override string ToString()
        {
            return $"{User_ID},{Name},{string.Join(";", Registered_Courses)}";
        }
    }

    class Faculty_member : User
    {
        List<string> Taught_Courses;

        public Faculty_member(string user_ID, string name, List<string> taught_courses)
            : base(user_ID, name)
        {
            Taught_Courses = taught_courses;
        }

        public List<string> Get_Taught_Courses()
        {
            return Taught_Courses;
        }

        public void Add_Taught_Course(string course)
        {
            Taught_Courses.Add(course);
        }

        public void Remove_Taught_Course(string course)
        {
            Taught_Courses.Remove(course);
        }

        public void Display_Taught_Courses()
        {
            Console.WriteLine("Taught Courses:");
            foreach (var course in Taught_Courses)
            {
                Console.WriteLine(course);
            }
        }

        public override string ToString()
        {
            return $"{User_ID},{Name},{string.Join(";", Taught_Courses)}";
        }
    }

    class Card
    {
        public int Card_Number { get; set; }
        public double Balance { get; set; }
        public string Status { get; set; }
        public string User_ID { get; set; }
        public string Type { get; set; }

        public Card(int card_number, double balance, string status, string user_id, string type)
        {
            Card_Number = card_number;
            Balance = balance;
            Status = status;
            User_ID = user_id;
            Type = type;
        }

        public bool Is_Blocked()
        {
            return Status.ToLower() == "blocked";
        }

        public void recharge(double amount)
        {
            Balance += amount;
        }

        public bool deduct(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Display_Card_Info()
        {
            Console.WriteLine("=== Card Information ===");
            Console.WriteLine($"Card Number: {Card_Number}");
            Console.WriteLine($"Balance: {Balance} JD");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"User ID: {User_ID}");
            Console.WriteLine("========================");
        }

        public override string ToString()
        {
            return $"{Card_Number},{Balance},{Status},{User_ID},{Type}";
        }
    }

    class Transaction
    {
        public string Transaction_ID { get; set; }
        public int Card_Number { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }

        public Transaction(string transaction_ID, int card_number, string type, double amount, string date)
        {
            Transaction_ID = transaction_ID;
            Card_Number = card_number;
            Type = type;
            Amount = amount;
            Date = date;
        }

        public void Display_Transaction()
        {
            string amountStr = Amount != 0 ? Amount.ToString() : "N/A";
            Console.WriteLine($"ID: {Transaction_ID} | Card: {Card_Number} | Type: {Type} | Amount: {amountStr}");
        }

        public override string ToString()
        {
            string amountStr = Amount != 0 ? Amount.ToString() : "N/A";
            return $"{Transaction_ID},{Card_Number},{Type},{amountStr}";
        }
    }

    class Attendance
    {
        public string Course_ID { get; set; }
        public string Date { get; set; }
        List<string> Attendees;

        public Attendance(string course_ID, string date)
        {
            Course_ID = course_ID;
            Date = date;
           Attendees = new List<string>();
        }

        public void Add_Attendee(string user_id)
        {
            Attendees.Add(user_id);
        }

        public void Remove_Attendee(string user_id)
        {
            Attendees.Remove(user_id);
        }

        public void Display_Attendees()
        {
            Console.WriteLine($"Course: {Course_ID} | Date: {Date}");
            Console.WriteLine($"Attendees: {string.Join(", ", Attendees)}");
            Console.WriteLine($"Total: {Attendees.Count} students");
        }

        public override string ToString()
        {
            return $"{Course_ID},{Date},{string.Join(";", Attendees)}";
        }
    }

    class Cafeteria_Service
    {
        Dictionary<string, double> Menu;

        public Cafeteria_Service()
        {
            Menu = new Dictionary<string, double>
            {
                { "Steak", 8 },
                { "Soup", 2 },
                { "Sandwich", 3 },
                { "Salad", 4 },
                { "Tea", 2 },
                { "Juice", 3 },
                { "Cake", 5 },
                { "Water", 1 }
            };
        }

        public void Display_Menu()
        {
            Console.WriteLine("\n=== Cafeteria Menu ===");
            int count = 1;
            foreach (var item in Menu)
            {
                Console.WriteLine($"{count}. {item.Key}: {item.Value} JD");
                count++;
            }
            Console.WriteLine("======================");
        }

        public double Calculate_Total(List<string> items)
        {
            double total = 0;
            foreach (var item in items)
            {
                if (Menu.ContainsKey(item))
                {
                    total += Menu[item];
                }
            }
            return total;
        }

        public List<string> Get_Menu_Items()
        {
            return new List<string>(Menu.Keys);
        }
    }

    class Bus_Service
    {
        public string Track_1_Origin { get; set; }
        public string Track_1_Destination { get; set; }
        public double Track_1_Cost { get; set; }

        public string Track_2_Origin { get; set; }
        public string Track_2_Destination { get; set; }
        public double Track_2_Cost { get; set; }

        public string Track_3_Origin { get; set; }
        public string Track_3_Destination { get; set; }
        public double Track_3_Cost { get; set; }

        public Bus_Service()
        {
            Track_1_Origin = "main gate";
            Track_1_Destination = "Northern buildings";
            Track_1_Cost = 3;

            Track_2_Origin = "main gate";
            Track_2_Destination = "Southern buildings";
            Track_2_Cost = 4;

            Track_3_Origin = "main gate";
            Track_3_Destination = "Library";
            Track_3_Cost = 5;
        }

        public void DisplayTracks()
        {
            Console.WriteLine("\n=== BUS TRACKS ===");
            Console.WriteLine("1) " + Track_1_Origin + "  " + Track_1_Destination + " | Cost: " + Track_1_Cost + " JD");
            Console.WriteLine("2) " + Track_2_Origin + "  " + Track_2_Destination + " | Cost: " + Track_2_Cost + " JD");
            Console.WriteLine("3) " + Track_3_Origin + "  " + Track_3_Destination + " | Cost: " + Track_3_Cost + " JD");
            Console.WriteLine("==================");
        }

        public double Get_Track_Cost(int choice)
        {
            switch (choice)
            {
                case 1: return Track_1_Cost;
                case 2: return Track_2_Cost;
                case 3: return Track_3_Cost;
                default: return 0;
            }
        }

        public string GetT_rack_Info(int choice)
        {
            switch (choice)
            {
                case 1: return Track_1_Origin + "  " + Track_1_Destination;
                case 2: return Track_2_Origin + "  " + Track_2_Destination;
                case 3: return Track_3_Origin + "  " + Track_3_Destination;
                default: return "Invalid Track";
            }
        }
    }

    class Car_Parking
    {
        public void Display_Rates()
        {
            Console.WriteLine("\n=== Car Parking Rates ===");
            Console.WriteLine("[1] first hour: 5 JD\n[2] second hour: 4 JD\n[3] third hour: 3 JD\n[4] fourth hour: 2 JD\n[5] fivth hour: 1 JD\n[6] above 5 hours for free");
            Console.WriteLine("=========================");
        }

        public double Calculate_Cost(int Hours)
        {
            double Cost = 0;
            while (Hours > 0)
            {
                switch (Hours)
                {
                    case 1: Cost += 5; break;
                    case 2: Cost += 4; break;
                    case 3: Cost += 3; break;
                    case 4: Cost += 2; break;
                    case 5: Cost += 1; break;
                }
                Hours--;
            }
            return Cost;
        }
    }

    class System_manger
    {
        // 🔹 شحن الكرت
        public void Recharge_Card(Card card, double amount)
        {
            if (card.Is_Blocked())
            {
                Console.WriteLine("Card is blocked, cannot recharge.");
                return;
            }

            card.recharge(amount);

            Transaction t = new Transaction(
                "TR" + DateTime.Now.Ticks,
                card.Card_Number,
                "recharge",
                amount,
                DateTime.Now.ToString()
            );

            t.Display_Transaction();
        }

        // 🔹 الدفع (كافتيريا – باص – مواقف)
        public void Make_Payment(Card card, double amount, string serviceType)
        {
            if (card.Is_Blocked())
            {
                Console.WriteLine("Card is blocked, payment denied.");
                return;
            }

            if (card.deduct(amount))
            {
                Transaction t = new Transaction(
                    "TR" + DateTime.Now.Ticks,
                    card.Card_Number,
                    serviceType,
                    amount,
                    DateTime.Now.ToString() 
                );

                t.Display_Transaction();
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        // 🔹 تسجيل حضور
        public void Register_Attendance(Card card)
        {
            if (card.Is_Blocked())
            {
                Console.WriteLine("Card is blocked, attendance not recorded.");
                return;
            }

            Transaction t = new Transaction(
                "TR" + DateTime.Now.Ticks,
                card.Card_Number,
                "attendance",
                0, // N/A
                DateTime.Now.ToString()
            );

            t.Display_Transaction();
        }

        // 🔹 حظر الكرت
        public void Block_Card(Card card)
        {
            card.Status = "blocked";
            Console.WriteLine("Card has been blocked.");
        }

        // 🔹 فك الحظر
        public void Unblock_Card(Card card)
        {
            card.Status = "active";
            Console.WriteLine("Card has been unblocked.");
        }

        // 🔹 عرض معلومات الكرت
        public void Display_Card(Card card)
        {
            card.Display_Card_Info();
        }
    }
    class File_manager { }

    internal class Program
    {
        static void Main(string[] args)
        {
            Car_Parking cp = new Car_Parking();
            cp.Display_Rates();
            double total_cost = cp.Calculate_Cost(324);
            Console.WriteLine($"Total parking cost: {total_cost} JD");
        }
    }
}

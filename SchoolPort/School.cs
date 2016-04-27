using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolPort
{
    public class School
    {
        string[] adminData;
        bool loginCheck = false;
        bool student = false;
        public void Start()
        {
            AskForLoginDisplay();
        }

        public void CheckLogin()
        {
            string[] Data = File.ReadAllLines("Data.txt", Encoding.Default);
            var f = Data[0].Split(',');
            adminData = f;
        }

        public void AskForLoginDisplay()
        {
            Console.WriteLine("Användarnamn:");
            var username = Console.ReadLine();

            Console.WriteLine("Lösenord:");
            var password = Console.ReadLine();
            AskForLogin(username, password);
            if(loginCheck == true)
            {
                Console.Clear();
                MenuDisplay();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("SOMETHING WENT WRONG");
                AskForLoginDisplay();
            }
        }

        public bool AskForLogin(string user, string pass)
        {
            CheckLogin();
            if (adminData[0] == user && adminData[1] == pass)
            {
                loginCheck = true;   
            }
            else
            {
                loginCheck = false;
            }
            
            return loginCheck;
        }

        private void MenuDisplay()
        {
            Console.WriteLine("1: Lärare");
            Console.WriteLine("2: Kurs");
            Console.WriteLine("3: Klass");
            Console.WriteLine("4: Elev");


            Console.WriteLine("Välj ett nr!");

            var value = Console.ReadLine();
            int x = 0;
            Int32.TryParse(value, out x);
            if (x != 0)
            {
                Menu(x);
            }
            
            Console.Clear();
        }

        public int Menu(int value)
        {
            int valuex = 0;
            if(value < 5 && 0 < value)
            {
                valuex = value;
            } 
            return valuex;
        }
    }
}
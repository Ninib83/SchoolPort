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
        List<string> DataList = new List<string>();
        List<string[]> DataListArray = new List<string[]>();
        List<string[]> AdministratiorList = new List<string[]>();
        List<string[]> TeacherList = new List<string[]>();
        List<string[]> CourseList = new List<string[]>();
        List<string[]> ClassList = new List<string[]>();
        List<string[]> StudentList = new List<string[]>();
        public void Start()
        {
            GetData();
            SplitData();
            AskForLoginDisplay();
        }
        public void GetData()
        {
            string[] Data = File.ReadAllLines("Data.txt", Encoding.Default);
            foreach (var item in Data)
            {
                DataList.Add(item);
            }
        }
        public void SplitData()
        {
            foreach (var firstItem in DataList)
            {
                var splitFirst = firstItem.Split('|');
                foreach (var item in splitFirst)
                {
                    if (splitFirst[0] == "Administrator")
                    {
                        AdministratiorList.Add(item.Split(','));
                    }
                    else if (splitFirst[0] == "Teacher")
                    {
                        TeacherList.Add(item.Split(','));
                    }
                    else if (splitFirst[0] == "Course")
                    {
                        CourseList.Add(item.Split(','));
                    }
                    else if (splitFirst[0] == "Class")
                    {
                        ClassList.Add(item.Split(','));
                    }
                    else if (splitFirst[0] == "Student")
                    {
                        StudentList.Add(item.Split(','));
                    }
                    
                }
            }
        }

        public string[] CheckLogin()
        {
            //string[] Data = File.ReadAllLines("Data.txt", Encoding.Default);
            //var f = Data[0].Split(',');
            //adminData = f;
            string[] adminList = new string[2];
            
            adminList[0] = AdministratiorList[1][0];
            adminList[1] = AdministratiorList[1][1];
            

            return adminList;
        }

        public void AskForLoginDisplay()
        {
            Console.WriteLine("Användarnamn:");
            var username = Console.ReadLine();

            Console.WriteLine("Lösenord:");
            var password = Console.ReadLine();
            var askForLoginBool = AskForLogin(username, password);
            if(askForLoginBool == true)
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
            bool loginBool = false;
            var adminData = CheckLogin();
            if (adminData[0] == user && adminData[1] == pass)
            {
                loginBool = true;   
            }
            else
            {
                loginBool = false;
            }
            
            return loginBool;
        }

        private void MenuDisplay()
        {
            Console.WriteLine("1: Lärare");
            Console.WriteLine("2: Kurs");
            Console.WriteLine("3: Klass");
            Console.WriteLine("4: Elev");


            Console.WriteLine("Välj ett nr!");

            var value = Console.ReadLine();
            var isNumber = Regex.IsMatch(value, @"^\d+$");
            if (isNumber != false)
            {
                int x = 0;
                Int32.TryParse(value, out x);
                if (x > 0 && 5 > x )
                {
                    Console.Clear();
                    RedirectMenu(x);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong");
                    MenuDisplay();
                }
            }

            Console.Clear();
        }
        public void Subject(List<string[]> list)
        {
            var subjectName = list[0][0];
            Console.WriteLine(subjectName);
            for (int i = 1; i < list.Count; i++)
            {
                var testlist = list[i];
                var joinlist = string.Join(" ", testlist); 
                Console.WriteLine(joinlist);
            }
        }

        public void RedirectMenu(int value)
        {
            if (value == 1)
            {
                Subject(TeacherList);
            }
            else if (value == 2)
            {
                Subject(CourseList);
            }
            else if (value == 3)
            {
                Subject(ClassList);
            }
            if (value == 4)
            {
                Subject(StudentList);
            }
            //int valuex = 0;
            //if (value < 5 && 0 < value)
            //{
            //    valuex = value;
            //}
            //return valuex;
        }

    }
}
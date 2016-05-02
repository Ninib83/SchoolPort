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
        public void OverWriteData(int inputId)
        {
            string[] testList = new string[5];
            testList[inputId] = DataList[inputId];

            int line_to_edit = inputId + 1;

            string[] lines = File.ReadAllLines("Data.txt");

            string lineToWrite = testList[inputId];

            using (StreamWriter writer = new StreamWriter("Data.txt"))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == line_to_edit)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
        }
        public void JoinData(List<string[]> list, int inputId)
        {
            StringBuilder sb = new StringBuilder();
            var teststing = list[0][0];
            sb.Append(teststing);
            for (int i = 1; i < list.Count; i++)
            {
                var result = string.Join(",", list[i]);
                sb.Append("|");
                sb.Append(result);
            }
            //foreach (var item in StudentList)
            //{
            //    var result = string.Join(",", item);
            //    sb.Append("|");
            //    sb.Append(result);
            //}
            string joinString = sb.ToString();
            DataList[inputId] = joinString;
            //var result = string.Join(",", StudentList[1]);
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
            string[] adminList = new string[2];            
            adminList[0] = AdministratiorList[1][1];
            adminList[1] = AdministratiorList[1][2];

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

        public void SubjectMenu(List<string[]> list, int inputId)
        {
            Subject(list, inputId);
            Console.WriteLine("User Input: ");
            var userInput = Console.ReadLine();
            CheckUserInput(userInput, list, inputId);
        }

        public void Subject(List<string[]> list, int inputId)
        {
            var subjectName = list[0][0];
            Console.WriteLine(subjectName);
            for (int i = 1; i < list.Count; i++)
            {
                var testlist = list[i];
                var joinlist = string.Join(" ", testlist); 
                Console.WriteLine(joinlist);
            }
            //Console.WriteLine("User Input: ");
            //var userInput = Console.ReadLine();
            //CheckUserInput(userInput, list, inputId);
        }

        public void CreateDisplay(List<string[]> list, int inputId)
        {
            Console.WriteLine("Create a new");
            if (list[0][0] == "Teacher")
            {
                Console.WriteLine("Ex; 1,John,Doe,Course");
            }
            if (list[0][0] == "Course")
            {
                Console.WriteLine("Ex; Id,Name,Teacher,Class,Start,End");
            }
            if (list[0][0] == "Class")
            {
                //Console.WriteLine("Ex; 1,John,Doe,197265-8762,Class");
            }
            if (list[0][0] == "Student")
            {
                Console.WriteLine("Ex; 1,John,Doe,197265-8762,Class");
            }

            var input = Console.ReadLine();
            var result = Create(list, input);
            if (result == true)
            {
                JoinData(list, inputId);
                OverWriteData(inputId);
                Console.Clear();
                Console.WriteLine("Item was successfully created");
                SubjectMenu(list, inputId);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Faild To Create");
                SubjectMenu(list, inputId);
            }
        }

        public bool Create(List<string[]> list, string input)
        {
            bool createdItem = false;
            var newInput = input.Split(',');
            if (newInput.Length == 5)
            {
                foreach (var itemId in list)
                {
                    if (itemId[0] == newInput[0])
                    {
                        return createdItem;
                    }
                }

                list.Add(new string[5]);
                var listlength = list.Count();
                list[listlength - 1] = newInput;
                createdItem = true;

                return createdItem;
            } 

            return createdItem;
        }

        public void DeleteDisplay(List<string[]> list, int inputId)
        {
            Subject(list, inputId);
            Console.WriteLine("How to delete an item");
            Console.WriteLine("Enter item Id");
            var userInput = Console.ReadLine();
            var isNumber = Regex.IsMatch(userInput, @"^\d+$");
            if (isNumber != false)
            {
                var result = Delete(list, userInput);
                if (result != false)
                {
                    JoinData(list, inputId);
                    OverWriteData(inputId);
                    Console.Clear();
                    Console.WriteLine("Item was deleted");
                    DeleteDisplay(list, inputId);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong");
                    DeleteDisplay(list, inputId);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something went wrong");
                DeleteDisplay(list, inputId);
            }
            
            //var isNumber = Regex.IsMatch(userInput, @"^\d+$");
            //if (isNumber != false)
            //{
            //    int x = 0;
            //    Int32.TryParse(userInput, out x);
            //    var result = Delete(list, x);
            //}
        }

        public bool Delete(List<string[]> list, string input)
        {
            var count = 0;
            foreach (var item in list)
            {
                var itemId = item[0];
                if (itemId == input)
                {
                    list.RemoveAt(count);

                    return true;
                }
                count += 1;
            }
            return false;
        }

        public void CheckUserInput(string userInput, List<string[]> list, int inputId)
        {
            if (userInput == "Create")
            {
                Console.Clear();
                CreateDisplay(list, inputId);
            }
            else if (userInput == "Edit")
            {

            }
            else if (userInput == "Delete")
            {
                Console.Clear();
                DeleteDisplay(list, inputId);
            }
            else
            {
                Console.WriteLine("You can only choose between | Create, Edit, Delete |");
                MenuDisplay();   
            }
        }

        public void RedirectMenu(int value)
        {
            if (value == 1)
            {
                SubjectMenu(TeacherList, value);
            }
            else if (value == 2)
            {
                SubjectMenu(CourseList, value);
            }
            else if (value == 3)
            {
                SubjectMenu(ClassList, value);
            }
            if (value == 4)
            {
                SubjectMenu(StudentList, value);
            }
        }

    }
}
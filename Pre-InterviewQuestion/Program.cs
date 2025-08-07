using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pre_InterviewQuestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hi My Name is : ASLT.Nontanun Pintanapoom :)");
                Console.WriteLine();
                Console.Write("Enter Question 1-6 (or type 'exit' to quit): ");
                string question = Console.ReadLine();

                if (question.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                switch (question)
                {
                    case "1":
                        QuestionNo1();
                        break;
                    case "2":
                        QuestionNo2();
                        break;
                    case "3":
                        QuestionNo3();
                        break;
                    case "4":
                        Console.Write("Enter a number or Char (N/C) :");
                        string key = Console.ReadLine();
                        switch (key)
                        {
                            case "N":
                                QuestionNo41();
                                break;
                            case "C":
                                QuestionNo4();
                                break;
                            default:
                                Console.WriteLine("Invalid Key");
                                break;
                        }
                        break;
                    case "5":
                        QuestionNo5();
                        break;
                    case "6":
                        QuestionNo6();
                        break;
                    default:
                        Console.WriteLine($"Invalid Question Please try again (1-6), {question}!");
                        break;
                }

                Console.WriteLine();
            }




            //QuestionNo1();
            //QuestionNo2();
            //QuestionNo3();
            //QuestionNo4();
            //QuestionNo41();
            //QuestionNo5();
            //QuestionNo6();



        }

        #region QuestionNo6
        private static void QuestionNo6()
        {
            Console.Write("QuestionNo6 ==> Enter List number Ex: (1,3,5) Or Pass key=> Y : ");
            //string itemList = Console.ReadLine();
            string num = Console.ReadLine();


            int[] listData = { 1, 3, 5 };
            int loop = int.MinValue;
            int keyTribo = 3;

            if (String.IsNullOrEmpty(num))
            {
                Console.WriteLine("Invalid key!");
                QuestionNo6();
                return;

            }

            if (num == "Y")
            {
                loop = 10;
            }
            else
            {

                string[] splitKey = num.Split(',');

                for (int i = 0; i < num.Split(',').Length; i++)
                {
                    listData[i] = Convert.ToInt32(splitKey[i]);
                }

                Console.Write("QuestionNo6 ==> Enter non negative : ");
                loop = Convert.ToInt32(Console.ReadLine());


            }





            for (int i = listData.Length; i < loop; i++)
            {
                if (listData.Length < loop)
                {
                    int resultSum = listData.Skip(i - keyTribo).Sum();
                    int[] newArray = new int[listData.Length + 1];

                    for (int j = 0; j < listData.Length; j++)
                    {
                        newArray[j] = listData[j];
                    }

                    newArray[listData.Length] = resultSum;
                    listData = newArray;
                }
            }

            Console.WriteLine(string.Join(", ", listData));
        }
        #endregion

        #region QuestionNo5
        private static void QuestionNo5()
        {
            Console.Write("QuestionNo5 ==> Enter number Ex: (2679) : ");
            //string itemList = Console.ReadLine();
            int num = Convert.ToInt32(Console.ReadLine());
            string result = String.Empty;
            foreach (char c in num.ToString().OrderByDescending(i => i))
            {
                result += c;
            }
            Console.WriteLine(result);
        }

        #endregion

        #region QuestionNo4
        private static void QuestionNo4()
        {
            string data = String.Empty;

            Console.Write("Enter Char (DCCLXXXIX) : ");

            string key = Console.ReadLine();

            int sum = 0;

            int valuse = 0;
            int[] numbers = new int[10];

            for (int i = 0; i < key.Length; i++)
            {
                valuse = ConvertCharToInt(key.Substring(i, 1));
                numbers[i] = valuse;

                if (i > 0)
                {
                    if (valuse > numbers[i - 1])
                    {
                        sum = (sum - numbers[i - 1]) + (valuse - numbers[i - 1]);
                    }
                    else
                    {
                        sum += numbers[i];
                    }
                }
                else
                {
                    sum += numbers[i];
                }
            }
            Console.WriteLine(key + " => " + sum);
        }

        private static void QuestionNo41()
        {
            Console.Write("Enter number : ");
            int number = int.Parse(Console.ReadLine());

            string result = "";


            string[] roman = { "M", "D", "C", "L", "X", "V", "I" };
            int[] value = { 1000, 500, 100, 50, 10, 5, 1 };

            for (int i = 0; i < value.Length; i++)
            {
                while (number >= value[i])
                {
                    result += roman[i];
                    number -= value[i];
                }
            }

            Console.WriteLine("Roman Number: " + result);
        }

        private static int ConvertCharToInt(string key)
        {
            int nub = 0;

            switch (key.ToUpper())
            {
                case "I":
                    nub = 1;
                    break;
                case "V":
                    nub = 5;
                    break;
                case "X":
                    nub = 10;
                    break;
                case "L":
                    nub = 50;
                    break;
                case "C":
                    nub = 100;
                    break;
                case "D":
                    nub = 500;
                    break;
                case "M":
                    nub = 1000;
                    break;
                default:
                    break;
            }
            return nub;

        }

        private static string ConvertIntToChar(int key)
        {
            string chars = String.Empty;
            switch (key)
            {
                case 1:
                    chars = "I";
                    break;
                case 5:
                    chars = "V";
                    break;
                case 10:
                    chars = "X";
                    break;
                case 50:
                    chars = "L";
                    break;
                case 100:
                    chars = "C";
                    break;
                case 500:
                    chars = "D";
                    break;
                case 1000:
                    chars = "M";
                    break;
            }
            return chars;

        }

        #endregion

        #region QuestionNo3 
        private static void QuestionNo3()
        {
            Console.WriteLine();
            Console.Write("QuestionNo3 ==> Enter item Ex : (Mother, Think, Worthy,Apple,Android or Pass key EX Enter Y) : ");
            string itemList = Console.ReadLine();

            if (String.IsNullOrEmpty(itemList))
            {
                Console.WriteLine("Invalid key!");
                QuestionNo3();
                return;

            }

            string search = String.Empty;
            string[] items = { "Mother", "Think", "Worthy", "Apple", "Android" };
            int maxResult = 0;
            if (itemList == "Y")
            {
                search = "th";
                maxResult = 2;
            }
            else
            {

                Console.WriteLine($"Item list ==> {itemList}");

                string[] splitKey = itemList.Split(',');
                //string[] input1 = new string[splitKey.Length];
                for (int i = 0; i < itemList.Split(',').Length; i++)
                {
                    items[i] = splitKey[i];
                }




                Console.Write("QuestionNo3 ==> Enter search : ");
                search = Console.ReadLine();

                Console.Write("QuestionNo3 ==> Enter maxResult : ");
                maxResult = Convert.ToInt32(Console.ReadLine());



            }


            DataSet ds = new DataSet();
            DataRow dr;
            DataTable dt = new DataTable("MyTable");

            dt.Columns.Add(new DataColumn("items", typeof(string)));

            foreach (string item in items)
            {
                dr = dt.NewRow();
                dr["items"] = item;
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);


            DataSet dsWhere = new DataSet();
            DataRow[] dtRow = dt.Select("items LIKE '%" + search + "%'", "items ASC");
            DataRow[] dtRow2 = dtRow.Take(maxResult).ToArray();
            if (dtRow2.Length > 0)
            {
                dsWhere.Tables.Add(dtRow2.CopyToDataTable());
            }
            string ConName = String.Empty;
            for (int i = 0; i < dsWhere.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine(ConName = dsWhere.Tables[0].Rows[i]["items"].ToString());
            }



        }

        #endregion

        #region QuestionNo2
        private static void QuestionNo2()
        {

            // test

            // update github

            Console.WriteLine();
            Console.Write("QuestionNo2 ==> Enter Key Ex : (TH19, SG20, TH2  or TH10, TH3Netflix, TH1, TH7 or pass key EX Enter Y) : ");
            string key = Console.ReadLine();

            if (String.IsNullOrEmpty(key))
            {
                Console.WriteLine("Invalid key!");
                QuestionNo2();
                return;

            }
            string[] result1;
            string[] result2;
            if (key == "Y")
            {
                string[] input1 = { "TH19", "SG20", "TH2" };
                string[] input2 = { "TH10", "TH3Netflix", "TH1", "TH7" };

                result1 = SortCustom(input1);
                result2 = SortCustom(input2);
                Console.WriteLine(string.Join(", ", result1));
                Console.WriteLine(string.Join(", ", result2));

            }
            else
            {
                int num = key.Split(',').Length;

                string[] splitKey = key.Split(',');
                string[] input1 = new string[splitKey.Length];
                for (int i = 0; i < num; i++)
                {
                    input1[i] = splitKey[i];
                }
                result1 = SortCustom(input1);
                Console.WriteLine(string.Join(", ", result1));
            }
        }

        static string[] SortCustom(string[] input)
        {
            return input
                .Select(item =>
                {
                    var match = Regex.Match(item, @"^([A-Za-z]+)(\d+)");
                    string prefix = match.Groups[1].Value;
                    int number = int.Parse(match.Groups[2].Value);
                    return new { Original = item, Prefix = prefix, Number = number };
                })
                .OrderBy(x => x.Prefix)
                .ThenBy(x => x.Number)
                .Select(x => x.Original)
                .ToArray();
        }

        #endregion

        #region QuestionNo1
        private static void QuestionNo1()
        {
            Console.WriteLine();
            Console.Write("QuestionNo1 ==> Enter Key Ex (), ([]], ([{}]), ([[{}]]], ), (]}]), ([)], { or ALL: ");
            string key = Console.ReadLine();

            string[] dataList = { "()", "([]]", "([{}])", "([[{}]]]", ")", "(]}])", "([)]", "{" };


            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("Invalid key!");
                QuestionNo1();
                return;

            }
            else
            {
                bool b = dataList.Contains(key);
                if (b)
                {
                    dataList = new string[] { key };
                }
                else
                {

                    if (key != "ALL")
                    {
                        Console.WriteLine("Key not match!");
                        QuestionNo1();
                        return;
                    }

                }
                foreach (string item in dataList)
                {
                    Console.WriteLine($"{item} => {CheckValid(item)}");
                }
            }

            //Console.WriteLine(CheckValid("()"));   // True
            //Console.WriteLine(CheckValid("([]]"));     // False
            //Console.WriteLine(CheckValid("([{}])")); // True
            //Console.WriteLine(CheckValid("([[{}]]]"));      // False
            //Console.WriteLine(CheckValid(")"));      // False
            //Console.WriteLine(CheckValid("(]}])"));      // False
            //Console.WriteLine(CheckValid("([)]"));      // False
            //Console.WriteLine(CheckValid("{"));      // False
        }

        static bool CheckValid(string inputData)
        {
            string previous;

            do
            {
                previous = inputData;
                inputData = inputData.Replace("()", "")
                             .Replace("[]", "")
                             .Replace("{}", "");
            } while (inputData != previous);

            return inputData.Length == 0;
        }

        #endregion
    }
}

using System;
using System.IO;

namespace CsvEmployeeWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            const int END = -1;
            const string DELIM = ",";
            const string FILENAME = "EmployeeData.txt";

            Employee emp = new Employee();
            FileStream outFile = new
                FileStream(FILENAME, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            string input;
            int outNum;
            double outDec;

            Console.Write("Enter employee number or {0} to quit", END);
            input = Console.ReadLine();

            if(int.TryParse(input,out outNum))
            {
                emp.EmpNum = outNum;
            }
            else
            {
                emp.EmpNum = -1;
            }

            try
            {
                while (emp.EmpNum != END)
                {
                    Console.Write("Enter last name>> ");
                    emp.Name = Console.ReadLine();

                    Console.Write("Enter salary>> ");
                    input = Console.ReadLine();
                    if (double.TryParse(input, out outDec))
                    {
                        emp.Salary = outDec;
                    }

                    writer.WriteLine("{1} {0} {2} {0} {3}"
                        , DELIM, emp.EmpNum, emp.Name, emp.Salary);
                    Console.Write("Enter employee number or {0} to quit", END);
                    input = Console.ReadLine();

                    if (int.TryParse(input, out outNum))
                    {
                        emp.EmpNum = outNum;
                    }
                    else
                    {
                        emp.EmpNum = -1;
                    }
                }
            } finally
            {
                writer.Close();
                outFile.Close();
            }
            

             
        }
    }
}

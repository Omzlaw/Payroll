using System;
using System.Threading;

namespace ProjectPayroll
{
    class Program
    {
        static void Main(string[] args)
        {   
            string option = String.Empty;
            Employee employee = new Employee();
            Console.WriteLine("===================================");
            Console.WriteLine("Welcome to EDsine Payroll system!!!");
            Console.WriteLine("===================================");
            do
            {
                Console.WriteLine();
                Console.WriteLine("Below are the system's functionality:");
                Console.WriteLine("1: Store employee information");
                Console.WriteLine("2: Update employee information");
                Console.WriteLine("3: Delete employee information");
                Console.WriteLine("4: Send Emails to all employees");
                Console.WriteLine("5: Send Email to specific employees");
                Console.WriteLine("6: Generate Payroll");
                Console.WriteLine("7: Generate Payslip");
                Console.WriteLine("8: Exit Payslip Application");
                Console.WriteLine();
                Console.Write("Please select an option: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1": 
                        Console.WriteLine("Storing employee information.....");
                     employee.storeEmployeeInfo();
                        break;
                    case "2": 
                        Console.WriteLine("Updating employee Information......");
                     employee.updateEmployeeInfo();
                        break;
                    case "3":
                        Console.WriteLine("Deleting employee Information......");
                     employee.deleteEmployeeInfo();
                        break;
                    case "4":
                        Console.WriteLine("Sending emails to all employees......");
                     employee.sendEmailToEmployees();
                        break;
                    case "5":
                        Console.WriteLine("Sending email to specific employee......");
                     employee.sendEmailToEmployee();
                        break;
                    case "6":
                        Console.WriteLine("Generating Payslip......");
                     employee.generatePayRoll();
                        break;
                    case "7":
                        Console.WriteLine("Generating Payslip......");
                     employee.generatePaySlip();
                        break;
                    case "8":
                        Console.WriteLine("Exiting Payroll Application......"); 
                        Thread.Sleep(3000);
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You selected an invalid entry"); 
                        Console.WriteLine("");
                        break;
                }

            } while (option != "8");

        }
    }
}

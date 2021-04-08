using System;
using System.IO;
using System.Text;

namespace ProjectPayroll
{
    public class Employee
    {
        static string directory = @"C:\EdsineProjects\project_payroll\ProjectPayroll\";
        static string fileName = "employeedata.csv";
        public int employeeNumber;
        public string firstName;
        public string lastName;
        public string department;
        public string emailAddress;
        public double grossSalary, netSalary, tax, bonuses, pension;
        public int totalWorkingHours;
        
        public void calculateNetSalary() {
            tax = Math.Round(0.075 * grossSalary, 2);
            pension = Math.Round(0.075 * grossSalary, 2);
            netSalary = Math.Round((grossSalary + bonuses) - tax - pension, 2);
        }

        public void calculateBonuses() {
            if (totalWorkingHours > 180) {
                bonuses = 0.05 * grossSalary;
            } else if (totalWorkingHours <= 160) {
                bonuses = -(0.02 * grossSalary);
            }
        }

        public void storeEmployeeInfo() {

            Console.Write("Input the employee's number: ");
            employeeNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Input the employee's first Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Input the employee's Last Name: ");
            lastName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Input the employee's Email Address: ");
            emailAddress = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Input the employee's department: ");
            department = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Input the employee's gross salary: ");
            grossSalary = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Input the employee's total working hours: ");
            totalWorkingHours = int.Parse(Console.ReadLine());
            Console.WriteLine();

            while(!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
                while(!File.Exists(directory + fileName)) {
                    File.Create(directory + fileName);
                }
            }

            calculateBonuses();
            calculateNetSalary();
            
            StringBuilder sb = new StringBuilder();
            sb.Append(employeeNumber + ",");
            sb.Append(firstName + ",");
            sb.Append(lastName + ",");
            sb.Append(department + ",");
            sb.Append(grossSalary + ",");
            sb.Append(tax + ",");
            sb.Append(pension + ",");
            sb.Append(bonuses + ",");
            sb.Append(netSalary + ",");
            sb.Append(totalWorkingHours + ",");
            sb.Append(emailAddress);
            sb.Append ("\n");
            File.AppendAllText(directory + fileName, sb.ToString());
            Console.Write("Data Recorded Successfully \n");
        }

        public void updateEmployeeInfo() {

        }

        public void deleteEmployeeInfo() {

        }

        public void sendEmailToEmployees() {

        }

        public void sendEmailToEmployee() {

        }

        public void generatePayRoll() {
            double totalSalaryPaid = 1, taxCollected = 1, pensionCollected = 1, bonusesPaid = 1;
            string[] lines = File.ReadAllLines(directory + fileName);
            Console.Write("---------------------------------------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.Write(String.Format("{0, -15}","No."));
            Console.Write(String.Format("{0, -15}", "First Name"));
            Console.Write(String.Format("{0, -15}", "Last Name"));
            Console.Write(String.Format("{0, -15}", "Department"));
            Console.Write(String.Format("{0, -15}", "Gross Salary"));
            Console.Write(String.Format("{0, -15}", "Tax"));
            Console.Write(String.Format("{0, -15}", "Pension"));
            Console.Write(String.Format("{0, -15}", "Bonuses"));
            Console.Write(String.Format("{0, -15}", "Net Salary"));
            Console.Write(String.Format("{0, -15}", "TW Hours"));
            Console.WriteLine(String.Format("{0, -15}", "Email"));
            Console.Write("---------------------------------------------------");
            Console.WriteLine("---------------------------------------------------");
            foreach(string line in lines) {
                string[] columns = line.Split(',');
                foreach(string column in columns) 
                {
                    Console.Write(String.Format("{0, -15}", $"{column}"));
                }
                Console.WriteLine();
                Console.Write("---------------------------------------------------");
                Console.WriteLine("---------------------------------------------------");
                totalSalaryPaid += double.Parse(columns[4]);
                taxCollected += double.Parse(columns[5]);
                pensionCollected += double.Parse(columns[6]);
                bonusesPaid += double.Parse(columns[7]);
            }
            Console.WriteLine();
            Console.Write("---------------------------------------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Total Salary: {totalSalaryPaid}".PadRight(20));
            Console.WriteLine($"Total Tax: {taxCollected}".PadRight(20));
            Console.WriteLine($"Total Pension: {pensionCollected}".PadRight(20));
            Console.WriteLine($"Total Bonuses: {bonusesPaid}".PadRight(20));
            Console.Write("---------------------------------------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }

        public void generatePaySlip() {
            Console.Write("Please input the employee's number: ");
            string employeeNumber = Console.ReadLine();
            string[] lines = File.ReadAllLines(directory + fileName);
            Console.WriteLine("Input the employer's name: ");
            string employer = Console.ReadLine();
            foreach(string line in lines) {
                if(line.Contains(employeeNumber)) {
                    string[] columns = line.Split(',');
                    Console.WriteLine("\n");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("PAYSLIP");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Employer's name: {employer}");
                    Console.WriteLine(String.Format("{0, -10} {1, -10}", $"Employee's name: {columns[1]} {columns[2]}", $"| Hours Worked: {columns[9]}"));
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("EARNINGS");
                    Console.WriteLine(String.Format("{0, -10} {1, -10}", "Salary: ", columns[4]));
                    Console.Write(String.Format("{0, -10} {1, -10}", "Bonuses: ", double.Parse(columns[7])));
                    Console.WriteLine(String.Format("{0, -10} {1, -10}", "Gross Payment: ", double.Parse(columns[4]) + double.Parse(columns[7])));
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("DEDUCTIONS");
                    Console.WriteLine(String.Format("{0, -10} {1, -10}", "Tax: ", columns[5]));
                    Console.Write(String.Format("{0, -10} {1, -10}", "Pension: ", columns[6]));
                    Console.WriteLine(String.Format("{0, -10} {1, -10}" ,"Total Deductions: ", double.Parse(columns[5]) + double.Parse(columns[6])));
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine(String.Format("{0, -10} {1, -10}", "Net Payment: ", columns[8]));
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();

                    break;
                }
                else {
                    Console.WriteLine("No employee found. Please check employee's number and try again"); 
                }
            }

        }


    }
}
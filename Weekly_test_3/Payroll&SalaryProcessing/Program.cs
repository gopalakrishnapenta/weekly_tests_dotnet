using System;
using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Services;

namespace PayrollSystem
{
    class Program
    {
        static void Main()
        {
            var employees = new List<Employee>
            {
                new FullTimeEmployee(101, "Rahul", 50000, 30),
                new FullTimeEmployee(102, "Sneha", 65000, 30),
                new FullTimeEmployee(103, "Amit", 80000, 30),
                new ContractEmployee(201, "Indra", 1200, 22),
                new ContractEmployee(202, "Viswa", 3000, 20)
            };
            bool exit = false;

            Console.WriteLine("=== Payroll System ===\n");

            while (!exit)
            {
                Console.WriteLine("1. Add Full-Time Employee");
                Console.WriteLine("2. Add Contract Employee");
                Console.WriteLine("3. Process Payroll");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddFullTimeEmployee(employees);
                        break;

                    case 2:
                        AddContractEmployee(employees);
                        break;

                    case 3:
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("No employees available.\n");
                            break;
                        }

                        ProcessPayroll(employees);
                        exit = true;
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }

            Console.WriteLine("Application closed.");
            Console.ReadLine();
        }

        #region Helper Methods

        private static void AddFullTimeEmployee(List<Employee> employees)
        {
            int id = ReadInt("Enter Employee ID: ");
            string name = ReadString("Enter Employee Name: ");
            decimal salary = ReadDecimal("Enter Monthly Salary: ");
            int workingDays = ReadInt("Enter Working Days: ");

            employees.Add(new FullTimeEmployee(id, name, salary, workingDays));
            Console.WriteLine("Full-Time Employee added.\n");
        }

        private static void AddContractEmployee(List<Employee> employees)
        {
            int id = ReadInt("Enter Employee ID: ");
            string name = ReadString("Enter Employee Name: ");
            decimal dailyRate = ReadDecimal("Enter Daily Rate: ");
            int workingDays = ReadInt("Enter Working Days: ");

            employees.Add(new ContractEmployee(id, name, dailyRate, workingDays));
            Console.WriteLine("Contract Employee added.\n");
        }

        private static void ProcessPayroll(List<Employee> employees)
        {
            var processor = new PayrollProcessor();

            processor.SalaryProcessed += NotificationService.NotifyHR;
            processor.SalaryProcessed += NotificationService.NotifyFinance;

            var payslips = processor.ProcessPayroll(employees);
            PayrollReportService.PrintSummary(payslips);

            Console.WriteLine("\nPayroll processed successfully.\n");
        }

        #endregion

        #region Input Utilities

        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Invalid number.");
            }
        }

        private static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;

                Console.WriteLine("Invalid amount.");
            }
        }

        private static string ReadString(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        #endregion
    }
}

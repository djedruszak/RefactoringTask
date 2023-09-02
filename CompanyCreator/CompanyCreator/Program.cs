// See https://aka.ms/new-console-template for more information

using CompanyCreator;
using CompanyCreator.Solution;

Console.WriteLine("Hello, World!");

var company = new Company("test");
company.AddEmployee(1, "a", "", EmployeeTypes.Standard, 10.0);
company.UpdateEmployeeSalary(1, 25.0);
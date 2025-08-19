using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            PermanentEmployee permanentEmp1 = new PermanentEmployee()
            {
                BasicSalary = 30000,
                Month = "February",
                EmpType = EmployeeType.Permanent
            };
            PermanentEmployee permanentEmp2 = new PermanentEmployee()
            {
                BasicSalary = 20000,
                Month = "February",
                EmpType = EmployeeType.Permanent
            };
            TemporaryEmployee temporaryEmp1 = new TemporaryEmployee()
            {
                BasicSalary = 40000,
                Month = "February",
                EmpType = EmployeeType.Permanent
            };
            TemporaryEmployee temporaryEmp2 = new TemporaryEmployee()
            {
                BasicSalary = 35000,
                Month = "February",
                EmpType = EmployeeType.Permanent
            };

            List<PermanentEmployee> permanentEmployees = new List<PermanentEmployee>();
            List<TemporaryEmployee> temporaryEmployees = new List<TemporaryEmployee>();

            permanentEmployees.Add(permanentEmp1);
            permanentEmployees.Add(permanentEmp2);

            temporaryEmployees.Add(temporaryEmp1);
            temporaryEmployees.Add(temporaryEmp2);

            Console.WriteLine("{0}\nPERMANENT EMPLOYEES", new String('.', 100));
            foreach (var item in permanentEmployees)
            {
                Console.WriteLine(new String('`', 100));
                Console.WriteLine($"SalaryID: {item.SalaryID}\tEmployee ID: {item.EmployeeID}\tEmployee Type: {item.EmpType}\tMonth: {item.Month}\n\nBasic Salary: {item.BasicSalary}\nDA: {item.DA}\nHRA: {item.HRA}\nPF: {item.PF}\nTotal Salary: {item.TotalSalary}");
                Console.WriteLine(new String('`', 100));
            }
            Console.WriteLine("{0}", new String('.', 100));

            Console.WriteLine("{0}\nTEMPORARY EMPLOYEES", new String('.', 100));
            foreach (var item in temporaryEmployees)
            {
                Console.WriteLine(new String('`', 100));
                Console.WriteLine($"SalaryID: {item.SalaryID}\tEmployee ID: {item.EmployeeID}\tEmployee Type: {item.EmpType}\tMonth: {item.Month}\n\nBasic Salary: {item.BasicSalary}\nDA: {item.DA}\nHRA: {item.HRA}\nPF: {item.PF}\nTotal Salary: {item.TotalSalary}");
                Console.WriteLine(new String('`', 100));
            }
            Console.WriteLine("{0}",new String('.', 100));            
        }
    }
}
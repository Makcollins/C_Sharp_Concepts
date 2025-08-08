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

            foreach (var item in permanentEmployees)
            {
                Console.WriteLine($"SalaryID: {item.SalaryID}\nEmployee ID: {item.EmployeeID}\nEmployee Type: {item.EmpType}\nBasic Salary: {item.BasicSalary}\nMonth: {item.Month}")
            }          
        }
    }
}
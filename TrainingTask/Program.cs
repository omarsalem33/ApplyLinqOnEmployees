using Shared;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace TrainingTask
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            var employees = Repository.LoadEmployee();
            // 1. Write a LINQ query to fetch all employees in the "IT" department
            var result1 = employees.Where(x => x.Department == "IT");
            result1.Print("All employees in the \"IT\" department");
            Console.WriteLine("*-------------------------------");
            
            //2. Find the employee with the highest salary using a LINQ query.
            var result2 = employees.MaxBy(x => x.Salary);
            Console.WriteLine(result2);
            
            // 3. Sort the employees by their names in ascending order and display them.
            var res3 = employees.OrderBy(x => x.Name);
            res3.Print("Sort the employees by their names in ascending order and display them");
            
            // Calculate the average salary of employees in the "HR" department
            var res4 = employees.Where(x => x.Department == "HR").Average(x => x.Salary);
            Console.WriteLine($"the average salary of employees in the \"HR\" department is: {res4}");
            
            //5. Write a LINQ query to fetch employees whose salary is greater than 50,000 and order them by department.
            var res5 = employees.Where(x => x.Salary > 50-000).OrderBy(x => x.Department);
            res5.Print("fetch employees whose salary is greater than 50,000 and order them by department");
            
            //6. Use LINQ to group employees by department and display the department name and count of employees in each.
            var res6 = employees.GroupBy(x => x.Department);
            foreach (var group in res6) 
            {
               group.Print($"Employees in {group.Key} Department is: {group.Count()}");    
            }

            //7. Create a new list that contains only the `Name` and `Salary` of employees and display it.
            var res7 = employees.Select(x =>
            {
                return new EmployeeDTO
                {
                    Name = x.Name,
                    Salary = x.Salary,
                };
            });
            res7.Print("list that contains only the `Name` and `Salary` of employees and display it");

            //Use LINQ to find the second-highest salary in the list.
            var employeesDESC = employees.OrderByDescending(x => x.Salary);
            var res8 = employeesDESC.Take(2).ToList().Min(x => x.Salary);
            Console.WriteLine($"Second higest salary:{res8}");

            //Implement a LINQ query to fetch employees whose names start with a vowel
            var res9 = employees.Where(x => x.Name.ToUpperInvariant().StartsWith("A") ||
                                            x.Name.ToUpperInvariant().StartsWith("E") || 
                                            x.Name.ToUpperInvariant().StartsWith("I") ||
                                            x.Name.ToUpperInvariant().StartsWith("U") ||
                                            x.Name.ToUpperInvariant().StartsWith("O")) ;
            res9.Print("fetch employees whose names start with a vowel");


        }
    }
}

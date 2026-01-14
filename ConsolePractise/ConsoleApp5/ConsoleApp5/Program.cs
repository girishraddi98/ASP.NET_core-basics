

using System.Collections
    .Generic;
using System.Linq;

class Employee
{
    int ID;
    string Name;
    public static void Main()
    {
        List<Employee> listEmployee = new List<Employee>()
     {
         new Employee{ID =101, Name="haw"},
         new Employee{ID =102, Name="aw"},
         new Employee{ID =103, Name="w"},
     };
        ////    Employee employee = listEmployee.Find((Employee x) => x.ID == 102);
        //Console.WriteLine("ID={0}, Name={1}", employee.ID, employee.Name);

        //listEmployee = listEmployee.Where((Employee x) => x.ID! > 101).ToList();
        //listEmployee = listEmployee.Append(new Employee { ID = 104, Name = "new" }).ToList();
        //listEmployee = listEmployee.Concat(new Employee { ID = 104, Name = "new" }, new Employee { ID = 105, Name = "hgt" }).ToList();
    }
    




}

   






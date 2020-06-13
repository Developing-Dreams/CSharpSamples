using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CSharpSamples
{
    
    class Program
    {
        static List<int> myList = new List<int>();
        delegate double CalcArea(int r);
        
        static void Main(string[] args)
        {
          /////anounymous method
                    // //CalcArea c = r => 3.12 * r * r;
                        // //double d = c(20);
          //////Inbuild or generic delegates Func
            Func<double, double> c = m => 3.12 * m * m;
            double d = c(20);
            ///Action delegate
            ///
            Action<string> s = k => Console.WriteLine(k);
            s("test");

            ///Predicate 
            Predicate<string> predcheck = k => k.Length>4;
            predcheck("sgh");

            //IenumerableOrIqueryable ienumQuer = new IenumerableOrIqueryable();
            //var e = ienumQuer.EnumCheck();
            ////SQL Profiler check
            //var q = ienumQuer.QueryableCheck();
            //q.ToList();
            // ienumQuer.PerformanceCheckIenumerable();
            // ienumQuer.PerformanceCheckIqueryable();

            // FillList();
            //foreach(var i in YieldKeyword.Filter())
            // {
            //     Console.WriteLine("I ={0} ", i);
            // }
            //foreach (var i in RunningTotal())
            //{
            //    Console.WriteLine("I ={0} ", i);
            //}
            //Console.ReadLine();


        }
        

        static IEnumerable<int> RunningTotal()
        {
            int runningTotal = 0;

            foreach (var i in myList)
            {
                runningTotal += i;
                yield return (runningTotal);
            }
            

        }
         static List<int> FillList()
        {
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);
            return myList;

        }
         static IEnumerable<int> Filter()
        {
            foreach (var i in myList)
            {
                if (i > 3)
                {
                    yield return i;
                }

            }
            //return myList;

        }
    }

    public static class DelegateAnonymousKeyword
    {

        public static double CalculateArea(int r)
        {
            return 3.14 * r * r;

        }


    }
    public class IenumerableOrIqueryable
    {
        private readonly EFContext _context=new EFContext();

        public IEnumerable<Employee> EnumCheck()
        {
            //delegate
            var emp = _context.Employees;

            //////Using delegate
            ///
            return emp.Where(delegate (Employee temp)
            {
                return temp.Name == "prabu";
            }).ToList();

        }

        public IQueryable<Employee> QueryableCheck()
        {
            IQueryable<Employee> emp = _context.Employees;
            return emp.Where(x => x.Name.Equals("prabu"));
        }

        public void PerformanceCheckIenumerable()
        {
           var emps =  _context.Employees.Where(x => x.Name == "prabu")
                    .AsEnumerable()
                    .OrderByDescending(x => x.Name)
                    .Take(3);
            foreach(var emp in emps)
            {
                Console.WriteLine("Data Name", emp.Name,"Sex",emp.Gender);
            }
//            SELECT
//    [Extent1].[Id] AS[Id], 
//    [Extent1].[Name] AS[Name], 
//    [Extent1].[Salry] AS[Salry], 
//    [Extent1].[Gender]
//        AS[Gender]
//FROM[dbo].[Employees]
//        AS[Extent1]
//WHERE 'prabu' = [Extent1].[Name]


    }
    public void PerformanceCheckIqueryable()
        {
            var emps = _context.Employees.Where(x => x.Name == "prabu")
                     .AsQueryable()
                     .OrderByDescending(x => x.Name)
                     .Take(3);
            foreach (var emp in emps)
            {
                Console.WriteLine("Data Name", emp.Name, "Sex", emp.Gender);
            }


//            SELECT TOP(3) 
//    [Extent1].[Id] AS[Id], 
//    [Extent1].[Name] AS[Name], 
//    [Extent1].[Salry] AS[Salry], 
//    [Extent1].[Gender]
//        AS[Gender]
//FROM[dbo].[Employees]
//        AS[Extent1]
//WHERE 'prabu' = [Extent1].[Name]
//        ORDER BY[Extent1].[Name] DESC

    }

    }
}

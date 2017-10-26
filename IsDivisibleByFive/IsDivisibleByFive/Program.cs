using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IsDivisibleByFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original:");
            original();

            Console.WriteLine("Parallel:");
            parallel();

            Console.WriteLine("ParallelFor:");
            parallelFor();
        }

        static bool IsDivisibleByFive(int i)
        {
            Parallel.For(0, 5, x =>
            Thread.SpinWait(2000000));
            return i % 5 == 0;
        }

        static void original()
        {
            var numbers = Enumerable.Range(1, 1000);
            var results = numbers.Where(IsDivisibleByFive);

            var sw = Stopwatch.StartNew();
            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
            sw.Stop();

            Console.WriteLine("El tiempo transcurrido en ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("\nTerminado");
            Console.ReadKey(true);
        }

        static void parallel()
        {
            var numbers = Enumerable.Range(1, 1000);
            var results = numbers.AsParallel().Where(IsDivisibleByFive);

            var sw = Stopwatch.StartNew();
            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
            sw.Stop();

            Console.WriteLine("El tiempo transcurrido en ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("\nTerminado");
            Console.ReadKey(true);
        }
      
        private static IEnumerable<int> results;

        static void parallelFor()
        {
            var sw = Stopwatch.StartNew();
            var numbers = Enumerable.Range(1, 1000);
            Parallel.For(0, 1000, i =>
            {
                results = numbers.Where(IsDivisibleByFive);

            });

            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());

            sw.Stop();

            Console.WriteLine("El tiempo transcurrido en ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("\nTerminado");
            Console.ReadKey(true);
        }

        static void TaskM() {
            Stopwatch sw = Stopwatch.StartNew();
            IEnumerable<int> numbers = Enumerable.Range(1, 1000);
            IEnumerable<int> results = numbers.Where(IsDivisibleByFive);

            var task = Task.Factory.StartNew(() => TaskMetodo(results));

            Task.WaitAll(task);
            sw.Stop();

            Console.WriteLine("El tiempo transcurrido en ms: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("\nTerminado");
            Console.ReadKey(true);
        }

        public static void TaskMetodo(IEnumerable<int> results)
        {
            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
        }
    }
}

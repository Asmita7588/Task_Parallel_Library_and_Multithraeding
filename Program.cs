using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //Thread t = Thread.CurrentThread;
        //t.Name = "Main thread";

        //Console.WriteLine("Current Executing Thread Name :" + t.Name);
        //Console.WriteLine("Current Executing Thread Name :" + Thread.CurrentThread.Name);
        //Console.Read();

        //Thread thread1 = new Thread(PrintNumbers);
        //Thread thread2 = new Thread(PrintNumbers);  

        //thread1.Start();
        //thread2.Start();

        //thread1.Join();
        //thread2.Join();

        //Tpl

        Task task1 = Task.Run(() => PrintNumbers());
        Task task2 = Task.Run(() => PrintNumbers());

        await Task.WhenAll(task1, task2);

        //Task Creation
        Task<bool> taskbool = Task.Run(() => {
            return true;
        });

        bool result = taskbool.Result;

        //task that return int value

        Task<int> taskint = Task.Run(() => 42);

        //task that continues with previous task

        Task<string> taskstring = taskint.ContinueWith(prviousTask =>
        {
           int result = prviousTask.Result;
            return $"previous task return value is {result}";
        });

        //create and start task in one operation

       Task result1 = Task.Factory.StartNew(() => DoComputation(1.0));

        Console.WriteLine($"result sum = {result1.ToString()}");

        //detached child task 

        var Outer = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Outer task beginnning");

            var Child = Task.Factory.StartNew(() => { 

                Thread.SpinWait(5000000);
                Console.WriteLine("Detached task is completed");
            });

            
        });

        Outer.Wait();
        Console.WriteLine("Outer task is completed");
   


    }

    public static double DoComputation(Double start) { 

         double sum = 0;
        for (var i = 1; i <= start + 10; i += 1) { 
            sum += i;
        }
        return sum;
    }
    public static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            //Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: {i}");
            //Thread.Sleep(1000);

            //Tpl

            Console.WriteLine($"Task {Task.CurrentId} :{i}");
            Task.Delay(1000);
        }

    }
}
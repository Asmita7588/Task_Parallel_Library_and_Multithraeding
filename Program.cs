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

        Task task1 =Task.Run(() => PrintNumbers());
        Task task2 =Task.Run(() => PrintNumbers());

        await Task.WhenAll(task1, task2);

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
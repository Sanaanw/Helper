using C_.Async.Models;
using System.Security.Cryptography.X509Certificates;

namespace C_.Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Shallow and Deep copy
            //Shallow copy and deep copy
            User user1 = new User()
            {
                ID = 1,
                Name = "Name1",
                City = "City1",
                Details = new()
                {
                    PhoneNumber = "+994"
                }

            };
            #region Shallow Copy
            ////Shallow copy
            ////icerisinde yalniz primitiv deyerler olanda istifade olunur
            //User user2 = user1.ShallowCopy();
            //user2.Details.PhoneNumber = "1111";
            //Console.WriteLine(user1.Details.PhoneNumber);
            //Console.WriteLine(user2.Name); 
            #endregion

            #region Deep Copy
            ////Deep Copy ise butun datalari copy ede bilirik np
            //User user2 = user1.DeepCopy();
            //user2.Details.PhoneNumber = "12345";
            //Console.WriteLine(user1.Details.PhoneNumber); 
            #endregion 
            #endregion

            // Process and thread ,Task
            Thread thread1 = new(Loop1);
            Thread thread2 = new(Loop2);
            #region Bu halda Hello setro bloklanmr paralel cixa biler 
            //thread1.Start();
            //thread2.Start();
            //Console.WriteLine("Hello"); 
            #endregion

            #region Bu halda ise  evvelce threadlar ishleyir
            //thread1.Start();
            //thread2.Start();
            //thread1.Join();
            //thread2.Join();
            //Console.WriteLine("Hello");  
            #endregion

        }
        public static void Loop1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"First {i}");
                Thread.Sleep(100);
            }
        }
        public static void Loop2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Second {i}");
                Thread.Sleep(100);
            }
        }
    }
}

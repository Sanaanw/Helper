using Ado.Net.Service;

namespace Ado.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
           StudentService studentService = new StudentService();
            //Data Insert Elemek ucun
            studentService.Create(new() { Name = "Student2", Age = 18 });
            //Datalarin hamisini oxumaq ucun
            foreach (var student in studentService.GetAll())
            {
                Console.WriteLine(student);
            }
            //Oturulen Id ye esasen tapmaq ucun
            Console.WriteLine(studentService.GetById(2));
            //ID nen silinmek ucun 
            studentService.DeleteByID(2);
            //Update ucun
            studentService.Update(1, new() { Name = "Senan", Age = 18 });
            //Function cagirmaq ucun
            Console.WriteLine(studentService.GetDataCount());
            //Procedure isletmek
            studentService.GetDataWithAge(18);
        }
    }
}

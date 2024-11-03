using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml.Serialization;
using Sreialization.Models;

namespace Sreialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region DirectoryInfo    Directoryleri,onlarin melumatlarini geri qaytarir
            string path = @"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\";

            //DirectoryInfo directoryInfo1 = new DirectoryInfo(path);
            //Console.WriteLine(directoryInfo1.FullName);//Path falan verir    
            //Console.WriteLine(directoryInfo1.Root);
            //DirectoryInfo[] directoryInfo2 = directoryInfo1.GetDirectories();//Pathdaki directoryleri get edir. 
            //foreach (DirectoryInfo file in directoryInfo2)
            //{
            //    Console.WriteLine(file.Name);
            //}
            #endregion

            #region FileInfo   File haqqinda melumaatlari zad elde etmek ucundur
            //path = @"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\Dir1\File.txt";
            //FileInfo fileInfo = new FileInfo(path);
            //Console.WriteLine(fileInfo.FullName);
            #endregion

            #region File/Directory Create/Delete  
            //File / Directory create / Delete
            path = @"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\Dir3\";
           // if (!(Directory.Exists(path))) Directory.CreateDirectory(path);
            //path = @"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\Dir3\File.txt";
            //if (!(File.Exists(path))) File.Create(path);
            //if ((File.Exists(path))) File.Delete(path);
            //path = @"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\Dir3\";
           // Directory.Delete(path, true);// Eger ici bosduse silir
           // Directory.Delete(path);//icinin bos olub olmadigini nezere almir prosta silir
            #endregion

            #region FileStream  FileReader   FileWriter
            //FileStream,FileReader,FileWriter 
            path = @"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\Dir1\File.txt";
            //using (FileStream fileStream1 = new FileStream(path, FileMode.Open))//Her defe evvelki yazini silir yenisin yazir 
            //{
            //    using (StreamWriter streamWriter1 = new StreamWriter(fileStream1))
            //    {
            //        streamWriter1.Write("Hello");
            //    }
            //}
            //using (FileStream fileStream2 = new FileStream(path, FileMode.Append))//Evvelki yazini silmeden yenisini add edir
            //{
            //    using (StreamWriter streamWriter2 = new StreamWriter(fileStream2))
            //    {
            //        streamWriter2.WriteLine("Hello123");
            //    }
            //}
            ////Yalniz Idisposable implement eden classlari using ve ya close ede bilirik
            //using (FileStream fileStream3 = new FileStream(path, FileMode.Open))
            //using (StreamReader streamReader1 = new StreamReader(fileStream3))
            //Console.WriteLine( streamReader1.ReadToEnd());
            #endregion

            #region Serializer and DeSerializer(Xml and Json)
            //Serialize and DeSerialize
            Student student = new Student() { ID = 1, Name = "Senan" };
            //SerializeWithXml(student);
            //Console.WriteLine(DeSerializeWithXml());
            //SerializeWithJson(student);
            SerializeWithJson(student);
            //Console.WriteLine(DeSerializeFromReal());
            //foreach (var item in DeSerializeFromRealWithList())////List qaytarir deye edirik
            //{
            // Console.WriteLine(item);
            //}
            //ReadDataWithHttpClient(); 
            #endregion

        }
        public static void SerializeWithXml(Student student)
        {
            #region Serializer and DeSerializer(Xml and Json)
            using FileStream fileStream = new(@"C:\\Users\\ASUS\\OneDrive\\Desktop\\Serialization\\Sreialization\\Data\\Student.xml", FileMode.Open);
            ////File Stream Fayli oxumaq ucun istifade edilir,open onu acir if doesn't exist onda error verecek.
            XmlSerializer serializerValue = new XmlSerializer(typeof(Student));
            ////Burada typeof(Student) hissesi student type melumatini oturur.
            serializerValue.Serialize(fileStream, student);
        }
        public static Student DeSerializeWithXml()
        {
            using FileStream fileStream = new(@"C:\\Users\\ASUS\\OneDrive\\Desktop\\Serialization\\Sreialization\\Data\\Student.xml", FileMode.Open);
            XmlSerializer serializerValue = new XmlSerializer(typeof(Student));
            Student obj = serializerValue.Deserialize(fileStream) as Student;
            return obj;
        }
        public static void SerializeWithJson(Student student)
        {
            using FileStream fileStream = new(@"C:\Users\ASUS\OneDrive\Desktop\Serialization and DeSerialization\Sreialization\Data\Student.json", FileMode.Open);
            using StreamWriter writer = new StreamWriter(fileStream);
            string result = JsonSerializer.Serialize(student);
            writer.Write(result);

        }
        public static Student DeSerializeWithJson()
        {
            using FileStream fileStream = new(@"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\Student.json", FileMode.Open);
            using StreamReader streamReader = new StreamReader(fileStream);
            string result = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<Student>(result);

        }
        public static Root DeSerializeFromReal()
        {
            //https://json2csharp.com/    Burada bu saytdan istifade edib Json-u c#-a ceviririk
            using FileStream fileStream = new(@"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\FakeData.json", FileMode.Open);
            using StreamReader reader = new StreamReader(fileStream);
            string result = reader.ReadToEnd();
            return JsonSerializer.Deserialize<Root>(result);
        }
        public static List<Root> DeSerializeFromRealWithList()
        {
            using FileStream fileStream = new(@"C:\Users\ASUS\OneDrive\Desktop\Serialization\Sreialization\Data\FakeData.json", FileMode.Open);
            using StreamReader reader = new StreamReader(fileStream);
            string result = reader.ReadToEnd();
            return JsonSerializer.Deserialize<List<Root>>(result);
        }
        public static void ReadDataWithHttpClient()
        {
            ////linkden istifade ederek oxumaq c# a goturmek ucundur.
            HttpClient client = new HttpClient();
            var data = client.GetAsync("https://jsonplaceholder.typicode.com/users").GetAwaiter().GetResult();
            var stringResult = data.Content.ReadAsStringAsync().Result;
            using FileStream fileStream = new("C:\\Users\\ASUS\\OneDrive\\Desktop\\Serialization\\Sreialization\\Data\\FakeData.json", FileMode.Open);
            using StreamWriter writer = new(fileStream);
            writer.Write(stringResult);
        }
        #endregion
    }
}

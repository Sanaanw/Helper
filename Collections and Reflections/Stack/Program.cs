using Collections;
using System.Collections;
using System.Reflection;

namespace CollectionsReflection
{
    internal class  Program
    {
        //For Getting Information about Collections
        //https://www.tutorialsteacher.com/csharp/csharp-collection
        static void Main(string[] args)
        {
            #region Collections
            ////Collections
            #region List
            //List is only Generic
            List<string> list = new List<string>(); 
            #endregion
            #region ArrayList
            //ArrayList-Only Non-Generic olur.
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(new ArrayList()); //Arrayi object kimi yox sepelenmis sekilde add edir.
            arrayList.Insert(0, new ArrayList());//0-ci indekse arrayi add edir. 
            #endregion
            #region Stack
            ////Stack-Generic ve Non-Generic olur,LIFO ile ishleyir,
            Stack<int> stackgeneric = new Stack<int>();//generic and nongeneric olur
            Stack stacknongeneric = new Stack();//LIFO (last in first out)
            stacknongeneric.Push(1);// Add eliyir
            stacknongeneric.Push(true);// Add eliyir istenilen tipi
            stacknongeneric.Pop();// ConsoleWriteLinede birinci olani silir
            Console.WriteLine(stacknongeneric.Peek());// ConsoleWritelinede birinci olani ekrana cixardir
            foreach (var item in stacknongeneric)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Queue
            //Queue-Generic ve Non-Generic olur,FIFO ile ishleyir(Stackdan ferqi)
            Queue queueNonGeneric = new Queue();//Non Generic and Generic olur
            Queue<string> queueGeneric = new Queue<string>();//FIFO(First int First Out)
            queueGeneric.Enqueue("Hi"); // Add eliyir
            queueGeneric.Enqueue("What's up");
            queueGeneric.Dequeue(); // ConsoleWritelinede birinci ekrana cixani silir
            Console.WriteLine(queueGeneric.Peek()); // ConsoleWritelinede birinci olani ekrana cixardir
            #endregion
            #region SortedList
            //SortedList-Key ve Valueden ibaretdir,Key istenilen type get ede bilir,Console.WriteLine edende ekrana sorted 
            ////sekilde cixarir.
            SortedList<int, string> sortedListGeneric = new SortedList<int, string>();//Genericde key ve value deyeri vereilir
            SortedList sortedListNonGeneric = new SortedList();
            sortedListNonGeneric.Add(4, "Lorem");
            sortedListNonGeneric.Add(2, "Ipsum");
            foreach (DictionaryEntry /*var yaza bileriy*/ item in sortedListNonGeneric)//Sorted ekrana cixardir
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            #endregion
            #region HashTable
            //HashTable-Yalniz Generic olur,
            Hashtable hashtable = new Hashtable();// Only Non Generic olur
            hashtable.Add("first", true);
            hashtable.Add("second", false);
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Dictionary
            //Dictionary-Yalniz Generic olur,Digerlerin ferqli olaraq indexeri var.
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>(); // Only Generic olur
            dictionary.Add(1, new List<int>() { 1, 2, 4 });
            dictionary.Add(2, new List<int>() { 1, 2, });
            Console.WriteLine(dictionary[1]);// Indexeri var
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);
            }
            #endregion
            #endregion

            #region Reflection
            // Reflection
            int num = 12;
            Student student = new();
            Console.WriteLine(num.GetType());// num type-ni ekrana cixarir
            Console.WriteLine(typeof(int)); // gonderilen type haqqinda melumat verir 
            var type = typeof(Student);
            Console.WriteLine(type.IsPublic);
            Console.WriteLine(type.IsSealed);
            //Bunlari Fields.methods,Constructors esasende yaza bilirik(asagidakilari)
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.Name);
            }
            PropertyInfo[] props = type.GetProperties();
            foreach (var item in props)
            {
                Console.WriteLine(item.Name);
            }
            #endregion
        }
    }
}

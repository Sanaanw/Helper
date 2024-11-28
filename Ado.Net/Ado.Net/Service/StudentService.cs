using Ado.Net.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.Net.Service
{
    public class StudentService
    {
        [Obsolete]
        public void Create(Student student)
        {
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "INSERT INTO STUDENTS VALUES(@Name,@Age)";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Age", student.Age);
            //Update,Delete,Insert(ExecuteNonQuery ishlenir)
            //Eger Execute 0 dan boyukdurse ugurludur eks halda ugursuz
            sqlCommand.ExecuteNonQuery();
        }
        public List<Student> GetAll()
        {
            List<Student> studentsList = new List<Student>();
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "Select * from Students";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            //Yalniz Read emelyatlarinda reader ishledirik
            SqlDataReader reader = sqlCommand.ExecuteReader();
            //Eger hasrows true gelirse table doludur eks halda bosdur
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int _id = (int)reader.GetValue(0);
                    string _name = (string)reader.GetValue(1);
                    int _age = (int)reader.GetValue(2);
                    studentsList.Add(new Student { ID = _id, Name = _name, Age = _age });
                }
                return studentsList;
            }
            return studentsList;
        }
        public Student GetById(int ID)
        {
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "Select * from Students WHere ID=@id";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", ID);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Student newStudent = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int _id = (int)reader.GetValue(0);
                    string _name = (string)reader.GetValue(1);
                    int _age = (int)reader.GetValue(2);
                    newStudent = new() { ID = _id, Name = _name, Age = _age };
                }
                return newStudent;
            }
            return newStudent;
        }
        public void DeleteByID(int ID)
        {
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "Delete from Students WHere ID=@id";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", ID);
            if (sqlCommand.ExecuteNonQuery() > 0)
                Console.WriteLine("Deleted");
            else Console.WriteLine("Doesn't found");
        }
        public void Update(int id, Student student)
        {
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "Update STUDENTS SET Name=@Name,AGE = @Age WHERE ID = @ID";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Age", student.Age);
            sqlCommand.ExecuteNonQuery();
            if (sqlCommand.ExecuteNonQuery() > 0)
                Console.WriteLine("Updated");
            else Console.WriteLine("Not Succesfull");
        }
        public string GetAllWithView()
        {
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "Create view GetNameWithID AS Select S.Name from Students S Where ID=1";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string _name = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _name = (string)reader.GetValue(0);
                }
                return _name;
            }
            return null;
        }
        public int GetDataCount()
        {
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "Select dbo.GetCount()";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            int result = (int)sqlCommand.ExecuteScalar();
            return result;
        }
        public void GetDataWithAge(int age)
        {
            List<Student> StuList = new();  
            string connectionString = "Server=.; Database=PB502; User Id=sa; Password=Senan123@;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string Query = "GetData";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.CommandType=System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Age",age);
            SqlDataReader reader=sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int _id = (int)reader.GetValue(0);
                    string _name = (string)reader.GetValue(1);
                    int _age = (int)reader.GetValue(2);
                    StuList.Add(new() { ID = _id, Name = _name, Age = _age });
                }
                foreach (Student student in StuList)
                {
                    Console.Write(student.Name );
                }
            }
            else Console.WriteLine("Not Succesfull");
        }
    }
}

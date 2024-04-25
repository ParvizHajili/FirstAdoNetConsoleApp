using FirstAdoNetConsoleApp.DataAccess.Concrete;
using FirstAdoNetConsoleApp.Entities;
using System.Data.SqlClient;
using System.Text;

namespace FirstAdoNetConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentRepository studentRepository = new ();
            StudentNumberRepository studentNumberRepository = new();
            Console.WriteLine("Enter number");
            Console.WriteLine("1-Add Student");
            Console.WriteLine("2-List Student");
            Console.WriteLine("3-Get Student");
            Console.WriteLine("4-Update Student");
            int userInputId = int.Parse(Console.ReadLine());

            if (userInputId == 1)
            {
                Console.WriteLine("Name");
                string name = Console.ReadLine();
                Console.WriteLine("Surname");
                string surName = Console.ReadLine();
                Console.WriteLine("Age");
                byte age = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Email");
                string email = Console.ReadLine();

                Student student = new()
                {
                    Name = name,
                    SurName = surName,
                    Age = age,
                    Email = email
                };

                studentRepository.Add(student);
            }
            if (userInputId == 2)
            {
                var studentList = studentRepository.Get();
                foreach (var item in studentList)
                {
                    Console.WriteLine($"{item.Id} {item.Name}");
                }

                Console.WriteLine("Enter StudentId");
                int studentId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Number");
                string number = Console.ReadLine();

                StudentNumber studentNumber = new()
                {
                    StudentId = studentId,
                    Number = number,
                };
                studentNumberRepository.Add(studentNumber);
                Console.WriteLine("Added");
            }

            #region Without Folder Structure



            //Console.OutputEncoding = Encoding.UTF8;
            //SqlConnectionStringBuilder sqlConnectionStr = new SqlConnectionStringBuilder();
            //sqlConnectionStr.DataSource = "Localhost";
            //sqlConnectionStr.InitialCatalog = "MyCourseDb";
            //sqlConnectionStr.IntegratedSecurity = true;

            //string connectionString = sqlConnectionStr.ConnectionString;

            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();
            //    string cmdText = @"Insert into Students 
            //                    values (N'Nurlanə',N'Mürşüdova',20,'nurlana@gmail.com')";

            //    using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
            //    {
            //        cmd.ExecuteNonQuery();
            //        Console.WriteLine("Məlumat uğurla əlavə olundu");
            //    }
            //}

            // Sql Injection
            //Console.WriteLine("Enter Name");
            //string name = Console.ReadLine();

            //Console.WriteLine("Enter Surname");
            //string surName = Console.ReadLine();

            //Console.WriteLine("Enter age");
            //int age = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter email");
            //string email = Console.ReadLine();

            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();
            //    string cmdText = $"Insert into Students values (N'{name}',N'{surName}',{age},'{email}')";

            //    using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
            //    {
            //        cmd.ExecuteNonQuery();
            //        Console.WriteLine("Məlumat uğurla əlavə olundu");
            //    }
            //}


            //Console.WriteLine("Enter Name");
            //string name = Console.ReadLine();

            //Console.WriteLine("Enter Surname");
            //string surName = Console.ReadLine();

            //Console.WriteLine("Enter age");
            //int age = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter email");
            //string email = Console.ReadLine();

            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();
            //    string cmdText = @"Insert into Students values (@name,@surName,@age,@email)";

            //    using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
            //    {
            //        cmd.Parameters.AddWithValue("@name", name);
            //        cmd.Parameters.AddWithValue("@surName", surName);
            //        cmd.Parameters.AddWithValue("@age", age);
            //        cmd.Parameters.AddWithValue("@email", email);

            //        cmd.ExecuteNonQuery();
            //        Console.WriteLine("Məlumat uğurla əlavə olundu");
            //    }
            //}
            //Console.WriteLine("Id daxil edin");
            //int userInputId = Convert.ToInt32(Console.ReadLine());
            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();
            //    string cmdText = @"Select name,Surname from Students";

            //    using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
            //    {
            //        //cmd.Parameters.AddWithValue("@userInputId", userInputId);
            //        SqlDataReader reader = cmd.ExecuteReader();

            //        while(reader.Read())
            //        {
            //            int id = reader.GetInt32(0);
            //            string name = reader.GetString(1);
            //            string surName = reader.GetString(2);
            //            byte age = reader.GetByte(3);
            //            string email = reader.GetString(4);

            //            Console.WriteLine($"{id}. {name} {surName} {age} {email} ");
            //        }
            //        //cmd.ExecuteNonQuery();
            //    }
            //}
            #endregion

        }
    }
}

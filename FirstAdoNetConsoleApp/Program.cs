using System.Data.SqlClient;
using System.Text;

namespace FirstAdoNetConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SqlConnectionStringBuilder sqlConnectionStr = new SqlConnectionStringBuilder();
            sqlConnectionStr.DataSource = "Localhost";
            sqlConnectionStr.InitialCatalog = "MyCourseDb";
            sqlConnectionStr.IntegratedSecurity = true;

            string connectionString = sqlConnectionStr.ConnectionString;

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
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string cmdText = @"Select * from Students";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    //cmd.Parameters.AddWithValue("@userInputId", userInputId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string surName = reader.GetString(2);
                        byte age = reader.GetByte(3);
                        string email = reader.GetString(4);

                        Console.WriteLine($"{id}. {name} {surName} {age} {email} ");
                    }
                    //cmd.ExecuteNonQuery();
                }
            }

        }
    }
}

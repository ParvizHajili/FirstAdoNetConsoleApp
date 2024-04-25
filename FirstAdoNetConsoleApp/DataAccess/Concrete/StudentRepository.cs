using FirstAdoNetConsoleApp.DataAccess.Abstract;
using FirstAdoNetConsoleApp.DataAccess.SqlDbContext;
using FirstAdoNetConsoleApp.Entities;
using System.Data.SqlClient;

namespace FirstAdoNetConsoleApp.DataAccess.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connection;
        public StudentRepository()
        {
            _connection = SqlDatabaseConnect.Connect();
        }

        public void Add(Student entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Insert into Students(Name,Surname,Age,Email)
                            values (@name,@surName,@age,@email)";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@name", entity.Name);
                    cmd.Parameters.AddWithValue("@surName", entity.SurName);
                    cmd.Parameters.AddWithValue("@age", entity.Age);
                    cmd.Parameters.AddWithValue("@email", entity.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Update Students set Deleted=@id where id=@id)";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Student Get(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Select * from Students where id=@id";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Student student = new Student();

                    if (reader.Read())
                    {
                        student.Name = Convert.ToString(reader["Name"]);
                        student.SurName = Convert.ToString(reader["Surname"]);
                        student.Email = Convert.ToString(reader["Email"]);
                        student.Age = Convert.ToByte(reader["Age"]);
                    }
                    return student;
                }
            }
        }

        public List<Student> Get()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Select * from Students where Deleted=0";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> studentList = new();

                    while (reader.Read())
                    {
                        Student student = new()
                        {
                            Id= Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                            SurName = Convert.ToString(reader["Surname"]),
                            Email = Convert.ToString(reader["Email"]),
                            Age = Convert.ToByte(reader["Age"]),
                        };
                        studentList.Add(student);
                    }
                    return studentList;
                }
            }
        }

        public void Update(Student entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Update Students set Name=@Name,
                                    Surname=@Surname, Age=@Age,Email= @Email where id=@id)";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id",entity.Id);
                    cmd.Parameters.AddWithValue("@Name",entity.Name);
                    cmd.Parameters.AddWithValue("@Surname", entity.SurName);
                    cmd.Parameters.AddWithValue("@Email",entity.Email);
                    cmd.Parameters.AddWithValue("@Age",entity.Age);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

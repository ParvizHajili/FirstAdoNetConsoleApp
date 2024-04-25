using FirstAdoNetConsoleApp.DataAccess.Abstract;
using FirstAdoNetConsoleApp.DataAccess.SqlDbContext;
using FirstAdoNetConsoleApp.Entities;
using System.Data.SqlClient;

namespace FirstAdoNetConsoleApp.DataAccess.Concrete
{
    public class StudentNumberRepository : IStudentNumberRepository
    {
        private readonly string _connection;
        public StudentNumberRepository()
        {
            _connection = SqlDatabaseConnect.Connect();
        }

        public void Add(StudentNumber entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Insert into StudentNumbers(Number,StudentId)
                                values (@Number,@StudentId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Number", entity.Number);
                    cmd.Parameters.AddWithValue("@StudentId", entity.StudentId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Update StudentNumbers set Deleted=@id where id=@id)";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public StudentNumber Get(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"select s.Name,s.Surname,sn.Number from StudentNumbers as sn
                                    inner join Students as s on sn.StudentId = s.Id 
                                    where sn.Id =@id ";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    StudentNumber studentNumber = new();

                    if (reader.Read())
                    {
                        studentNumber.Number = Convert.ToString(reader["sn.Number"]);
                        studentNumber.Student.Name = Convert.ToString(reader["s.Name"]);
                        studentNumber.Student.SurName = Convert.ToString(reader["s.Surname"]);
                    }
                    return studentNumber;
                }
            }
        }

        public List<StudentNumber> Get()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"select s.Name,s.Surname,sn.Number from StudentNumbers as sn
                                    inner join Students as s on sn.StudentId = s.Id 
                                    where s.Deleted =0 ";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<StudentNumber> studentNumberList = new();

                    while (reader.Read())
                    {
                        StudentNumber student = new();
                        student.Student.Name= Convert.ToString(reader["s.Name"]);
                        student.Student.SurName= Convert.ToString(reader["s.Surname"]);
                        student.Number= Convert.ToString(reader["sn.Number"]);

                        studentNumberList.Add(student);
                    };
                    
                    return studentNumberList;
                }
            }
        }

        public void Update(StudentNumber entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string cmdText = @"Update StudentNumbers set Number=@Number,
                                    StudentId=@StudentId where id=@id)";

                using (SqlCommand cmd = new SqlCommand(cmdText, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.Parameters.AddWithValue("@Number", entity.Number);
                    cmd.Parameters.AddWithValue("@StudentId", entity.StudentId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

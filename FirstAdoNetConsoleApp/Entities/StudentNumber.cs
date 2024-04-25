using FirstAdoNetConsoleApp.Entities.Abstract;

namespace FirstAdoNetConsoleApp.Entities
{
    public class StudentNumber : BaseEntity
    {
        public string Number { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

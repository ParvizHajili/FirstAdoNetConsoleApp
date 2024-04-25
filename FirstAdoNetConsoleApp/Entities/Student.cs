using FirstAdoNetConsoleApp.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace FirstAdoNetConsoleApp.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
    }
}

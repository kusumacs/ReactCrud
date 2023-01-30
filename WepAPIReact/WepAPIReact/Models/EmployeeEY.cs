using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Models
{
    public class EmployeeEY
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public int IsActive{ get; set; }

    }
}

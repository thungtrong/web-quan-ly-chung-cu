using System.ComponentModel;

namespace ManagerApartmentProject.Models
{
    [DefaultValueAttribute(null)]
    public class PersonModel
    {
        [DisplayName("ID")]
        public int ID { get; set; } = default(int);
        
        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }

    }
}
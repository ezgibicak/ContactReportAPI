using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Model
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Firm { get; set; }
        public List<ContactModel> Contacts { get; set; }
        public int PersonNumber { get; set; }
        public int SavedPhoneNumber { get; set; }

    }
}

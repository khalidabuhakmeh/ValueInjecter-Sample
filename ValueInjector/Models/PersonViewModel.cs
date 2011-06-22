using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValueInjector.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string Hobby { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProject.ViewModels
{
    public class ClientViewModel
    {
        public int Age { get; set; }
        public string Fullname { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Anh { get; set; }

    }
}
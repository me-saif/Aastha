using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aastha.Data.Models
{
    public class Student : BaseEntity
    {
        [Key]
        public long Student_Master_Id { get; set; }
        public string Student_Name { get; set; }
        public string Mobile_No { get; set; }
        public string Mobile_No2 { get; set; }
        public string Email_Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DOB { get; set; }
        public string College_Name { get; set; }
        public string Course { get; set; }
        public string Batch { get; set; }
        public decimal? Total_Fee { get; set; }
        public string IsActive { get; set; }
        public bool SentSMS { get; set; }
        public DateTime? SMS_Expiration { get; set; }
        public string DOBdd { get; set; }
        public string DOBmm { get; set; }
        public string DOByy { get; set; }
        public string Password { get; set; }

    }
}

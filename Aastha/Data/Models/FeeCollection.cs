using System;
using System.ComponentModel.DataAnnotations;

namespace Aastha.Data.Models
{
    public class FeeCollection
    {
        [Key]
        public long FeeCollection_Master_Id { get; set; }
        public string Transaction_No { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Transaction_Time { get; set; }
        public long Student_Master_Id { get; set; }
        public decimal Paid_Amount { get; set; }
        public string Payment_Mode { get; set; }
        public string Cheque_No { get; set; }
        public DateTime Cheque_Date { get; set; }
        public string Bank_Name { get; set; }
    }
}
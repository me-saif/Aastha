using System;

namespace Aastha.Data.Models
{
    public class BaseEntity
    {
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Modified_By { get; set; }
        public DateTime? Modified_Date { get; set; }
    }
}

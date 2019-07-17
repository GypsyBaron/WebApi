using System;

namespace WebApi_Aurimas.Models
{
    public class HugModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Reason { get; set; }
        public DateTime Created { get; set; }
        public int Id { get; set; }
    }
}

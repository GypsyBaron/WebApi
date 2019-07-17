using System.Collections.Generic;

namespace HugDb.Entities
{
    public class Committee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserCommittee> UserCommittees { get; set; }
        public List<Hug> Hugs { get; set; }
    }
}

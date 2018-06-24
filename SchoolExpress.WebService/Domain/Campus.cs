using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Campus : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}
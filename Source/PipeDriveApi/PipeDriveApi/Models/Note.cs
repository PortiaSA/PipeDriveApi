using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeDriveApi
{
    public class Note : BaseEntity
    {
		public int UserId { get; set; }
		public int DealId { get; set; }
		public int PersonId { get; set; }
        public int OrgId { get; set; }
        public string Content { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool ActiveFlag { get; set; }
        public bool PinnedToDealFlag { get; set; }
        public bool PinnedToPersonFlag { get; set; }
        public bool PinnedToOrganizationFlag { get; set; }
        public int? LastUpdateUserId { get; set; }
		public OrganizationId Organization { get; set; }
		public PersonId Person { get; set; }
		public Deal Deal { get; set; }
		public Owner User { get; set; }
    }
}

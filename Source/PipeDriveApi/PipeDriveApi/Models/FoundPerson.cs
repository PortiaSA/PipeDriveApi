using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeDriveApi
{
    public class FoundPerson : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? OrgId { get; set; }
        public string OrgName { get; set; }
        public string VisibleTo { get; set; }
    }
}

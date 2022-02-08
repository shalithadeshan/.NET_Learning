using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertex.EMS.Domain.Model
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // these follwing 4 is called audit field
        public string CreatedUser { get; set; } = string.Empty;
        public string ModifiefiedUser { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; } = DateTime.UnixEpoch;
    }
}

using NBP.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int? paymentId { get; set; }
        public DateTime? Date { get; set; }
        public string? memberName { get; set; }

        [ForeignKey("Receptionist")]
        public int? ID { get; set; }
        public Receptionist? Receptionist { get; set; }

    }
}

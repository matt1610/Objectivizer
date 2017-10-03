using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Objectivizer.Models
{
    public class Organisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ParentOrgId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("ParentOrgId")]
        public virtual Organisation ParentOrganization { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
        public Weight Weight { get; set; }
    }

    public enum Weight
    {
        Company,
        Group,
        Team
    }
}
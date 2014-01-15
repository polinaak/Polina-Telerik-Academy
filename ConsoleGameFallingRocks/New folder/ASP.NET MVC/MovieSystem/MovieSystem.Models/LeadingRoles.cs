using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Models
{
    public class LeadingRoles
    {
        [Key]
        public int LeadingRolesId { get; set; }

        public string MaleRole { get; set; }

        public int MaleRoleAge { get; set; }

        public string FemaleRole { get; set; }

        public int FemaleRoleAge { get; set; }
    }
}

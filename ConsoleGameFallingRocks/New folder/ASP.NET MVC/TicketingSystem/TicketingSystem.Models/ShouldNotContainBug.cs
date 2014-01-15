using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicketingSystem.Models
{
    public class ShouldNotContainBug : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return true;
            }

            if (valueAsString.ToLower().Contains("bug"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

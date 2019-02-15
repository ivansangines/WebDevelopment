using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCRoutes.Models
{
    public class ProdNameAttribute : ValidationAttribute
    {
        public int MinimLength { get; set; }
        public int MaximLength { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            var nm = (string)value;
            if ((nm.Length < MinimLength) || (nm.Length > MaximLength))
            {
                return false;
            }
            return true;
        }
    }
}
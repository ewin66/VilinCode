using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;

namespace Vilin.Mvc.Models
{
    [Description("订单信息")]
    public class OrderViewModel
    {
        [Required(ErrorMessage = "*OrderCode")]
        [StringLength(20)]
        public string OrderCode { get; set; }

        [Required(ErrorMessage = "*ProductCode")]
        [StringLength(20)]
        public string ProductCode { get; set; }
    }
}
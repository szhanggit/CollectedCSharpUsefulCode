using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessingServer.Models
{
    public class CheckAccountExistsViewModel
    {
        public bool IsSuccess { get; set; }
        public string ErrorMsg { get; set; }
    }
}
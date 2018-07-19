using System;
using System.Collections.Generic;
using System.Text;

namespace Medico.Challange.Services.Models
{
    public class BaseResultViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Extra { get; set; }
    }
}

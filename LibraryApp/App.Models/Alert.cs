using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public enum AlertType
    {
        Error,
        Info,
        Warning,
        Success
    }

    public class Alert
    {
        public AlertType Type { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }

        public Alert()
        {;
            Dismissable = true;
        }
        public Alert(AlertType type, string message)
        {
            Type = type;
            Message = message;
            Dismissable = true;
        }
    }  
}
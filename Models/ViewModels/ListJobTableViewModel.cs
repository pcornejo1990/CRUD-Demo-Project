using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Demo_Project.Models.ViewModels
{
    public class ListJobTableViewModel
    {
        public string Job { get; set; }
        public string JobTile { get; set; }
        public string JobDescription { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        
    }
}
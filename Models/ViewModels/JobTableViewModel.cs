using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Demo_Project.Models.ViewModels
{
    public class JobTableViewModel
    {
        [Required]
        [Display(Name = "Job")]
        public string Job { get; set; }

        [Display(Name = "Job title")]
        public string JobTile { get; set; }

        [Display(Name = "Description")]
        public string JobDescription { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "From date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FromDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "To date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ToDate { get; set; }
    }
}
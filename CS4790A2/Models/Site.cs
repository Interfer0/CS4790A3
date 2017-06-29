using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790A3.Models
{
    public class Site
    {
        public int SiteID { get; set; }

        [Required(ErrorMessage = "Enter Site Name")]
        [Display(Name = "Site Name")]
        public string siteName { get; set; }
        [Display(Name = "Site Description")]
        [Required(ErrorMessage = "Site Description Required")]
        public string siteDescription { get; set; }
        [Display(Name = "Land Type")]
        [Required(ErrorMessage = "Land Type Required")]
        public string siteLandType { get; set; }
        [Display(Name = "Site Uses")]
        public string siteUses { get; set; }
        [Display(Name = "Water Available")]
        [Required(ErrorMessage = "Water nearby information Required")]
        public Boolean siteWater { get; set; }
        [Display(Name = "Nearest Gas")]
        [Required(ErrorMessage = "How close is the nearest gas station?")]
        public int siteGas { get; set; }
        [Display(Name = "OHV Required")]
        [Required(ErrorMessage = "Does this site require an Offroad vehicle to access?")]
        public Boolean siteOffroad { get; set; }
        [Display(Name = "Site Longitude")]
        [Required(ErrorMessage = "Longitude Required")]
        public double siteLong { get; set; }
        [Display(Name = "Site Latitude")]
        [Required(ErrorMessage = "Latitude Required")]
        public double siteLat { get; set; }
        [Display(Name = "Is Site Level?")]
        public Boolean siteLevel { get; set; }
        [Display(Name = "Cost of Site")]
        public double siteCost { get; set; }
        [Display(Name = "Image Location")]
        public string imglocation { get; set; }
        public string imgthumblocation { get; set; }
        [Display(Name = "Is Site Available")]
        public Boolean siteAvailable { get; set; }
       

        public ICollection<Comment> Comments { get; set; }
    

        
        
    }
}

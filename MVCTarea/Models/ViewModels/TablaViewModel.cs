using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTarea.Models.ViewModels
{
    public class TablaViewModel
    {

        [Required]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

       
    }
}
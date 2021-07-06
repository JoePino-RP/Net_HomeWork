using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTarea.Models.ViewModels
{
    public class ListTablaViewModel
    {        
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Cargo { get; set; }
        public int Id { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SasaServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Catalog
    {
        public int Id { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public int costPerDay { get; set; }
        public int costPerLate { get; set; }
        public string gearbox { get; set; }
        public int PhotoNumber { get; set; }
        public string availability { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual Cars Cars1 { get; set; }
    }
}

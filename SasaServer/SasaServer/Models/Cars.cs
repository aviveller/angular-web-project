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
    
    public partial class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            this.Rent = new HashSet<Rent>();
        }
    
        public int Id { get; set; }
        public int licensePlate { get; set; }
        public int km { get; set; }
        public bool isProper { get; set; }
        public bool availability { get; set; }
        public int location { get; set; }
    
        public virtual Location Location1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent> Rent { get; set; }
        public virtual Catalog Catalog { get; set; }
    }
}

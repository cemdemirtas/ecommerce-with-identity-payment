//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_kategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_kategori()
        {
            this.tbl_urunler = new HashSet<tbl_urunler>();
            this.tbl_urunler1 = new HashSet<tbl_urunler>();
            this.tbl_urunler2 = new HashSet<tbl_urunler>();
            this.tbl_urunler3 = new HashSet<tbl_urunler>();
        }
    
        public int id { get; set; }
        public string kategoriad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_urunler> tbl_urunler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_urunler> tbl_urunler1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_urunler> tbl_urunler2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_urunler> tbl_urunler3 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SACLA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paper
    {
        public int PaperId { get; set; }
        public string PaperTitle { get; set; }
        public string PaperAbstract { get; set; }
        public string PaperAuthor { get; set; }
        public System.DateTime PaperDateSubmitted { get; set; }
        public Nullable<int> TopicId { get; set; }
    
        public virtual topic topic { get; set; }
    }
}

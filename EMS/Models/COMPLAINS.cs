//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMSClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMPLAINS
    {
        public int ComplainId { get; set; }
        public string EmployeeId { get; set; }
        public int ComplainTypeId { get; set; }
        public string ComplainDescription { get; set; }
        public string ComplainStatus { get; set; }
        public Nullable<int> FeedbackRating { get; set; }
        public string feedbackDescription { get; set; }
        public Nullable<System.DateTime> ComplainDate { get; set; }
    }
}

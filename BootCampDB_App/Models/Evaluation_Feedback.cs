//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BootCampDB_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evaluation_Feedback
    {
        public int Eval_id { get; set; }
        public string Evaluator_DasId { get; set; }
        public Nullable<int> Candidate_Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Screening_Level { get; set; }
        public string Feekback { get; set; }
        public string Comments { get; set; }
    
        public virtual Candidate Candidate { get; set; }
        public virtual Interviewer Interviewer { get; set; }
    }
}
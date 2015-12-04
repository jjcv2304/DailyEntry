using System;
using System.Collections.Generic;

namespace PowerTools.Models
{
    public partial class DiaryUser
    {
        public DiaryUser()
        {
            this.tblDiaryFeelings = new List<tblDiaryFeeling>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public virtual ICollection<tblDiaryFeeling> tblDiaryFeelings { get; set; }
    }
}

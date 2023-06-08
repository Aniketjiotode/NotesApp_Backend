using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class ColaboratorModel
    {
        public int ColaboratorId { get; set; }
        public string EmailId { get; set; }
        public long  NoteId { get; set; }
        public long UserId { get; set; } 
    }
}

using System;

namespace ApplyOnline.Models
{
    public class PostsContent
    {

        public int PkPostEntryId { get; set; }
        public string PostSubject { get; set; }
        public string PostBody { get; set; }
        public DateTime PostEntryDate { get; set; }
    }
}
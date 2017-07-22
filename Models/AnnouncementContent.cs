using System;

namespace ApplyOnline.Models
{
    public class AnnouncementContent
    {

        public int PkAnnouncementEntryId { get; set; }
        public string AnnouncementSubject { get; set; }
        public string AnnouncementBody { get; set; }
        public DateTime AnnouncementEntryDate { get; set; }
    }
}
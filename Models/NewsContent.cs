using System;

namespace ApplyOnline.Models
{
    public class NewsContent
    {

        public int PkNewsEntryId { get; set; }
        public string NewsSubject { get; set; }
        public string NewsBody { get; set; }
        public DateTime NewsEntryDate { get; set; }
    }


}
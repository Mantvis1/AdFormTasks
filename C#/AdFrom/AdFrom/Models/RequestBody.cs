using System.Collections.Generic;

namespace AdFrom.Models
{
    public class RequestBodyPart
    {
        public IList<string> Metrics { get; set; }
        public IList<string> Dimensions { get; set; }
        public Filter Filter { get; set; }
    }
}

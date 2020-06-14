using System.Collections.Generic;

namespace AdFrom.Models
{
    public class RequestBodyPart
    {
        public List<string> Metrics = new List<string>();
        public List<string> Dimensions = new List<string>();
        public Filter Filter { get; set; }
    }
}

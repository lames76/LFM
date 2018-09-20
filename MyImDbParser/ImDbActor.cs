using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImDbParser
{
    public class MyActor
    {
        public string @context { get; set; }
        public string @type { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public List<string> jobTitle { get; set; }
        public string description { get; set; }
        public string birthDate { get; set; }

        public MyActor()
        {
            jobTitle = new List<string>();
        }
    }
    

    public class MyActorSingle
    {
        public string @context { get; set; }
        public string @type { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string jobTitle { get; set; }
        public string description { get; set; }
        public string birthDate { get; set; }
    }
}

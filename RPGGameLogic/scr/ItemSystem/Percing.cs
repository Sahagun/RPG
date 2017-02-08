using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGameLogic.ItemSystem
{
    public enum PercingLocation { Lip, Nose, Ear, Eyebrow }
    public enum PercingType { Stud }
    public class Percing
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songe_unconverter.Classes
{
    public class DifficultyDat
    {
        public string _version { get; set; }
        public List<BPMChange> _BPMChanges { get; set; }
        public List<Event> _events { get; set; }
        public List<Note> _notes { get; set; }
        public List<Obstacle> _obstacles { get; set; }
        public List<Bookmark> _bookmarks { get; set; }
    }
}

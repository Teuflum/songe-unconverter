using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songe_unconverter.Classes
{
    public class DifficultyJson
    {
        public string _version { get; set; } = "1.6.0";
        public double _beatsPerMinute { get; set; }
        public double _beatsPerBar { get; set; } = 16;
        public double _noteJumpSpeed { get; set; }
        public double _noteJumpStartBeatOffset { get; set; }
        public double _shuffle { get; set; }
        public double _shufflePeriod { get; set; }
        public List<string> _warnings { get; set; } = new List<string>();
        public List<string> _information { get; set; } = new List<string>();
        public List<string> _suggestions { get; set; } = new List<string>();
        public List<string> _requirements { get; set; } = new List<string>();
        public List<Event> _events { get; set; } = new List<Event>();
        public List<Note> _notes { get; set; } = new List<Note>();
        public List<Obstacle> _obstacles { get; set; } = new List<Obstacle>();
        public double _time { get; set; } = 0;
        public List<BPMChange> _BPMChanges { get; set; } = new List<BPMChange>();
        public List<Bookmark> _bookmarks { get; set; } = new List<Bookmark>();
        [JsonIgnore]
        public string FileName { get; set; }
    }
}

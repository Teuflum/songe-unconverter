using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songe_unconverter.Classes
{
    public class Event
    {
        public double _time { get; set; }
        public int _type { get; set; }
        public int _value { get; set; }
    }

    public class Note
    {
        public double _time { get; set; }
        public int _lineIndex { get; set; }
        public int _lineLayer { get; set; }
        public int _type { get; set; }
        public int _cutDirection { get; set; }
    }

    public class Obstacle
    {
        public double _time { get; set; }
        public int _lineIndex { get; set; }
        public int _type { get; set; }
        public double _duration { get; set; }
        public int _width { get; set; }
    }

    public class BPMChange
    {
        public double _BPM { get; set; }
        public double _time { get; set; }
        public double _beatsPerBar { get; set; }
        public double _metronomeOffset { get; set; }
    }

    public class Bookmark
    {
        public double _time { get; set; }
        public string _name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songe_unconverter.Classes
{
    public class InfoDat
    {
        public string _version { get; set; }
        public string _songName { get; set; }
        public string _songSubName { get; set; }
        public string _songAuthorName { get; set; }
        public string _levelAuthorName { get; set; }
        public double _beatsPerMinute { get; set; }
        public double _songTimeOffset { get; set; }
        public double _shuffle { get; set; }
        public double _shufflePeriod { get; set; }
        public double _previewStartTime { get; set; }
        public double _previewDuration { get; set; }
        public string _songFilename { get; set; }
        public string _coverImageFilename { get; set; }
        public string _environmentName { get; set; }
        public CustomData _customData { get; set; }
        public List<DifficultyBeatmapSet> _difficultyBeatmapSets { get; set; }

        public class CustomData
        {
            public List<Contributor> _contributors { get; set; }
            public string _customEnvironment { get; set; }
            public string _customEnvironmentHash { get; set; }
        }

        public class Contributor
        {
            public string _role { get; set; }
            public string _name { get; set; }
            public string _iconPath { get; set; }
        }

        public class DifficultyBeatmapSet
        {
            public string _beatmapCharacteristicName { get; set; }
            public List<DifficultyBeatmap> _difficultyBeatmaps { get; set; }
        }

        public class DifficultyBeatmap
        {
            public string _difficulty { get; set; }
            public int _difficultyRank { get; set; }
            public string _beatmapFilename { get; set; }
            public double _noteJumpMovementSpeed { get; set; }
            public double _noteJumpStartBeatOffset { get; set; }
            public CustomDataBeatmap _customData { get; set; }
        }

        public class CustomDataBeatmap
        {
            public string _difficultyLabel { get; set; }
            public int _editorOffset { get; set; }
            public int _editorOldOffset { get; set; }
            public List<string> _warnings { get; set; }
            public List<string> _information { get; set; }
            public List<string> _suggestions { get; set; }
            public List<string> _requirements { get; set; }
        }
    }
}

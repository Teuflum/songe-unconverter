using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songe_unconverter.Classes
{
    public class InfoJson
    {
        public string songName { get; set; }
        public string songSubName { get; set; }
        public string authorName { get; set; }
        public List<Contributor> contributors { get; set; } = new List<Contributor>();
        public double beatsPerMinute { get; set; }
        public double previewStartTime { get; set; }
        public double previewDuration { get; set; }
        public string coverImagePath { get; set; }
        public string environmentName { get; set; }
        public bool oneSaber { get; set; } = false;
        public string customEnvironment { get; set; }
        public string customEnvironmentHash { get; set; }
        public List<DifficultyLevel> difficultyLevels { get; set; } = new List<DifficultyLevel>();

        public class Contributor
        {
            public string role { get; set; }
            public string name { get; set; }
            public string iconPath { get; set; }
        }

        public class DifficultyLevel
        {
            public string difficulty { get; set; }
            public int difficultyRank { get; set; }
            public string audioPath { get; set; }
            public string jsonPath { get; set; }
            public int offset { get; set; }
            public int oldOffset { get; set; }
            public string chromaToggle { get; set; } = "Off";
            public bool customColors { get; set; } = false;
            public string characteristic { get; set; }
            public string difficultyLabel { get; set; }
        }
    }
}

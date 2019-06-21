using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songe_unconverter.Classes
{
    public class Converter
    {
        public static Tuple<InfoJson,List<DifficultyJson>> ConvertInfo(InfoDat infoDat, string folderPath)
        {
            List<DifficultyJson> diffJsons = new List<DifficultyJson>();
            InfoJson info = new InfoJson
            {
                songName = $"{infoDat._songName}{(string.IsNullOrWhiteSpace(infoDat._songSubName) ? "" : $" {infoDat._songSubName}")}",
                songSubName = infoDat._songAuthorName,
                authorName = infoDat._levelAuthorName,
                beatsPerMinute = infoDat._beatsPerMinute,
                previewStartTime = infoDat._previewStartTime,
                previewDuration = infoDat._previewDuration,
                coverImagePath = infoDat._coverImageFilename,
                environmentName = infoDat._environmentName,
                customEnvironment = infoDat._customData?._customEnvironment ?? "",
                customEnvironmentHash = infoDat._customData?._customEnvironmentHash ?? ""
            };
            if (infoDat._customData != null)
            {
                foreach (var contrib in infoDat._customData._contributors) // Contributors
                {
                    info.contributors.Add(new InfoJson.Contributor
                    {
                        role = contrib._role,
                        name = contrib._name,
                        iconPath = contrib._iconPath
                    });
                }
            }

            foreach (var set in infoDat._difficultyBeatmapSets) // Difficulty Sets
            {
                foreach (var diff in set._difficultyBeatmaps) // Actual Difficulties
                {
                    var diffLevel = new InfoJson.DifficultyLevel
                    {
                        difficulty = diff._difficulty,
                        difficultyRank = ConvertDifficultyRank(diff._difficultyRank),
                        audioPath = infoDat._songFilename.Replace(".egg", ".ogg"),
                        jsonPath = diff._beatmapFilename.Replace(".dat",".json"),
                        offset = diff._customData?._editorOffset ?? 0,
                        oldOffset = diff._customData?._editorOldOffset ?? 0,
                        characteristic = GetNewCharacteristic(set._beatmapCharacteristicName),
                        difficultyLabel = diff._customData?._difficultyLabel ?? ""
                    };
                    info.difficultyLevels.Add(diffLevel);

                    diffJsons.Add(ConvertDifficulty(infoDat, diff,
                        JsonConvert.DeserializeObject<DifficultyDat>(File.ReadAllText(Path.Combine(folderPath, diff._beatmapFilename)))));
                }
            }

            return new Tuple<InfoJson, List<DifficultyJson>>(info, diffJsons);
        }

        public static DifficultyJson ConvertDifficulty(InfoDat infoDat, InfoDat.DifficultyBeatmap diffBeatmap, DifficultyDat diffDat)
        {
            return new DifficultyJson
            {
                _beatsPerMinute = infoDat._beatsPerMinute,
                _noteJumpSpeed = diffBeatmap._noteJumpMovementSpeed,
                _noteJumpStartBeatOffset = diffBeatmap._noteJumpStartBeatOffset,
                _shuffle = infoDat._shuffle,
                _shufflePeriod = infoDat._shufflePeriod,
                _warnings = diffBeatmap._customData?._warnings,
                _information = diffBeatmap._customData?._information,
                _suggestions = diffBeatmap._customData?._suggestions,
                _requirements = diffBeatmap._customData?._requirements,
                _events = diffDat._events,
                _notes = diffDat._notes,
                _obstacles = diffDat._obstacles,
                _BPMChanges = diffDat._BPMChanges,
                _bookmarks = diffDat._bookmarks,
                FileName = diffBeatmap._beatmapFilename.Replace(".dat", ".json")
            };
        }

        private static string GetNewCharacteristic(string oldCharacteristic)
        {
            switch (oldCharacteristic)
            {
                case "NoArrows":
                   return "No Arrows";
                case "OneSaber":
                    return "One Saber";
                case "Lightshow":
                    return "Lightshow";
                case "Lawless":
                    return "Lawless";
                case "Standard":
                default:
                    return "Standard";
            }
        }

        private static int ConvertDifficultyRank(int rank)
        {
            switch (rank)
            {
                case 9: // Expert+
                    return 5;
                case 7: // Expert
                    return 4;
                case 5: // Hard
                    return 3;
                case 3: // Normal
                    return 2;
                case 1: // Easy
                default:
                    return 1;
            }
        }
    }
}

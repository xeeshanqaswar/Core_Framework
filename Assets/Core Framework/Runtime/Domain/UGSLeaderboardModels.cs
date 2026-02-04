using System;
using UnityEngine;

namespace Core.Framework
{
    public class ScoreMetaData
    {
    
    }

    public class LeaderboardEntryData
    {
        public string playerId;
        public string playerName;
        public int rank;
        public double score;
        public string tier;
        public DateTime updatedTime;
        public string metadata;
    }
}

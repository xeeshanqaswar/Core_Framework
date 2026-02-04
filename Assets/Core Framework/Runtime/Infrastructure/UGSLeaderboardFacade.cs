using Unity.Services.Core;
using UnityEngine;
using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using System.Collections.Generic;
using VContainer.Unity;

namespace Core.Framework
{
    public class UGSLeaderboardFacade
    {
        public const string LEADERBOARD_ID = "Weekly_Leaderboard";
        
        public async void AddScore(int score, ScoreMetaData metaData = null)
        {
            var playerEntry = await LeaderboardsService.Instance.AddPlayerScoreAsync(
                LEADERBOARD_ID,
                score,
                new AddPlayerScoreOptions { Metadata = metaData }
                );
        }

        public async Task<LeaderboardEntryData> GetPlayerScore()
        {
            var playerEntry = await LeaderboardsService.Instance.GetPlayerScoreAsync(
                LEADERBOARD_ID, 
                new GetPlayerScoreOptions {
                IncludeMetadata = true }
                );
            
            return BuildLeaderboardEntry(playerEntry);
        }

        public async Task<List<LeaderboardEntryData>> GetPlayers(int range, int start = 0, bool metadata = false)
        {
            var response = await LeaderboardsService.Instance.GetScoresAsync(
                LEADERBOARD_ID,
                new GetScoresOptions
                {
                    Limit = range,
                    Offset = start,
                    IncludeMetadata = metadata,
                });
            
            return BuildLeaderboardEntry(response.Results);
        }
        
        public async Task<List<LeaderboardEntryData>> GetPlayersAround(int limit, bool metadata = false)
        {
            var response = await LeaderboardsService.Instance.GetPlayerRangeAsync(
                LEADERBOARD_ID,
                new GetPlayerRangeOptions
                {
                    RangeLimit = limit,
                    IncludeMetadata = metadata
                });

            return BuildLeaderboardEntry(response);
        }

        public async Task<List<LeaderboardEntryData>> GetOtherPlayerById(List<string> playerIds)
        {
            var response = await LeaderboardsService.Instance.GetScoresByPlayerIdsAsync(
                LEADERBOARD_ID,
                playerIds);

            return BuildLeaderboardEntry(response.Results);
        }
        
        #region PRIVATE METHODS

        private LeaderboardEntryData BuildLeaderboardEntry(LeaderboardEntry entry)
        {
            if (entry == null)
                Debug.LogWarning("LeaderboardEntry is null");
            
            return new LeaderboardEntryData
            {
                playerId = entry.PlayerId,
                playerName = entry.PlayerName,
                rank = entry.Rank,
                score = entry.Score,
                tier = entry.Tier,
                updatedTime = entry.UpdatedTime,
                metadata = entry.Metadata
            };
        }
        
        private List<LeaderboardEntryData> BuildLeaderboardEntry(LeaderboardScores scores)
        {
            if (scores == null)
                Debug.LogWarning("LeaderboardEntries are null");
            
            List<LeaderboardEntryData> entries = new List<LeaderboardEntryData>();

            foreach (var entry in scores.Results)
                entries.Add(BuildLeaderboardEntry(entry));
            
            return entries;
        }
        
        private List<LeaderboardEntryData> BuildLeaderboardEntry(List<LeaderboardEntry> scores)
        {
            if (scores == null)
                Debug.LogWarning("LeaderboardEntries are null");
            
            List<LeaderboardEntryData> entries = new List<LeaderboardEntryData>();

            foreach (var entry in scores)
                entries.Add(BuildLeaderboardEntry(entry));
            
            return entries;
        }

        #endregion
        
    }
}


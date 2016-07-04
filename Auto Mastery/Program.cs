using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace AutoMastery
{
    class Program
    {
        static void Main(string[] args) { Loading.OnLoadingComplete += Loading_OnLoadingComplete; }
        private static AIHeroClient myhero { get { return ObjectManager.Player; } }
        private static int CurrentKills, TotalKills;
        private static bool UsedEmote;
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print("<font color='#0080FF'>Speedy50 (Draven)</font>: Auto Mastery Loaded! (v1.0)");
            Chat.Print("by Speedy50");
            Game.OnUpdate += OnUpdate;
            TotalKills = 0;
        }
        private static void OnUpdate(EventArgs args)
        {
            if (myhero.IsDead) return;

            CurrentKills = myhero.ChampionsKilled;

            if (CurrentKills == TotalKills)
            {
                UsedEmote = false;
            }

            if (CurrentKills > TotalKills && UsedEmote == false)
            {
                Chat.Say("/masterybadge");
                UsedEmote = true;
                TotalKills = CurrentKills;
            }
        }
    }
}
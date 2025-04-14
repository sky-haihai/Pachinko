using GameConstant;
using UI.Element;
using UnityEngine;
using UnityEngine.UI;
using XiheFramework.Core.UI.UIEntity;
using XiheFramework.Runtime;

namespace UI.Layout {
    public class PachinkoControlPage : UIPageEntity {
        public PlayerStatsBarElement strengthBar;
        public PlayerStatsBarElement intelligenceBar;
        public PlayerStatsBarElement emoIntelligenceBar;
        public PlayerStatsBarElement imaginationBar;
        public PlayerStatsBarElement happinessBar;

        public override void OnInitCallback() {
            base.OnInitCallback();

            strengthBar.statType = PlayerStatsType.Strength;
            intelligenceBar.statType = PlayerStatsType.Intelligence;
            emoIntelligenceBar.statType = PlayerStatsType.EmoIntelligence;
            imaginationBar.statType = PlayerStatsType.Imagination;
            happinessBar.statType = PlayerStatsType.Happiness;

            strengthBar.RefreshStat();
            intelligenceBar.RefreshStat();
            emoIntelligenceBar.RefreshStat();
            imaginationBar.RefreshStat();
            happinessBar.RefreshStat();
        }
    }
}
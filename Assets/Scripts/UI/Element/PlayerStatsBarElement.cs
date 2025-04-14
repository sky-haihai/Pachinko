using GameConstant;
using TMPro;
using UnityEngine.UI;
using XiheFramework.Core.UI.UIEntity;
using XiheFramework.Runtime;

namespace UI.Element {
    public class PlayerStatsBarElement : UIElementEntity {
        public PlayerStatsType statType;
        public Slider slider;
        public TMP_Text titleText;
        public TMP_Text lastThresholdText;
        public TMP_Text currentThresholdText;
        public TMP_Text statsGradeText;

        public void RefreshStat() {
            // Game.Blackboard.GetData<float>()
            titleText.text= statType.ToString();
            slider.value = 0f;
            lastThresholdText.text = "0";
            currentThresholdText.text = "10";
            statsGradeText.text = "F";
        }

        public override void OnInitCallback() {
            base.OnInitCallback();

            Game.Event.Subscribe(EventNames.OnPlayerStatChanged, OnPlayerStatChanged);
        }

        private void OnPlayerStatChanged(object sender, object e) {
            RefreshStat();
        }
    }
}
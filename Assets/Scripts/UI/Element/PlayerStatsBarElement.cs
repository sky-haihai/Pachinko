using GameConstant;
using XiheFramework.Core.UI.UIEntity;
using XiheFramework.Runtime;

namespace UI.Element {
    public class PlayerStatsBarElement : UIElementEntity {
        public int statTypeId;
        public override void OnInitCallback() {
            base.OnInitCallback();

            Game.Event.Subscribe(EventNames.OnPlayerStatChanged, OnPlayerStatChanged);
        }

        private void OnPlayerStatChanged(object sender, object e) {
            //todo:refresh stat
            
        }
    }
}
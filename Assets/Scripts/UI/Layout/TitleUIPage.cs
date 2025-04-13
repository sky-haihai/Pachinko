using System.Collections;
using GameConstant;
using XiheFramework.Core.UI.UIEntity;
using XiheFramework.Runtime;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace UI.Layout {
    public class TitleUIPage : UIPageEntity {
        public Image knobImage;
        public Button startButton;

        public override void OnInitCallback() {
            base.OnInitCallback();

            startButton.onClick.AddListener(() => {
                // switch to main game state
                StartCoroutine(RotateKnobCo(2f));
            });
        }

        IEnumerator RotateKnobCo(float duration) {
            var time = 0f;
            while (time < duration) {
                knobImage.transform.Rotate(0, 0, -1f);
                time += Game.LogicTime.ScaledDeltaTime;
                yield return null;
            }

            Game.Fsm.ChangeState(GameLoopStatesNames.GameLoopFsm, GameLoopStatesNames.Game);
        }
    }
}
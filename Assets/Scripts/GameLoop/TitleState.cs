using GameConstant;
using UnityEngine;
using UnityEngine.SceneManagement;
using XiheFramework.Core.FSM;
using XiheFramework.Runtime;

namespace GameLoop {
    public class TitleState : State<MonoBehaviour> {
        public TitleState(StateMachine parentStateMachine, MonoBehaviour owner) : base(parentStateMachine, owner) { }

        public override void OnEnter() {
            //load title scene
            Game.Scene.LoadScene(ResourceAddresses.Scene_Title, LoadSceneMode.Single, () => {
                //open title page
                Game.UI.OpenPage(ResourceAddresses.UILayout_TitleUIPage);
            });
        }

        public override void OnUpdate() { }

        public override void OnExit() { }
    }
}
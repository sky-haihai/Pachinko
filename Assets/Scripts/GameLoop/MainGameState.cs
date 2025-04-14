using GameConstant;
using UnityEngine;
using UnityEngine.SceneManagement;
using XiheFramework.Core.Config;
using XiheFramework.Core.FSM;
using XiheFramework.Runtime;

namespace GameLoop {
    public class MainGameState : State<MonoBehaviour> {
        public MainGameState(StateMachine parentStateMachine, MonoBehaviour owner) : base(parentStateMachine, owner) { }

        public override void OnEnter() {
            Game.Scene.LoadScene(ResourceAddresses.Scene_Game, LoadSceneMode.Single, InitGame);
        }

        private void InitGame() {
            Game.UI.OpenPage(ResourceAddresses.UILayout_PachinkoControlPage);
        }

        public override void OnUpdate() {
            if (Game.Input(0).GetButtonUp("Fire")) {
                //spawn 20 x 5 ball array
                for (int i = 0; i < 20; i++) {
                    for (int j = 0; j < 5; j++) {
                        var rootPos = new Vector3(-32, 10, 0);
                        Game.Entity.InstantiateEntity(ResourceAddresses.BallEntity_GeneralBall, rootPos + new Vector3(2 * i, 2 * j, 0));
                    }
                }
            }
        }

        public override void OnExit() { }
    }
}
using GameConstant;
using UnityEngine;
using XiheFramework.Runtime;

namespace GameLoop {
    public class StartMainLoop : MonoBehaviour {
        private string m_EventHandlerId;

        private void Start() {
            m_EventHandlerId = Game.Event.Subscribe(Game.Resource.onDefaultResourcesLoadedEvtName, OnDefaultResourcesLoaded);
        }

        private void OnDefaultResourcesLoaded(object sender, object e) {
            var fsm = Game.Fsm.CreateStateMachine(GameLoopStatesNames.GameLoopFsm);
            fsm.AddState(GameLoopStatesNames.Entry, new EntryState(fsm, Game.Fsm)); //play logo
            fsm.AddState(GameLoopStatesNames.Title, new TitleState(fsm, Game.Fsm)); //enter title screen
            fsm.AddState(GameLoopStatesNames.Game, new MainGameState(fsm, Game.Fsm)); //main pachinko game
            fsm.SetDefaultState(GameLoopStatesNames.Entry);
            fsm.Start();
        }

        private void OnDestroy() {
            Game.Event.Unsubscribe(Game.Resource.onDefaultResourcesLoadedEvtName, m_EventHandlerId);
        }
    }
}
using GameConstant;
using UnityEngine;
using XiheFramework.Core.FSM;
using XiheFramework.Runtime;

namespace GameLoop {
    public class EntryState : State<MonoBehaviour> {
        public EntryState(StateMachine parentStateMachine, MonoBehaviour owner) : base(parentStateMachine, owner) { }
        public override void OnEnter() { }

        public override void OnUpdate() {
            ChangeState(GameLoopStatesNames.Title);
        }

        public override void OnExit() { }
    }
}
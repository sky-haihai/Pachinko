using GameConstant;
using UnityEngine;
using XiheFramework.Core.Entity;
using XiheFramework.Runtime;
using XiheFramework.Utility.Extension;

namespace Hole {
    public class HoleEntity : GameEntity {
        public override string GroupName => "HoleEntity";

        public LayerMask ballLayerMask;

        public uint holeTypeId;

        public override void OnInitCallback() {
            base.OnInitCallback();

            SubscribeEvent(ThisGame.Hole.OnHoleTypeChangedEventName, OnHoleTypeChanged);
        }

        private void OnHoleTypeChanged(object sender, object e) {
            var args = (OnHoleTypeChangedEventArgs)e;
            if (args.holeEntityId != EntityId) {
                return;
            }

            holeTypeId = args.newHoleTypeId;
            UpdateHoleVisual();
        }

        private void UpdateHoleVisual() {
        
        }

        private void OnTriggerEnter(Collider other) {
            if (ballLayerMask.Includes(other.gameObject.layer)) {
                Debug.Log("Hole Enter: " + other.gameObject.name);
                var ballEntityId = other.gameObject.GetComponent<BallEntity>()?.EntityId;
                Game.Event.Invoke(EventNames.OnBallEnterHole, holeTypeId, ballEntityId);
            }
        }
    }
}
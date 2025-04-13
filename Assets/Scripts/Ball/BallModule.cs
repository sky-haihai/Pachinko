using GameConstant;
using XiheFramework.Core.Base;
using XiheFramework.Runtime;

namespace Ball {
    public class BallModule : GameModule {
        public void SpawnBall(uint ballTypeId) {
            Game.Entity.InstantiateEntity(ResourceAddresses.BallEntity_GeneralBall);
        }

        protected override void Awake() {
            base.Awake();

            ThisGame.Ball = this;
        }
    }
}
using GameConstant;
using XiheFramework.Core.Entity;
using XiheFramework.Runtime;

public class BallEntity : GameEntity {
    public override string GroupName => "BallEntity";

    public uint ballTypeId = 0;

    public override void OnInitCallback() {
        base.OnInitCallback();

        SubscribeEvent(EventNames.OnBallEnterHole, OnBallEnterHole);
    }

    private void OnBallEnterHole(object sender, object e) {
        var ballId = (uint)e;

        if (ballId == EntityId) {
            Game.Entity.DestroyEntity(this);
        }
    }
}
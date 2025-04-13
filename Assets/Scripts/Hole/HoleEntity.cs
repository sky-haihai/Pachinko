using System;
using System.Collections;
using System.Collections.Generic;
using GameConstant;
using UnityEngine;
using UnityEngine.Serialization;
using XiheFramework.Core.Entity;
using XiheFramework.Runtime;
using XiheFramework.Utility.Extension;

public class HoleEntity : GameEntity {
    public override string GroupName => "HoleEntity";

    public LayerMask ballLayerMask;

    public uint holdTypeId;

    private void OnTriggerEnter(Collider other) {
        if (ballLayerMask.Includes(other.gameObject.layer)) {
            Debug.Log("Hole Enter: " + other.gameObject.name);
            var ballEntityId = other.gameObject.GetComponent<BallEntity>()?.EntityId;
            Game.Event.Invoke(EventNames.OnBallEnterHole, holdTypeId, ballEntityId);
        }
    }
}
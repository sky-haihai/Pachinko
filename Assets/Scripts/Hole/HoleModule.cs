using System.Collections.Generic;
using GameConstant;
using UnityEngine;
using XiheFramework.Core.Base;
using XiheFramework.Core.Config;
using XiheFramework.Runtime;

namespace Hole {
    public class HoleModule : GameModule {
        [Config, HideInInspector]
        public int holeCount = 0;

        [Config, HideInInspector]
        public Vector3[] holePositions;

        private int[] m_CurrentHoleTypes;
        
        public void SpawnBigHole(int holeTypeId, int positionId) {
            Game.Entity.InstantiateEntity(ResourceAddresses.HoleEntity_BigHole, holePositions[positionId]);    
        }
        
        public void SpawnSmallHole(int holeTypeId, int positionId) {
            Game.Entity.InstantiateEntity(ResourceAddresses.HoleEntity_SmallHole, holePositions[positionId]);
        }

        protected override void Awake() {
            base.Awake();

            ThisGame.Hole = this;
        }

        public override void Setup() {
            base.Setup();

            holeCount = Game.Config.FetchConfig<int>(this, nameof(holeCount));

            holePositions = new Vector3[holeCount];
        }
    }
}
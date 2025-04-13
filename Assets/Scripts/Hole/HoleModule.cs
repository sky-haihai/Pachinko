using System;
using System.Collections.Generic;
using GameConstant;
using UnityEngine;
using XiheFramework.Core.Base;
using XiheFramework.Core.Config;
using XiheFramework.Runtime;

namespace Hole {
    public class HoleModule : GameModule {
        public string OnHoleTypeChangedEventName => "OnHoleTypeChanged";

        [Config, HideInInspector]
        public int holeCount = 1000;

        public Vector3[] holePositions;

        private uint[] m_CurrentHoleTypes;
        private HoleEntity[] m_CurrentHoleEntities;

        public void ChangeHoleType(int positionIndex, uint holeTypeId) {
            if (positionIndex >= holeCount) {
                return;
            }

            m_CurrentHoleTypes[positionIndex] = holeTypeId;
            var onHoldeTypeChangedEventArgs = new OnHoleTypeChangedEventArgs();
            onHoldeTypeChangedEventArgs.holeEntityId = m_CurrentHoleEntities[positionIndex].EntityId;
            onHoldeTypeChangedEventArgs.newHoleTypeId = holeTypeId;
            onHoldeTypeChangedEventArgs.oldHoleTypeId = m_CurrentHoleTypes[positionIndex - 1];
            Game.Event.Invoke(OnHoleTypeChangedEventName, null, onHoldeTypeChangedEventArgs);
        }

        protected override void Awake() {
            base.Awake();

            ThisGame.Hole = this;
        }

        public override void Setup() {
            base.Setup();

            holeCount = Game.Config.FetchConfig<int>(this, nameof(holeCount));
            m_CurrentHoleTypes = new uint[holeCount];
            m_CurrentHoleEntities = new HoleEntity[holeCount];
        }

        public override void OnLateStart() {
            base.OnLateStart();

            for (int i = 0; i < holeCount; i++) {
                var holeEntity = Game.Entity.InstantiateEntity<HoleEntity>(ResourceAddresses.HoleEntity_BigHole, holePositions[i]);
                m_CurrentHoleEntities[i] = holeEntity;
            }
        }
    }
}
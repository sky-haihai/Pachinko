using XiheFramework.Combat.Damage.Interfaces;

namespace Hole {
    public struct OnHoleTypeChangedEventArgs {
        public uint holeEntityId;
        public uint newHoleTypeId;
        public uint oldHoleTypeId;
    }
}
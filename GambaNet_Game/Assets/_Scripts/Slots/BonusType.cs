using UnityEngine;

namespace GambaNet.Slots
{
    [CreateAssetMenu(fileName = "NewBonusType", menuName = "GambaNet/New Bonus Type", order = 1)]
    public class BonusType : ScriptableObject
    {
        public Sprite bonusIcon;
        public float bonusMultiplier;
    }
}

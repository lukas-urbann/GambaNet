using UnityEngine;
using UnityEngine.UI;

namespace GambaNet.Slots
{
    public class SlotBonus : MonoBehaviour
    {
        public BonusType bonusType;
        public Image image;

        public void SetBonusType(BonusType bonusType)
        {
            this.bonusType = bonusType;
            image.sprite = bonusType.bonusIcon;
        }
    }
}

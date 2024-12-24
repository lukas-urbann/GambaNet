using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GambaNet.Wrapper
{
    public class StartupManager : MonoBehaviour
    {
        public TMP_Text gameName;
        public Image gameBackground;
        public Vector3 backgroundRGB = Vector3.zero;
        public UnityEvent<int> setWinRate = new();

        public void SetRed(float value)
        {
            backgroundRGB.x = value;
            ApplyColor();
        }

        public void SetGreen(float value)
        {
            backgroundRGB.y = value;
            ApplyColor();
        }

        public void SetBlue(float value)
        {
            backgroundRGB.z = value;
            ApplyColor();
        }

        private void ApplyColor()
        {
            backgroundRGB.x /= 255;
            backgroundRGB.y /= 255;
            backgroundRGB.z /= 255;

            gameBackground.color = new Color(backgroundRGB.x, backgroundRGB.y, backgroundRGB.z);
            gameName.color = new Color(1 - backgroundRGB.x, 1 - backgroundRGB.y, 1 - backgroundRGB.z);
        }

        public void SetName(string val)
        {
            gameName.text = val;
        }

        public void SetWinrate(int val)
        {
            setWinRate?.Invoke(val);
        }
    }
}
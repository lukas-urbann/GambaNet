using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GambaNet.Wrapper
{
    public class StartupManager : MonoBehaviour
    {
        public TMP_Text gameName;
        public Image gameBackground;
        public GameObject dataLoadLock;

        private Vector3 backgroundRGB = Vector3.zero;

        private string loadedGameName;
        private double loadedWinrate;
        
        private void Awake()
        {
            dataLoadLock.SetActive(true);
        }

        public void SetRed(float value) => backgroundRGB.x = value;
        public void SetGreen(float value) => backgroundRGB.y = value;
        public void SetBlue(float value) => backgroundRGB.z = value;
        public void ApplyColor() => gameBackground.color = new Color(backgroundRGB.x, backgroundRGB.y, backgroundRGB.z);
        public void SetName(string val) => loadedGameName = val;
        public void SetWinrate(double val) => loadedWinrate = val;

        public void DataLoadComplete()
        {
            gameName.text = loadedGameName;
            ApplyColor();
            dataLoadLock.SetActive(false);
        }
    }
}
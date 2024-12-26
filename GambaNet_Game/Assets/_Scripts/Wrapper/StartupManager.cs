using System.Globalization;
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

        private void Start()
        {
            if (!WebWrapper.HasConnection)
            {
                SetRed(Random.Range(0, 255));
                SetGreen(Random.Range(0, 255));
                SetBlue(Random.Range(0, 255));
                ApplyColor();
                SetWinrate(Random.Range(0, 100));
                SetName("Offline hra");
                return;
            }

            SetRed(float.Parse(WebWrapper.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataColorRedDownload, gameId: WebWrapper.GetGameId()), CultureInfo.InvariantCulture.NumberFormat));
            SetGreen(float.Parse(WebWrapper.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataColorGreenDownload, gameId: WebWrapper.GetGameId()), CultureInfo.InvariantCulture.NumberFormat));
            SetBlue(float.Parse(WebWrapper.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataColorBlueDownload, gameId: WebWrapper.GetGameId()), CultureInfo.InvariantCulture.NumberFormat));
            ApplyColor();
            SetWinrate(int.Parse(WebWrapper.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataWinrateDownload, gameId: WebWrapper.GetGameId()), CultureInfo.InvariantCulture.NumberFormat));
            SetName(WebWrapper.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataNameDownload, gameId: WebWrapper.GetGameId()));
        }

        public void SetRed(float value)
        {
            backgroundRGB.x = value;
        }

        public void SetGreen(float value)
        {
            backgroundRGB.y = value;
        }

        public void SetBlue(float value)
        {
            backgroundRGB.z = value;
        }

        private void ApplyColor()
        {
            backgroundRGB.x /= 255;
            backgroundRGB.y /= 255;
            backgroundRGB.z /= 255;

            gameBackground.color = new Color(backgroundRGB.x, backgroundRGB.y, backgroundRGB.z, 1);
            gameName.color = new Color(1 - backgroundRGB.x, 1 - backgroundRGB.y, 1 - backgroundRGB.z, 1);
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
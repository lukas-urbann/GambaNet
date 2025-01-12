using System.Collections;
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

        private IEnumerator WaitForConnection()
        {
            SetRed(Random.Range(0, 255));
            SetGreen(Random.Range(0, 255));
            SetBlue(Random.Range(0, 255));
            ApplyColor();
            SetWinrate(Random.Range(0, 100));
            SetName("Offline hra");
            yield return new WaitUntil(() => WebWrapper.Instance.HasConnected.Item1 && WebWrapper.Instance.HasConnected.Item2);
            int _winrate = 0;
            string _name = "";

            (bool, bool, bool, bool, bool) check = (false, false, false, false, false);

            UnityEvent<string> colorRedResponse = new UnityEvent<string>();

            colorRedResponse.AddListener((color) =>
            {
                SetRed(float.Parse(color, CultureInfo.InvariantCulture.NumberFormat));
                check.Item1 = true;
                ApplySettings();
            });

            UnityEvent<string> colorGreenResponse = new UnityEvent<string>();

            colorGreenResponse.AddListener((color) =>
            {
                SetGreen(float.Parse(color, CultureInfo.InvariantCulture.NumberFormat));
                check.Item2 = true;
                ApplySettings();
            });

            UnityEvent<string> colorBlueResponse = new UnityEvent<string>();

            colorBlueResponse.AddListener((color) =>
            {
                SetBlue(float.Parse(color, CultureInfo.InvariantCulture.NumberFormat));
                check.Item3 = true;
                ApplySettings();
            });

            UnityEvent<string> winrateResponse = new UnityEvent<string>();

            winrateResponse.AddListener((winrate) =>
            {
                _winrate = int.Parse(winrate, CultureInfo.InvariantCulture.NumberFormat);
                check.Item4 = true;
                ApplySettings();
            });

            UnityEvent<string> nameResponse = new UnityEvent<string>();

            nameResponse.AddListener((name) =>
            {
                _name = name;
                check.Item5 = true;
                ApplySettings();
            });

            WebWrapper.Instance.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataColorRedDownload, WebWrapper.Instance.GetUserId(), WebWrapper.Instance.GetGameId(), callback: colorRedResponse);
            WebWrapper.Instance.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataColorGreenDownload, WebWrapper.Instance.GetUserId(), WebWrapper.Instance.GetGameId(), callback: colorGreenResponse);
            WebWrapper.Instance.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataColorBlueDownload, WebWrapper.Instance.GetUserId(), WebWrapper.Instance.GetGameId(), callback: colorBlueResponse);
            WebWrapper.Instance.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataWinrateDownload, WebWrapper.Instance.GetUserId(), WebWrapper.Instance.GetGameId(), callback: winrateResponse);
            WebWrapper.Instance.GetDataPostRequest(WebWrapper.RequestReturnType.GameDataNameDownload, WebWrapper.Instance.GetUserId(), WebWrapper.Instance.GetGameId(), callback: nameResponse);

            void ApplySettings()
            {
                if (check.Item1 && check.Item2 && check.Item3 && check.Item4 && check.Item5)
                {
                    ApplyColor();
                    SetWinrate(_winrate);
                    SetName(_name);
                    WebWrapper.Instance.SettingsLoaded = true;
                }
            }
        }

        private void Start()
        {
            StartCoroutine(WaitForConnection());
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

            gameBackground.color = new UnityEngine.Color(backgroundRGB.x, backgroundRGB.y, backgroundRGB.z, 1);
            gameName.color = new UnityEngine.Color(1 - backgroundRGB.x, 1 - backgroundRGB.y, 1 - backgroundRGB.z, 1);
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
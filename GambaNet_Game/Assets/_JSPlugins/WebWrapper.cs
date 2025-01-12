using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WebWrapper : MonoBehaviour
{
    private static readonly string databaseUrl = "https://urban-lukas.cz/";
    private static readonly string dataloaderUrl = "gambadata.php";

    public bool SettingsLoaded = false;
    public bool UserLoaded = false;

    public Animator loadPanelAnimator;

    public static WebWrapper Instance;

    private void Start()
    {
        StartCoroutine(WaitForLoad());
    }

    private IEnumerator WaitForLoad()
    {
        OnGameStart();
        yield return new WaitUntil(() => SettingsLoaded && UserLoaded);

        if (GetUserId() == -1 || GetGameId() == -1) yield return new WaitUntil(() => GetUserId() != -1 && GetGameId() != -1);

        Debug.Log("Game data loaded");
        
        loadPanelAnimator.SetTrigger("Loaded");
    }

    public enum RequestReturnType
    {
        UserBalanceDownload,
        UserBalanceUpload,

        GameDataWinrateDownload,
        GameDataNameDownload,

        GameDataColorRedDownload,
        GameDataColorBlueDownload,
        GameDataColorGreenDownload,
    }

    [DllImport("__Internal")]
    public static extern int OnGameStart();

    public (bool, bool) HasConnected = (false, false);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetGameID(string id)
    {
        HasConnected.Item1 = true;
        gID = string.IsNullOrEmpty(id) ? -1 : int.Parse(id);
    }

    public void SetUserID(string id)
    {
        HasConnected.Item2 = true;
        uID = string.IsNullOrEmpty(id) ? -1 : int.Parse(id);
    }

    int uID = -1;
    int gID = -1;

    public int GetUserId()
    {
        return uID;
    }

    public int GetGameId()
    {
        return gID;
    }

    public void GetDataPostRequest(RequestReturnType returnType, int userId = 1, int gameId = 1, string newValue = "0", UnityEvent<string> callback = null)
    {
        StartCoroutine(MakeRequest(returnType, userId, gameId, newValue, callback));
    }

    private UnityWebRequest CreateRequest(string data = null)
    {
        var request = new UnityWebRequest(databaseUrl + dataloaderUrl, "POST");
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        if (data != null)
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(ConvertToUrlEncoded(data));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        request.downloadHandler = new DownloadHandlerBuffer();

        return request;
    }

    private IEnumerator MakeRequest(RequestReturnType returnType, int user = 1, int game = 1, string value = "0", UnityEvent<string> callback = null)
    {
        var dataToSend = new
        {
            requestType = returnType,
            userId = user,
            gameId = game,
            newValue = value,
        };

        var request = CreateRequest(dataToSend.ToString());
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }
        else
        {
            callback?.Invoke(request.downloadHandler.text);
        }
    }

    public static string ConvertToUrlEncoded(string input)
    {
        // Odstraníme složené závorky a mezery kolem nich
        input = input.Trim('{', '}').Trim();

        // Použijeme regulární výraz k nalezení všech "key = value" dvojic
        var matches = Regex.Matches(input, @"\s*(\w+)\s*=\s*([\w\.\-]+)\s*");

        // Pøevod na klíè=hodnota formát
        var keyValuePairs = new List<string>();
        foreach (Match match in matches)
        {
            string key = match.Groups[1].Value;
            string value = match.Groups[2].Value;

            // Pokud je hodnota èíslo, necháme ji jako string, aby nebyla zmìnìna
            keyValuePairs.Add($"{key}={value}");
        }

        // Spojíme jednotlivé dvojice &-kem
        return string.Join("&", keyValuePairs);
    }
}
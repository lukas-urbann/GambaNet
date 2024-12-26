using System.Collections.Specialized;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class WebWrapper : MonoBehaviour
{
    private static string databaseUrl = "http://localhost/phpdatabaze/";
    private static string dataloaderUrl = "dataloader.php";
    public static bool HasConnection;

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

    private void Awake()
    {
        HasConnection = TestConnection();
    }

    public static int GetUserId()
    {
        //TODO: vracet ID uzivatele

        return 1;
    }

    public static int GetGameId()
    {
        //TODO: vracet ID hry

        return 1;
    }

    private bool TestConnection()
    {
        using WebClient client = new();
        try
        {
            client.DownloadString(databaseUrl + dataloaderUrl);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static string GetDataPostRequest(RequestReturnType returnType, int userId = 1, int gameId = 1, string newValue = "0")
    {
        using WebClient client = new();
        NameValueCollection postData = new()
            {
                { "requestType", returnType.ToString() },
                { "userId", userId.ToString() },
                { "gameId", gameId.ToString() },
                { "newValue", newValue }
            };
        try
        {
            return Encoding.UTF8.GetString(client.UploadValues(databaseUrl + dataloaderUrl, postData)); //stahuje se to jako byte[], je nutna koverze
        }
        catch
        {
            return "NO_CONNECTION";
        }
    }

    /*
    private IEnumerator GetGameData()
    {
        UnityWebRequest request = UnityWebRequest.Get(databaseUrl + gameDataUrl);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string s = request.downloadHandler.text;
            s = s.Replace("\n", "");
            Debug.Log(s);
        }
    }
    */

    [DllImport("__Internal")]
    public static extern int LoadUserId();
}

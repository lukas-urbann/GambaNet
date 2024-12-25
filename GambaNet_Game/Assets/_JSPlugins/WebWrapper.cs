using System.Collections.Specialized;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class WebWrapper : MonoBehaviour
{
    private static string databaseUrl = "http://localhost/phpdatabaze/";
    private static string dataloaderUrl = "dataloader.php";

    public enum RequestReturnType
    {
        UserBalanceDownload,
        UserBalanceUpload,

        GameDataWinrateDownload,
        GameDataNameDownload,

        GameDataColorRedownload,
        GameDataColorBlueDownload,
        GameDataColorGreenDownload,
    }

    private void Start()
    {
        //StartCoroutine(GetGameData());
        //Debug.Log(PostGetUserBalance(RequestReturnType.UserBalanceDownload, userId: 1));
        //Debug.Log(PostGetUserBalance(RequestReturnType.UserBalanceUpload, userId: 1, newValue:555));
        

        //Debug.Log(PostGetUserBalance(RequestReturnType.GameDataNameDownload, gameId: 1));
        //Debug.Log(PostGetUserBalance(RequestReturnType.GameDataWinrateDownload, gameId: 1));

        //Debug.Log(PostGetUserBalance(RequestReturnType.GameDataColorRedownload, gameId: 1));
        //Debug.Log(PostGetUserBalance(RequestReturnType.GameDataColorBlueDownload, gameId: 1));
        //Debug.Log(PostGetUserBalance(RequestReturnType.GameDataColorGreenDownload, gameId: 1));

        //Debug.Log(PostGetUserBalance(RequestReturnType.UserBalanceDownload, userId: 1));
    }

    public static string PostGetUserBalance(RequestReturnType returnType, int userId = 1, int gameId = 1, string newValue = "0")
    {
        using WebClient client = new();
        NameValueCollection postData = new()
            {
                { "requestType", returnType.ToString() },
                { "userId", userId.ToString() },
                { "gameId", gameId.ToString() },
                { "newValue", newValue }
            };

        return Encoding.UTF8.GetString(client.UploadValues(databaseUrl + dataloaderUrl, postData)); //stahuje se to jako byte[], je nutna koverze
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

using System.Runtime.InteropServices;
using UnityEngine;

public class WebWrapper : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void UploadUserBalance(double balance);
}

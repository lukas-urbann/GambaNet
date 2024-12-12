using UnityEngine;

namespace GambaNet.Generic
{
    public class CursorController : MonoBehaviour
    {
        public static CursorController Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetCursorVisible(bool visible)
        {
            Cursor.visible = visible;
        }

        public void SetCursorLock(bool locked)
        {
            Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public void SetCursorTexture(Texture2D texture)
        {
            Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
        }
    }
}
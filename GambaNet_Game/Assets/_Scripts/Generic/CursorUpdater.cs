using UnityEngine;

namespace GambaNet.Generic
{
    public class CursorUpdater : MonoBehaviour
    {
        public void UpdateCursor(Texture2D cursor) => CursorController.Instance.SetCursorTexture(cursor);
    }
}

using UnityEngine;

namespace GambaNet.Generic
{
    public class AlwaysLastSibling : MonoBehaviour
    {
        private void Update()
        {
            if (transform.GetSiblingIndex() == transform.parent.childCount - 1)
                return;
            
            transform.SetAsLastSibling();
        }
    }
}

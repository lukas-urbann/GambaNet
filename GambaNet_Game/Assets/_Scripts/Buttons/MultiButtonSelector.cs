using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace GambaNet.Buttons
{
    public class MultiButtonSelector : MonoBehaviour
    {
        private List<Button> connectedBtnList = new(); 
        public UnityEvent<Button> OnButtonSelected = new();

        private void Start()
        {
            foreach (Transform child in transform)
            {
                if (!child.TryGetComponent(out GambaNet.Buttons.Button btn)) continue;
                connectedBtnList.Add(btn);
                btn.Rig(() => { OnButtonSelected.Invoke(btn); });
            }

            OnButtonSelected.AddListener(btn => StartCoroutine(UpdateSelectedButton(btn)));
        }

        private IEnumerator UpdateSelectedButton(Button btn)
        {
            connectedBtnList.ForEach(b => b.OnDeselectButton?.Invoke());
            yield return new WaitForEndOfFrame();
            btn.OnSelectButton?.Invoke();
        }
    }
}
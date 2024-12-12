using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GambaNet.Buttons
{
    public class Button : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
    {
        public bool selectOnStart;
        public UnityEvent OnSelectButton = new();
        public UnityEvent OnDeselectButton = new();
        public UnityEvent OnButtonClick = new();
        public UnityEvent OnButtonEnter = new();
        public UnityEvent OnButtonExit = new();
        private Action selectAction;

        public void Rig(Action act)
        {
            selectAction = act;

            if (!selectOnStart) return;
            StartCoroutine(Skip());
        }

        private IEnumerator Skip()
        {
            yield return new WaitForEndOfFrame();
            VoidClick();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke();
            selectAction?.Invoke();
        }

        public void VoidClick()
        {
            OnPointerClick(null);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnButtonEnter?.Invoke();
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            OnButtonExit?.Invoke();
        }
    }
}
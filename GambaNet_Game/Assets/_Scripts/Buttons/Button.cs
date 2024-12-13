using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GambaNet.Buttons
{
    public class Button : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
    {
        public bool interactable = true;
        public bool selectOnStart;
        public bool enableUninteractableEffects = false;
        public UnityEvent OnSelectButton = new();
        public UnityEvent OnDeselectButton = new();
        public UnityEvent OnButtonClick = new();
        public UnityEvent OnButtonEnter = new();
        public UnityEvent OnButtonExit = new();
        private Action selectAction;

        public void SetInteractable(bool value)
        {
            interactable = value;
        }

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
            if (!interactable) return;
            OnButtonClick?.Invoke();
            selectAction?.Invoke();
        }

        public void VoidClick()
        {
            if (!interactable) return;
            OnPointerClick(null);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!interactable && !enableUninteractableEffects) return;
            OnButtonEnter?.Invoke();
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            if (!interactable && !enableUninteractableEffects) return;
            OnButtonExit?.Invoke();
        }
    }
}
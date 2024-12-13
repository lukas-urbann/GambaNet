using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GambaNet.Generic
{
    public class Constructor : MonoBehaviour
    {
        public GameObject prefab;
        private readonly List<GameObject> _constructed = new();
        public bool clearOnConstruct = true;

        public UnityEvent onConstruct = new UnityEvent(), onDestruct = new UnityEvent();
        
        public void Construct<T>(List<T> items, Action<GameObject, T> bind)
        {
            if (clearOnConstruct)
                ClearConstructed();
            
            foreach (var item in items)
            {
                var go = Instantiate(prefab, transform);
                _constructed.Add(go);
                bind(go, item);
            }
            
            onConstruct?.Invoke();
        }

        public void Construct<T>(int count, Action<GameObject, T> bind)
        {
            if (clearOnConstruct)
                ClearConstructed();

            for (int i = 0; i < count; i++)
            {
                var go = Instantiate(prefab, transform);
                _constructed.Add(go);
                bind(go, default);
            }

            onConstruct?.Invoke();
        }

        public void ClearConstructed()
        {
            foreach (var item in _constructed)
            {
                if (item == null)
                    continue;

                item.gameObject.SetActive(false);
                Destroy(item);
            }
            
            _constructed.Clear();
            onDestruct?.Invoke();
        }
    }
}

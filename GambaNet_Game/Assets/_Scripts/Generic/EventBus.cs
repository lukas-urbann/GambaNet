using System;
using System.Collections.Generic;
using UnityEngine;

namespace GambaNet.Generic
{
    public class EventBus : MonoBehaviour
    {
        public static EventBus Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        
        public void Subscribe<T>(Action<T> action)
        {
            
        }
        
        public void Unsubscribe<T>(Action<T> action)
        {
            
        }

        public void InvokeEvent<T>(T eventType)
        {
            
            
        }
    }
}
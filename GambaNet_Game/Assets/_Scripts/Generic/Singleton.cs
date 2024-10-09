using System;
using UnityEngine;

namespace GambaNet.Generic
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        
    }
}


using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
   
    public static class EventManager
    {
        public static event Action<bool> TogglePause;
        public static void InvokeTogglePause(bool pause) => TogglePause?.Invoke(pause);
    }


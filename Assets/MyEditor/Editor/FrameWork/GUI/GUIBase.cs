using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class GUIBase :IDisposable
    {
        public bool mDisposed { get; private set; }
        public Rect mPosition { get; private set; }

        public virtual void OnGUI(Rect position)
        {
            mPosition = position;
        }
        public void Dispose()
        {
            if(mDisposed) return;
            OnDispose();
            mDisposed = true;
        }

        protected abstract void OnDispose();
    }
}
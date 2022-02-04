using System;
using UnityEngine;

namespace EditorFramework
{
    public abstract class GUIBase : IDisposable
    {
        protected bool mDisposed { get; private set; }
        protected Rect mPosition { get; set; }
        
        public virtual void OnGUI(Rect position)
        {
            mPosition = position;
        }

        public virtual void Dispose()
        {
            if (mDisposed) return;
            OnDispose();
            mDisposed = true;
        }

        protected abstract void OnDispose();
    }
}
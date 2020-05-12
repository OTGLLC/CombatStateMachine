
using UnityEngine;


namespace OTG.EventSystem
{
    public abstract class OTGEventListener<T> : MonoBehaviour
    {
        public abstract void OnEventRaised(T t);
        protected abstract void OnEnable();
        protected abstract void OnDisable();
        
    }

}

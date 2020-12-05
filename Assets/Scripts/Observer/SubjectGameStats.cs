using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class SubjectGameStats:ISubject
    {
        private readonly List<IObserver> m_Observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            m_Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        { 
            m_Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in m_Observers)
            {
                observer.UpdateObserver(this);
            }
        }
    }
}
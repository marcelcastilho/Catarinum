using System.Collections.Generic;

namespace Catarinum.Coap {
    public abstract class Layer : ILayer, IMessageObserver {
        private readonly List<IMessageObserver> _observers;

        protected Layer() {
            _observers = new List<IMessageObserver>();
        }

        public abstract void Send(Message message);

        public virtual void RegisterObserver(IMessageObserver observer) {
            _observers.Add(observer);
        }

        public void OnSend(Message message) {
            foreach (var observer in _observers) {
                observer.OnSend(message);
            }
        }

        public virtual void OnReceive(Message message) {
            foreach (var observer in _observers) {
                observer.OnReceive(message);
            }
        }
    }
}
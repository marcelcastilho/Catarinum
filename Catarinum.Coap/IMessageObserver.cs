using System;

namespace Catarinum.Coap {
    public interface IMessageObserver {
        void OnSend(Message message);
        void OnReceive(Message message);
        void OnError(Exception e);
    }
}
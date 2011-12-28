﻿using System;
using Catarinum.Coap;
using Catarinum.Coap.Util;

namespace Catarinum.Examples.Client {
    public class PrintResponseHandler : IMessageHandler {
        public void Handle(Message message) {
            Console.WriteLine(string.Format("response received: {0}", ByteConverter.GetString(message.Payload)));
        }
    }
}
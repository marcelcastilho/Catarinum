﻿using System;
using NUnit.Framework;

namespace Catarinum.Tests {
    [TestFixture]
    public class RequestTests {
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Invalid code registry for request.")]
        public void Should_have_valid_code_registry() {
            new Request(1, CodeRegistry.Empty, true);
        }

        [Test]
        public void Confirmable_message_should_carry_request() {
            var request = new Request(1, CodeRegistry.Get, true);
            Assert.IsNotNull(request);
        }

        [Test]
        public void Non_confirmable_message_should_carry_request() {
            var request = new Request(1, CodeRegistry.Get, false);
            Assert.IsNotNull(request);
        }
    }
}
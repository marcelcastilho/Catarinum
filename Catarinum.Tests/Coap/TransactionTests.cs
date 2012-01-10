﻿using Catarinum.Coap;
using NUnit.Framework;

namespace Catarinum.Tests.Coap {
    [TestFixture]
    public class TransactionTests {
        private TimerStub _timer;
        private Transaction _transaction;

        [SetUp]
        public void SetUp() {
            _timer = new TimerStub();
            _transaction = new Transaction(_timer) { Message = new Request(CodeRegistry.Get, true) };
        }

        [Test]
        public void Should_schedule_retransmission() {
            _timer.Ticks = 1;
            _transaction.ScheduleRetransmission(RetransmissionCallback, ErrorCallback);
            Assert.AreEqual(1, _transaction.Retransmissions);
            Assert.Greater(_transaction.Timeout, 0);
        }

        [Test]
        public void Should_double_timeout_on_each_retransmission() {
            _timer.Ticks = 2;
            _transaction.ScheduleRetransmission(RetransmissionCallback, ErrorCallback);
            Assert.AreEqual(2, _transaction.Retransmissions);
            Assert.AreEqual(_timer.Timeouts[0] * 2, _timer.Timeouts[1]);
        }

        [Test]
        public void Should_stop_retransmission_if_exceed_max() {
            _timer.Ticks = 10;
            _transaction.ScheduleRetransmission(RetransmissionCallback, ErrorCallback);
            Assert.AreEqual(Transaction.MaxRetransmissions, _transaction.Retransmissions);
        }

        private static void RetransmissionCallback(ITransaction transaction) { }
        private static void ErrorCallback(ITransaction transaction) { }
    }
}
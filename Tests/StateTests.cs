using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Sand.StateMachine;

namespace Tests
{
    public class StateTests
    {
        [Test]
        public void ShouldCallExitAction()
        {
            bool exitWasCalled = false;
            var state = new State((Machine machine) => exitWasCalled = true);
            state.Run();

            Assert.IsTrue(exitWasCalled);
        }
    }
}

using NUnit.Framework;
using Sand.StateMachine;
using System;

namespace Tests
{
    public class TestState : State
    {
        public int runCounter;

        public TestState(Action<Machine> exitAction) : base(exitAction)
        {

        }

        public override void Run()
        {
            base.Run();

            runCounter ++;
        }
    }

    public class MachineTests
    {
        [Test]
        public void ShouldStartRootState()
        {
            var machine = new Machine(null);
            var state = new State(null);
            machine.Add("awd", state, true);

            Assert.IsNull(machine.CurrentState);
            
            machine.Start();

            Assert.AreEqual(machine.CurrentState, state);
        }

        [Test]
        public void ShouldSetTheRootState()
        {
            var machine = new Machine(null);
            var state = new State(null);
            machine.Add("awd", state, true);

            Assert.AreEqual(machine.RootState, state);
        }

        [Test]
        public void ShouldExecuteRunOnCurrentState()
        {
            var machine = new Machine(null);
            var state = new TestState(null);
            machine.Add("awd", state, true);
            machine.Start();

            Assert.AreEqual(state.runCounter, 0);

            machine.Run();

            Assert.AreEqual(state.runCounter, 1);
        }
    
        [Test]
        public void ShouldChangeToTheRightState()
        {
            var machine = new Machine(null);
            var idle = new State(null);
            var running = new State(null);
            
            machine.Add("idle", idle, true);
            machine.Add("running", running, false);

            machine.Start();

            Assert.AreEqual(machine.CurrentState, idle);

            machine.ChangeState("running");

            Assert.AreEqual(machine.CurrentState, running);
        }
    }
}

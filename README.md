## Sand State Machine

Sand State Machine is a simple C# suite that helps you to code your own finite state machine in Unity3D. 

## Install

As long as Sand State Machine is a UPM, all you need to do is to add a package to your project with this repo URL (don't forget the .git extension).

## Creating a state

```C#
using System;

public interface IWalkable
{
  int MyProp { get; set; }
  // ...
}

public class WalkState : Sand.StateMachine.State
{
  IWalkable reference;

  public WalkState(Action<Sand.StateMachine.Machine> exitAction) : base(exitAction)
  {
  }

  // Called when the state machine starts
  public override void Start(Sand.StateMachine.Machine machine, object reference)
  {
    base.Start(machine, reference);

    // Storing your reference
    this.reference = reference as IWalkable;
  }

  // Run is called every update
  public override void Run()
  {
    base.Run();
    // Your walk logic goes here
  }

  // Begin is called once the the state begins
  public override void Begin()
  {
    base.Begin();
  }

  // Begin is called once the the state ends
  public override void End()
  {
    base.End();
  }
}
```

## Creating a state machine

```C#
public class EnemyStateMachine : Sand.StateMachine.SandMachineBehaviour
{
  public MyClass reference;

  private void Awake()
  {
    StateMachine = new Sand.StateMachine.Machine(reference);

    StateMachine.Add("idle", new MyIdleState(IdleExit), true);
    StateMachine.Add("walk", new WalkState(WalkExit), false);
  }

  public void IdleExit(Sand.StateMachine.Machine machine)
  {
    if (someWalkCondition)
    {
      machine.ChangeState("walk");
      return;
    }
  }

  public void WalkExit(Sand.StateMachine.Machine machine)
  {
    if (someIdleCondition)
    {
      machine.ChangeState("idle");
      return;
    }
  }
}
```

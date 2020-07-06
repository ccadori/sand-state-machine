## Sand State Machine

Sand State Machine is a simple C# suite that helps you to code your own finite state machine in Unity3D. 

## Install

As long as Sand State Machine is a UPM, all you need to do is to add a package to your project with this repo URL (don't forget the .git extension).

## Creating a state

```C#
using System
using Sand;

public interface IWalkable 
{
  public int MyProp { get; set; }
  // ...
}

public class WalkState : StateMachine.State
{
  IWalkable reference;
  
  public WalkState(Action<StateMachine.Machine> exitAction) : base(exitAction)
  {
  }
  
  // Called when the state machine starts
  public override void Start(StateMachine.Machine machine, object reference)
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
using Sand;

public class EnemyStateMachine: StateMachine.SandMachineBehaviour
{
  public MyClass reference;

  private void Awake()
  {
    StateMachine = new StateMachine.SandMachineBehaviour(reference);

    StateMachine.Add("idle", new MyIdleState(IdleExit), true);
    StateMachine.Add("walk", new WalkState(WalkExit), false);
  }
  
  public void IdleExit(StateMachine.SandMachineBehaviour machine)
  {
      if (someWalkCondition)
      {
          tree.ChangeState("walk");
          return;
      }
  }
  
  public void WalkExit(StateMachine.SandMachineBehaviour machine)
  {
      if (someIdleCondition)
      {
          tree.ChangeState("idle");
          return;
      }
  }
}
```

using System.Collections.Generic;
using UnityEngine;

namespace Sand.StateMachine
{
    public class Machine
    {
        public State RootState { get; protected set; }
        public State CurrentState { get; protected set; }
        public Dictionary<string, State> States { get; protected set; }
        public object Reference { get; set; }

        public Machine(object reference)
        {
            States = new Dictionary<string, State>();
            Reference = reference;
        }

        public virtual void Start()
        {
            if (RootState == null)
            {
                Debug.LogWarning("You must have a root state before start");
                return;
            }

            foreach (KeyValuePair<string, State> pair in States)
            {
                pair.Value.Start(this, Reference);
            }

            ChangeState(RootState);
        }

        public virtual void Run()
        {
            CurrentState?.Run();
        }

        public virtual void Add(string id, State state, bool root)
        {
            if (States.ContainsKey(id))
            {
                Debug.LogWarning("Duplicated state id");
                return;
            }

            States.Add(id, state);

            if (root)
            {
                RootState = state;
            }
        }

        public virtual State Get(string id)
        {
            if (!States.ContainsKey(id))
            {
                return null;
            }
            
            return States[id];
        }

        public virtual void ChangeState(string id)
        {
            if (!States.ContainsKey(id))
            {
                Debug.LogWarning("Missed id");
            }

            ChangeState(States[id]);
        }

        public virtual void ChangeState(State state)
        {
            CurrentState?.End();
            CurrentState = state;
            CurrentState.Begin();
        }
    }
}

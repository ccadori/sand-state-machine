using UnityEngine;

namespace Sand.StateMachine
{
    public class SandMachineBehaviour : MonoBehaviour
    {
        protected Machine StateMachine { get; set; }

        protected virtual void Start()
        {
            StateMachine.Start();
        }

        protected virtual void Update()
        {
            StateMachine.Run();
        }
    }
}

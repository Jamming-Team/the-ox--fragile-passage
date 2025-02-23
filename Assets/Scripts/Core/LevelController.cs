using UnityEngine;
using UnityUtils;

namespace MoI
{
    public class LevelController : Singleton<LevelController>
    {
        [SerializeField]
        private StateMachine _stateMachine;

        private void Start()
        {
            _stateMachine.Init(this);
        }
    }
}
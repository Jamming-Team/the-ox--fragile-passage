using System.Collections.Generic;
using MoI;
using UnityEngine;

namespace MoI
{
    public abstract class LevelStateBase : StateBase<LevelController>
    {
        [SerializeField] protected List<GameObject> _views;

        public override void Init(MonoBehaviour context)
        {
            base.Init(context);
            SetViewsVisibility(false);
        }
        
        protected override void OnEnter()
        {
            SetViewsVisibility(true);
        }

        protected override void OnExit()
        {
            SetViewsVisibility(false);
        }
        
        protected void SetViewsVisibility(bool visibility)
        {
            _views?.ForEach(x =>
            {
                // Debug.Log(x.gameObject.name);
                if (x)
                    x.SetActive(visibility);
            });
        }
    }
}
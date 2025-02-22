using System;
using UnityEngine;

namespace MoI.GameLogicMVP
{
    public class SparkOfHope : MonoBehaviour
    {
        [SerializeField]
        private float _sparkLifetime = 3f;

        public void Update()
        {
            _sparkLifetime -= Time.deltaTime;
            
            if (_sparkLifetime <= 0f)
                Destroy(gameObject);
        }
    }
}
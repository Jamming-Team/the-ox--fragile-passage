using System;
using UnityEngine;

namespace MoI.GameLogicMVP
{
    public class GLModel
    {
        public Action OnVictory;
        public Action OnDefeat;
        
        
        public readonly GLModelData _glModelData = new GLModelData();
        
        private float _fireFadeRate;
        private float _tempFadeRate;

        private float _minTemp;
        

        public GLModel(float tempValue, float victoryTimerValue, float tempFadeRate, float fireFadeRate, float minTemp)
        {
            _glModelData.fireValue = 0.7f;
            _glModelData.tempValue = tempValue;
            _glModelData.victoryTimerValue = victoryTimerValue;

            _fireFadeRate = fireFadeRate;
            _tempFadeRate = tempFadeRate;
            _minTemp = minTemp;
        }


        public void UpdateValues(float delta)
        {
            _glModelData.fireValue -= _fireFadeRate * delta;
            _glModelData.tempValue = Mathf.Clamp(_glModelData.tempValue - _tempFadeRate * delta, _minTemp, 20f);
            _glModelData.victoryTimerValue -= delta;

            if (_glModelData.victoryTimerValue <= 0f)
            {
                OnVictory?.Invoke();
                return;
            }

            if (_glModelData.fireValue <= 0f)
                OnDefeat?.Invoke();
        }

        public void FuelUpFire(float value)
        {
            
            _glModelData.fireValue = Mathf.Clamp(_glModelData.fireValue + value, 0f, 1f);
            
        }
        
    }
    
    public class GLModelData
    {
        public float fireValue;
        public float tempValue;
        public float victoryTimerValue;
    }
}
using System;
using UnityEngine;

namespace MoI
{
    [CreateAssetMenu(fileName = "MoI", menuName = "MoI/WGDataSO", order = 0)]
    public class WGDataSO : ScriptableObject
    {
        public GameData gameData = new GameData();
        
        [Serializable]
        public class GameData
        {
            public float musicVolume;
            public float SFXVolume;
            
            // WG itself
            public int maxCurrentWordsCount = 4;
            
            // Game rules as whole
            public float victoryTimer = 60f;
            
            public float absoluteMinTemp = -80f;
            public float gameMinTemp = -60f;
            public float absoluteMaxTemp = 20f;
            public float gameMaxTemp = 0f;
            public float tempDecreasingRate = 1.5f;
            
            public float minParticlesDuration = 0.2f;
            public float maxParticlesDuration = 4f;
            public float fireFadeRate = 0.1f;
            public float valuePerCharacter = 0.05f;

            public float maxHealthDepletionRate = 0.1f;

            public float gameDecreaseRate => Mathf.Abs(gameMaxTemp - gameMinTemp) / victoryTimer;

            public float GetTempFillRate(float currentTemp)
            {
                return Mathf.InverseLerp(gameMinTemp, absoluteMaxTemp, currentTemp);
            }
            
            public float GetTempDamageRate(float currentTemp)
            {
                return Mathf.InverseLerp(-10f, absoluteMinTemp, currentTemp);
            }
            
            public float GetFireFillRate(float currentFire)
            {
                return Mathf.Lerp(minParticlesDuration, maxParticlesDuration, currentFire);
            }
            

            // public float tempDecreesRate = 1f;
        }
    }
}
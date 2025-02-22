using UnityEngine;

namespace MoI
{
    [CreateAssetMenu(fileName = "MoI", menuName = "MoI/WGDataSO", order = 0)]
    public class WGDataSO : ScriptableObject
    {
            
        
        public class WGData
        {
            // WG itself
            public int maxCurrentWordsCount = 4;
            
            // Game rules as whole
            public float victoryTimer = 60f;
            public float minTemp = -70;
        }
    }
}
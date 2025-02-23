using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MoI.GameLogicMVP
{
    public class GLView : MonoBehaviour
    {


        [Header("View Refs")]
        [SerializeField]
        private Image _healthBar;
        [SerializeField]
        private Image _tempBackground;
        [SerializeField]
        private Scrollbar _tempScrollbar;
        [SerializeField]
        private TMP_Text _tempText;

        [SerializeField]
        private TMP_Text _victoryTimerText;

        [SerializeField]
        private ParticleSystem _firePS;

        public void SetIntro()
        {
            var main = _firePS.main;
            main.startLifetime = 3f;
            var startColor = main.startColor;
            startColor.color = new Color(1, 1, 1, 1);
            main.startColor = startColor;
        }

        public void UpdateState(GLViewData data)
        {
            _tempText.text = Mathf.Round(data.tempTrueValue) + " \u00b0C";
            _tempBackground.fillAmount = data.tempFill;
            _tempScrollbar.value = data.tempFill;

            var main = _firePS.main;
            main.startLifetime = data.fireValue;
            var startColor = main.startColor;
            startColor.color = new Color(1, 1, 1, data.fireFill);
            main.startColor = startColor;
            
            _victoryTimerText.text = (Mathf.Round(data.timerValue * 10f) / 10f).ToString();

            _healthBar.fillAmount = data.healthFill;
        }
        
    }

    public struct GLViewData
    {
        public float tempTrueValue;
        public float tempFill;
        public float fireValue;
        public float fireFill;
        public float timerValue;

        public float healthFill;
    }
}
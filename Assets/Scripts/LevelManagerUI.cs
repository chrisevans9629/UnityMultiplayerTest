using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelManagerUI : MonoBehaviour
    {
        [SerializeField]
        private LevelManager LevelManager;

        [SerializeField]
        private Text XpText;
        [SerializeField]
        private Text LevelText;

        void Start()
        {
            SetText();
            LevelManager.Xp.OnValueChanged = (p, n) =>
            {
                SetText();
            };
        }

        private void SetText()
        {
            XpText.text = $"{LevelManager.Xp.Value}/{LevelManager.XpNeeded.Value}";
            LevelText.text = $"Level {LevelManager.Level.Value}";
        }
    }
}

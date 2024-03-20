using UnityEngine;

namespace Aviator
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private CreditsManager _creditsManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private LineAnimation _lineAnimation;

        public UIManager UIManager { get => _uiManager; }
        public CreditsManager CreditsManager { get => _creditsManager; }
        public AudioManager AudioManager { get => _audioManager; }
        public LineAnimation LineAnimation { get => _lineAnimation; }

        public static GameManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            AudioManager.PlayMusic();
        }
    }
}
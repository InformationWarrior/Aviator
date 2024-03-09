using UnityEngine;

namespace Aviator
{
    public enum GameState { None, Waiting, Running, Finish};

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private CreditsManager _creditsManager;
        [SerializeField] private AudioManager _audioManager;

        public UIManager UIManager { get => _uiManager; }
        public CreditsManager CreditsManager { get => _creditsManager; }
        public AudioManager AudioManager { get => _audioManager; }

        public static GameManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    }
}
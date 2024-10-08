using UnityEngine;

namespace Caught.Services
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioService : MonoBehaviour
    {
        #region Variables

        private AudioSource _audioSource;

        #endregion

        #region Properties

        public static AudioService Instance { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }

        public void PlayOneShot(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }

        #endregion
    }
}
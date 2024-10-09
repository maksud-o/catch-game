using UnityEngine;

namespace Caught.Services
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioService : SingletonMonoBehaviour<AudioService>
    {
        #region Variables

        private AudioSource _audioSource;

        #endregion

        #region Public methods

        public void PlayOneShot(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }

        #endregion

        #region Protected methods

        protected override void AwakeAddition()
        {
            base.AwakeAddition();
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        #endregion
    }
}
using Caught.Services;
using UnityEngine;

namespace Caught.Game.Items
{
    [RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
    public abstract class Item : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioClip _soundOnCatch;
        private Rigidbody2D _rb;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(GameInfo.BoardTag))
            {
                OnCaughtAction();
                AudioService.Instance.PlayOneShot(_soundOnCatch);
            }
            else if (other.gameObject.CompareTag(GameInfo.FallColliderTag))
            {
                OnFallAction();
            }
            else
            {
                return;
            }

            Destroy(gameObject);
        }

        #endregion

        #region Public methods

        public void SetSpeed(float speed)
        {
            _rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
        }

        #endregion

        #region Protected methods

        protected abstract void OnCaughtAction();

        protected virtual void OnFallAction() { }

        #endregion
    }
}
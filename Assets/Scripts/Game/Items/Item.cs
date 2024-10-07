using UnityEngine;

namespace Caught.Game.Items
{
    [RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
    public abstract class Item : MonoBehaviour
    {
        #region Variables

        private Rigidbody2D _rb;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(GameInfo.BoardTag))
            {
                OnCaughtAction();
            }
            else if (collision.gameObject.CompareTag(GameInfo.FallColliderTag))
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
using Caught.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Caught.Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Board : MonoBehaviour
    {
        #region Variables

        [SerializeField] private InputActionReference _moveBoardInputActionReference;

        private Camera _camera;
        private BoxCollider2D _collider;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _camera = Camera.main;
            _collider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            if (!PauseService.Instance. IsPaused)
            {
                MoveAlongPointer();
                ClampXWithinScreen();
            }
        }

        #endregion

        #region Private methods

        private void ClampXWithinScreen()
        {
            float left = _camera.ScreenToWorldPoint(Vector2.zero).x + _collider.size.x / 2;
            float right = _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - _collider.size.x / 2;
            float x = transform.position.x;
            x = Mathf.Clamp(x, left, right);
            transform.position = new Vector2(x, transform.position.y);
        }

        private void MoveAlongPointer()
        {
            var mousePosition = new Vector2(_moveBoardInputActionReference.action.ReadValue<float>(), 0);
            var newPosition = new Vector2(_camera.ScreenToWorldPoint(mousePosition).x, transform.position.y);
            transform.position = newPosition;
        }

        #endregion
    }
}
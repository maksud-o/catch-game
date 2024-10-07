using System.Collections.Generic;
using UnityEngine;

namespace Caught.Game
{
    [RequireComponent(typeof(EdgeCollider2D))]
    public class FallColliderSetup : MonoBehaviour
    {
        #region Variables

        private Camera _camera;
        private EdgeCollider2D _collider;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _collider = GetComponent<EdgeCollider2D>();
        }

        private void Start()
        {
            _camera = Camera.main;
            SetupCollider();
        }

        #endregion

        #region Private methods

        private void SetupCollider()
        {
            List<Vector2> points = new()
            {
                _camera.ScreenToWorldPoint(Vector2.zero),
                _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)),
            };
            _collider.SetPoints(points);
        }

        #endregion
    }
}
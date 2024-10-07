using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Caught.UI
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class ButtonVisuals : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField] private Color _onHoverColor;
        [SerializeField] private Sprite _onHoverSprite;

        private Color _defaultColor;
        private Sprite _defaultSprite;
        private Image _image;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _image = GetComponent<Image>();

            _defaultColor = _textMesh.color;
            _defaultSprite = _image.sprite;
        }

        #endregion

        #region IPointerDownHandler

        public void OnPointerDown(PointerEventData eventData)
        {
            ToOnHover();
        }

        #endregion

        #region IPointerUpHandler

        public void OnPointerUp(PointerEventData eventData)
        {
            ToDefault();
        }

        #endregion

        #region Private methods

        private void ToDefault()
        {
            _textMesh.color = _defaultColor;
            _image.sprite = _defaultSprite;
        }

        private void ToOnHover()
        {
            _textMesh.color = _onHoverColor;
            _image.sprite = _onHoverSprite;
        }

        #endregion
    }
}
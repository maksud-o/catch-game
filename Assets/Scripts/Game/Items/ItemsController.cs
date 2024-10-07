using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Caught.Game.Items
{
    public class ItemsController : MonoBehaviour
    {
        #region Variables

        [Header("Items Prefabs")]
        [SerializeField] private PositiveItem _positiveItemPrefab;
        [SerializeField] private NegativeItem _negativeItemPrefab;
        [SerializeField] private SpecialItem[] _specialItemsPrefabs;

        [Header("Item Speed Settings")]
        [SerializeField] private float _startingSpeed = 5f;
        [SerializeField] private float _speedupInterval = 10f;
        [SerializeField] private float _speedupMultiplier = 1.5f;

        [Header("Spawn Chance Settings")]
        [Range(0f, 1f)]
        [SerializeField] private float _specialItemChance = 0.1f;
        [Range(0f, 1f)]
        [SerializeField] private float _positiveAndNegativeItemsRatio = 0.5f;

        [Header("Spawn Time Settings")]
        [SerializeField] private float _startDelay = 3f;
        [SerializeField] private float _delayBetweenItems = 0.5f;

        [Header("Other")]
        [SerializeField] private float _ySpawnPos;

        private Camera _camera;
        private float _itemSpeed;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _itemSpeed = _startingSpeed;
        }

        private void Start()
        {
            _camera = Camera.main;

            StartCoroutine(SpawnItems());
            StartCoroutine(SpeedupCountdown());
        }

        #endregion

        #region Private methods

        private Vector2 GetSpawnPos()
        {
            float minX = _camera.ScreenToWorldPoint(Vector2.zero).x;
            float maxX = _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
            float xPos = Random.Range(minX, maxX);
            return new Vector2(xPos, _ySpawnPos);
        }

        private IEnumerator SpawnItems()
        {
            yield return new WaitForSeconds(_startDelay);

            while (true)
            {
                Item item;
                if (_specialItemsPrefabs.Length != 0 && Random.Range(0f, 1f) <= _specialItemChance)
                {
                    SpecialItem itemToSpawn = _specialItemsPrefabs[Random.Range(0, _specialItemsPrefabs.Length)];
                    item = Instantiate(itemToSpawn, GetSpawnPos(), Quaternion.identity);
                }
                else if (Random.Range(0f, 1f) <= _positiveAndNegativeItemsRatio)
                {
                    item = Instantiate(_positiveItemPrefab, GetSpawnPos(), Quaternion.identity);
                }
                else
                {
                    item = Instantiate(_negativeItemPrefab, GetSpawnPos(), Quaternion.identity);
                }

                item.SetSpeed(_itemSpeed);

                yield return new WaitForSeconds(_delayBetweenItems);
            }
        }

        private IEnumerator SpeedupCountdown()
        {
            while (true)
            {
                yield return new WaitForSeconds(_speedupInterval);
                _itemSpeed *= _speedupMultiplier;
            }
        }

        #endregion
    }
}
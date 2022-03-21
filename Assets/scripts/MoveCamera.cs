using UnityEngine;

public class moveCamera : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private string _playerTag;
    [SerializeField] private float _movingSpeed;

    private void Awake()
    {
        if (_playerTransform == null)
        {
            if (gameObject.TryGetComponent<Player>(out Player player))
            {
                _playerTransform = GameObject.FindObjectOfType<Player>().transform;
            }
        }

        this.transform.position = new Vector3()
        {
            x = _playerTransform.position.x,
            y = _playerTransform.position.y,
            z = _playerTransform.position.z - 10
        };
    }

    private void Update()
    {
        if (_playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.transform.position.x,
                y = this.transform.position.y,
                z = this.transform.position.z - 10
            };

            Vector3 position = Vector3.Lerp(transform.position, target, _movingSpeed * Time.deltaTime);

            transform.position = position;
        }
    }
}

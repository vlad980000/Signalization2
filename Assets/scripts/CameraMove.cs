using UnityEngine;

[RequireComponent(typeof(Player))]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Player _player;

    private void Start()
    {
        GetComponent<Camera>().transform.position = _playerTransform.position;
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

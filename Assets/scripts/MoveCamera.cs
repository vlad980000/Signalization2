using UnityEngine;

public class moveCamera : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private string _playerTag;
    [SerializeField] private float _movingSpeed;

    private void Awake()
    {
        if (this._playerTransform == null)
        {
            if (this._playerTag == "")
            {
                this._playerTag = "player";
            }
            this._playerTransform = GameObject.FindGameObjectWithTag(this._playerTag).transform;
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
        if (this._playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.transform.position.x,
                y = this.transform.position.y,
                z = this.transform.position.z - 10

            };

            Vector3 position = Vector3.Lerp(this.transform.position, target, this._movingSpeed * Time.deltaTime);

            this.transform.position = position;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Player))]
public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Player _player;

    private void Start()
    {
        GetComponent<UnityEngine.Camera>().transform.position = _player.transform.position;
    }

    private void Update()
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

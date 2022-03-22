using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]private GameObject _pointTeleport;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
            collision.gameObject.transform.position = _pointTeleport.gameObject.transform.position;
    }
}

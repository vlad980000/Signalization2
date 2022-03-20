using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voise : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;

    private float _volumeScale;
    private float _runningTime;
    private float _target = 1f;

    private void Start()
    {
        _audioSource.volume = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume()
    {
        _audioSource.Play();
        _runningTime += Time.deltaTime;
        _volumeScale = _runningTime / _duration;

        _audioSource.volume = Mathf.MoveTowards(_volumeScale,_target,_runningTime);

        yield return null; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Stop();
            StopCoroutine(ChangeVolume());
        }
    }
}

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
    void Start()
    {
        _audioSource.volume = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _audioSource.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _runningTime += Time.deltaTime;
        _volumeScale = _runningTime / _duration;

        if(_audioSource.volume == 1f)
        {
            _target = 0f;
            _runningTime = 0;
        }
        else if(_audioSource.volume == 0f)
        {
            _target = 1f;
            _runningTime = 0;
        }

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _volumeScale);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _audioSource.Stop();
    }
}

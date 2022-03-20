using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voise : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;

    private float _step;
    private float _runningTime;
    private float _target = 1f;
    private bool _isPlaying = true;

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
        _step = _runningTime / _duration;

        while (true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _step);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _isPlaying = false;
            _audioSource.Stop();
            StopCoroutine(ChangeVolume());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryGrandmother : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Player _player;
    private float _step = 1f;
    private float _target = -1;
    private bool _isPlaying = true;

    private void Start()
    {
        _audioSource.volume = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            var changeVolumeJob = StartCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume()
    {
        var waitHalfSecond = new WaitForSeconds(0.5f);

        while (_isPlaying == true)
        {
            _audioSource.Play();
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _step);
            yield return waitHalfSecond;
            _target *= _target;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var changeVolumeJob = StartCoroutine(ChangeVolume());

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isPlaying = false;
            _audioSource.Stop();
            StopCoroutine(changeVolumeJob);
        }
    }
}

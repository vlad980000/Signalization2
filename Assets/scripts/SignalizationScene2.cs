﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalizationScene2 : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _step = 1f;
    private float _target = -1;
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
        while (_isPlaying == true)
        {
            _audioSource.Play();
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _target, _step);
            yield return new WaitForSeconds(0.5f);

            _target *= -1;
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
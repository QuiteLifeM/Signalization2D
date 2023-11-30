using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine coroutine;
    private float _speed = 0.4f;
    private float _minTargetVolume = 0f;
    private float _maxTargetVolume = 1f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            _audioSource.loop = true;
            _audioSource.Play();
            coroutine = StartCoroutine(ChangeVolume(_maxTargetVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            coroutine = StartCoroutine(ChangeVolume(_minTargetVolume));
            
            if(_audioSource.volume == _minTargetVolume)
            {
                _audioSource.loop = false;
            }
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.isPlaying)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed * Time.deltaTime);

            yield return null;
        }
    }
}

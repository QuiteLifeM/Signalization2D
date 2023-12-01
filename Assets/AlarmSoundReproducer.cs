using System.Collections;
using UnityEngine;

public class AlarmSoundReproducer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine coroutine;
    private float _speed = 0.4f;
    private float _minTargetVolume = 0f;
    private float _maxTargetVolume = 1f;

    private bool IsMinVolume => _audioSource.volume == _minTargetVolume;

    public void TurnOnSound()
    {
        StopActiveCoroutine();
        _audioSource.loop = true;
        _audioSource.Play();
        coroutine = StartCoroutine(ChangeVolume(_maxTargetVolume));
    }

    public void TurnOffSound()
    {
        StopActiveCoroutine();
        coroutine = StartCoroutine(ChangeVolume(_minTargetVolume));

        if (IsMinVolume)
        {
            _audioSource.loop = false;
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.isPlaying)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void StopActiveCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}

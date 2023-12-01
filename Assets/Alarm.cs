using System.Collections;
using UnityEngine;

public class AlarmDetector : MonoBehaviour
{
    private AlarmSoundReproducer _alarmSoundReproducer;

    private void Awake()
    {
        _alarmSoundReproducer = GetComponent<AlarmSoundReproducer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _alarmSoundReproducer.TurnOnSound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _alarmSoundReproducer.TurnOffSound();
        }
    }
}

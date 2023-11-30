using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMover : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private int _negativeDirection = -1;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(_velocity * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(_velocity * Time.deltaTime * _negativeDirection, 0, 0);
        }
    }
}

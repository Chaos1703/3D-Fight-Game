using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float shakeDuration = 0.2f , shakePower = 0.2f , slowDownAmount = 1f;
    private bool shouldShake;
    private float initialDuration;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
        initialDuration = shakeDuration;
    }

    void Update()
    {
        Shake();
    }

    void Shake()
    {
        if (shouldShake)
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakePower;
                shakeDuration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shakeDuration = initialDuration;
                transform.localPosition = initialPosition;
                shouldShake = false;
            }
        }
    }

    public bool ShouldShake
    {
        get
        {
            return shouldShake;
        }
        set
        {
            shouldShake = value;
        }
    }
}

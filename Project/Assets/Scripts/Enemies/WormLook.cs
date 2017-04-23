using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormLook : MonoBehaviour
{
    private Transform target;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;

    // Private variables
    // Code logic
    Vector3 moveTo;
    Vector3 noChange;
    Vector3 difference;
    Quaternion newRot;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        moveTo = target.position;
        difference = moveTo - transform.position;

        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
    }
}

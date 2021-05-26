using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratransform : MonoBehaviour
{
    public float rotationSpeed;
    public Transform player;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            player.position,
            5 * Time.deltaTime);
        
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(transform.rotation.eulerAngles.x,
                player.rotation.eulerAngles.y,
                transform.rotation.eulerAngles.z), 
            rotationSpeed * Time.deltaTime);
    }
}

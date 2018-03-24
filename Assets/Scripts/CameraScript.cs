using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private float distance = 1;
    private float speed = 0.3f;
    private float maxRange = 6;
    private float minRange = 3;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rotate(true);
        if (Input.GetKey(KeyCode.D))
            rotate(false);
        if (Input.GetKey(KeyCode.W))
            zoom(true);
        if (Input.GetKey(KeyCode.S))
            zoom(false);
    }

    private void rotate (bool input)
    {
        float step = speed * Time.deltaTime;
        float orbit = 2F * distance * Mathf.PI;
        float distanceRadians = (speed / orbit) * 20 * Mathf.PI;
        if (input)
            transform.RotateAround(player.transform.position, Vector3.up, -distanceRadians);
        else
            transform.RotateAround(player.transform.position, Vector3.up, distanceRadians);
    }

    private void zoom (bool input)
    {
        Ray cRay = Camera.main.ScreenPointToRay(player.transform.position);
        RaycastHit hit;
        Physics.Raycast(cRay, out hit);

        Debug.Log(hit.distance);
        if (input && hit.distance >= minRange)
            transform.Translate(0, 0, speed, Space.Self);
        else if(!input && hit.distance <= maxRange)
            transform.Translate(0, 0, -speed, Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMoon : MonoBehaviour
{

    public GameObject moon;
    public GameObject earth;
    public float distanceBehind = 100.0f;
    public float distanceAbove = 50.0f;
    public float distanceFromMoon = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {

        // Calculate the vector from the earth to the moon
        Vector3 earthToMoon = moon.transform.position - earth.transform.position;

        // Normalize the vector (to get a unit vector), then scale it by the desired distance from the moon
        Vector3 cameraPosition = moon.transform.position + earthToMoon.normalized * distanceFromMoon;
        cameraPosition.y += distanceAbove;

        // Set the camera's position
        transform.position = cameraPosition;

        // Position the camera behind and above the moon
        //Vector3 cameraPosition = moon.transform.position - moon.transform.forward * distanceBehind + moon.transform.up * distanceAbove;
        //transform.position = cameraPosition;

        // Make the camera look at the earth
        transform.LookAt(earth.transform.position);
    }
}

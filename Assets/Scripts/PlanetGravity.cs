using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public GameObject earth;
    public GameObject moon;
    public Rigidbody moon_body;

    private Vector3 earth_position;
    private Vector3 moon_position;

    private Vector3 initial_velocity = new Vector3(0.0f, 0.0f, 10.0f); // 0 m/s

    private float G = 6.67408f * Mathf.Pow(10, -11); // Gravitational constant
    private float earth_mass = 5.972f * Mathf.Pow(10, 10);   // Mass of Earth
    private float moon_mass = 7.342f * Mathf.Pow(10, 1);   // Mass of Moon

    public Vector3 calculate_force() {
        // Find positions of Earth and Moon
        earth_position = earth.transform.position;
        moon_position = moon.transform.position;

        // Distance between Earth and Moon
        float distance = Vector3.Distance(earth_position, moon_position);

        // Calculate central force
        // F = G * m1 * m2 / r^2
        float force = G * earth_mass * moon_mass / Mathf.Pow(distance, 2);

        // Calculate direction of force
        Vector3 direction = earth_position - moon_position;
        Vector3 force_vector = (force * direction/direction.magnitude);

        return force_vector;
    }

    // Start is called before the first frame update
    void Start()
    {
        moon_body.AddForce(initial_velocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate force
        Vector3 force_vector = calculate_force() * 0.01f;

        Debug.Log(
            "Force: " + force_vector + "\n"
        );

        // Apply force to moon
        moon_body.AddForce(force_vector, ForceMode.Impulse);
    }
}

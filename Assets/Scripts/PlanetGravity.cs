using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public GameObject earth;
    public GameObject moon;
    public Rigidbody moon_body;
    public TrailRenderer moon_trail;

    private Vector3 earth_position;
    private Vector3 moon_position;

    private Vector3 moon_velocity;

    private Vector3 initial_velocity = new Vector3(0.0f, 0.0f, 100.0f); // 1000 m/s

    private float G = 6.67408f * Mathf.Pow(10, -11); // Gravitational constant
    private float earth_mass = 5.9722f * Mathf.Pow(10, 24); // Mass of Earth
    private float moon_mass = 7.34767309f * Mathf.Pow(10, 10); // Mass of Moon

    private float earth_radius = 6371.0f; // Radius of Earth
    private float moon_radius = 1737.0f; // Radius of Moon
    private float earth_moon_distance = 384400.0f; // Distance between Earth and Moon

    public float magnitude_correction = 10000;

    public void resize_object(GameObject go, float diameter){
        float size = go.GetComponent<Renderer> ().bounds.size.y;
        Vector3 rescale = go.transform.localScale;
        rescale.y = diameter * rescale.y / size;
        rescale.x = diameter * rescale.x / size;
        rescale.z = diameter * rescale.z / size;
        go.transform.localScale = rescale;
    }

    public Vector3 calculate_force() {
        // Find positions of Earth and Moon
        earth_position = earth.transform.position;
        moon_position = moon.transform.position;

        // Distance between Earth and Moon
        float distance = Vector3.Distance(earth_position, moon_position);

        // Calculate central force
        // F = G * m1 * m2 / r^2
        float force = G * (earth_mass / magnitude_correction) * (moon_mass / magnitude_correction) / Mathf.Pow(distance, 2);

        // Calculate vector between Earth and Moon
        Vector3 direction = earth_position - moon_position;

        // Multiply force by direction to get force vector
        Vector3 force_vector = (force * direction/direction.magnitude);

        return force_vector;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set realistic sizes for Earth and Moon
        resize_object(moon, moon_radius / magnitude_correction);
        resize_object(earth, earth_radius / magnitude_correction);

        // Set realistic distance between Earth and Moon
        // TODO: determine the correct magnitude correction ratio (squared?)
        moon.transform.position = new Vector3(earth_moon_distance / magnitude_correction, 0.0f, 0.0f);        

        moon_trail.Clear();

        // Set initial velocity of moon
        // TODO: Change this to transform the moon location based on the force,
        //       rather than applying a force to the moon
        //moon_body.AddForce(initial_velocity, ForceMode.VelocityChange);

        // Set initial velocity of moon
        moon_velocity = initial_velocity / (magnitude_correction / 100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate force
        Vector3 force_vector = calculate_force() / magnitude_correction;

        Debug.Log(
            "Force: " + force_vector + "\n"
        );

        // Apply force to moon
        // TODO: Change this to transform the moon location based on the force,
        //       rather than applying a force to the moon
        //moon_body.AddForce(force_vector, ForceMode.Impulse);

        // Update velocity
        Vector3 acceleration = force_vector / moon_mass;
        moon_velocity += acceleration * Time.fixedDeltaTime;

        // Update position
        moon.transform.position += moon_velocity * Time.fixedDeltaTime;
    }
}

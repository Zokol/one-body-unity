# Newton's Gravitational Law in Unity

![](demo.gif)

## Introduction

This project provides a simulation of the motion of the moon around the Earth, based on Newton's law of universal gravitation. It showcases the ability to simulate large scale physics models in Unity.

The goal of this simulation is to investigate Unity's limitations for large scale physics models. The model simulates the behavior of the moon under the influence of the gravitational force exerted by the Earth, thus serving as a visual representation of Newton's gravitational theory.

## Implementation

In reality, the distances and sizes involved in the Earth-Moon system are much too large to conveniently work with in Unity using the default units. Hence, we have scaled the model down to 1/100 of its actual size to make it more manageable.

The Unity physics engine, specifically the Rigidbody and Collider components, are not used here due to their limitations with large scale simulations. Instead, the positions and velocities of the celestial bodies are updated manually in each frame using Newton's law of gravitation.

The moon's motion is updated according to the calculated gravitational force which leads to an elliptical orbit around the Earth. This simulation does a great job of visually demonstrating the effects of gravity and how it can lead to an elliptical orbit.

## Features

- **Realistic Scaling:** The Earth and Moon are represented at a 1/100 scale for feasibility.
- **Accurate Physics:** The motion of the moon is computed based on Newton's law of gravitation.
- **Camera Tracking:** A camera follows the moon, staying on the line between the Earth and the moon, providing a dynamic view of the simulation.
- **Trail Visualization:** The path of the moon is illustrated using a Trail Renderer, providing a visual representation of the moon's orbit.

## Limitations

While this project does an excellent job of simulating the Earth-Moon system on a smaller scale, there are some limitations to consider. Unity's physics engine is not designed for simulations on such a large scale, and some precision is lost in the process. For more accurate results, a dedicated physics simulation software might be more appropriate.

## Conclusion

This project provides a simple and visually-appealing demonstration of Newton's law of gravitation. It serves as a great starting point for anyone looking to understand or expand upon physics simulations in Unity.
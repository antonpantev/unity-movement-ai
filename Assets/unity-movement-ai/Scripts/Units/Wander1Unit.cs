﻿using UnityEngine;
using System.Collections;

namespace UnityMovementAI
{
    public class Wander1Unit : MonoBehaviour
    {

        private SteeringBasics steeringBasics;
        private Wander1 wander;

        // Use this for initialization
        void Start()
        {
            steeringBasics = GetComponent<SteeringBasics>();
            wander = GetComponent<Wander1>();
        }

        void FixedUpdate()
        {
            Vector3 accel = wander.getSteering();

            steeringBasics.steer(accel);
            steeringBasics.lookWhereYoureGoing();
        }
    }
}
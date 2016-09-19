﻿using UnityEngine;
using System.Collections;

namespace UnityMovementAI
{
    [RequireComponent(typeof(Flee))]
    public class Evade : MonoBehaviour
    {
        /* Maximum prediction time the pursue will predict in the future */
        public float maxPrediction = 1f;

        private Flee flee;

        void Awake()
        {
            flee = GetComponent<Flee>();
        }

        public Vector3 getSteering(MovementAIRigidbody target)
        {
            /* Calculate the distance to the target */
            Vector3 displacement = target.position - transform.position;
            float distance = displacement.magnitude;

            /* Get the targets's speed */
            float speed = target.velocity.magnitude;

            /* Calculate the prediction time */
            float prediction;
            if (speed <= distance / maxPrediction)
            {
                prediction = maxPrediction;
            }
            else
            {
                prediction = distance / speed;
                //Place the predicted position a little before the target reaches the character
                prediction *= 0.9f;
            }

            /* Put the target together based on where we think the target will be */
            Vector3 explicitTarget = target.position + target.velocity * prediction;

            return flee.getSteering(explicitTarget);
        }
    }
}
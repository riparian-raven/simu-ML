using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class SimpBoy : Agent
{
    [SerializeField] private Transform goal1Transform;
    [SerializeField] private Transform goal2Transform;
    [SerializeField] float moveSpeed = 2.0f;
    private bool fertile = false;

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }
    public override void OnEpisodeBegin()
    {
        fertile = false;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        if (!fertile)
        {
            //sensor.Reset();
            sensor.AddObservation(transform.localPosition);
            sensor.AddObservation(goal1Transform);
            //sensor.AddObservation(transform.InverseTransformVector(goal1Transform.position - transform.position));
            sensor.AddObservation(!fertile);
        }
        else if (fertile)
        {
            sensor.Reset();
            sensor.AddObservation(transform.localPosition);
            sensor.AddObservation(goal2Transform);
            //sensor.AddObservation(transform.InverseTransformVector(goal2Transform.position - transform.position));
            sensor.AddObservation(fertile);
        }
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        //AddReward(-1f / MaxStep);
        float moveX = (actions.ContinuousActions[0]);
        float moveZ = (actions.ContinuousActions[1]);
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * 2.0f;
    }

}



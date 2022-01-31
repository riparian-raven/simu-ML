using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class BoyCollisions : Agent
{
    [SerializeField] private Material boyFertileMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private Material boyMatedMaterial;
    [SerializeField] private Material boyInfertileMaterial;
    [SerializeField] private MeshRenderer boyRenderer;
    private bool fertile;


    private void OnCollisionEnter(Collision other)
    {
        GetComponent (other.gameObject.tag);
        if (other.gameObject.CompareTag("Food"))
        {
            if (!fertile)
            {
                AddReward(+0.5f);
                Debug.Log("Food collected by boy.");
                boyRenderer.material = boyFertileMaterial;
                fertile = true;
                gameObject.tag = "BoyFertile";
                mindHead.currentFoodCount--;
                mindHead.foodCollectedTotal++;
                other.gameObject.SetActive(false);
                Debug.Log("disabling food item"); 
            }
        }
        else if (other.gameObject.CompareTag("GirlFertile") && fertile)
        {
            AddReward(+1.0f);
            Debug.Log("Congratulations!  Successful Mate.");
            gameObject.tag = "Boy";
            fertile = false;
            mindHead.currentMateCount++;
            mindHead.matesTotal++;
            boyRenderer.material = boyMatedMaterial;
            EndEpisode();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            if (fertile == true)
            {
                mindHead.currentFoodCount--;
            }
            AddReward(-1.0f);
            mindHead.wallFails++;
            Debug.Log("Boy hit wall.");
            fertile = false;
            gameObject.tag = "Boy";
            EndEpisode();
            //boyRenderer.material = loseMaterial;
            // TRIGGER RESPAWN or DEATH
        }

    }
}


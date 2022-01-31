using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScramblerScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToScramble1;
    [SerializeField] private GameObject objectToScramble2;
    [SerializeField] private GameObject objectToScramble3;
    [SerializeField] private float xRangeLow = -70;
    [SerializeField] private float xRangeHigh = 70;
    [SerializeField] private float zRangeLow = -70;
    [SerializeField] private float zRangeHigh = 70;
    [SerializeField] private float xRangeLow2 = -25;
    [SerializeField] private float xRangeHigh2 = 25;
    [SerializeField] private float zRangeLow2 = -25;
    [SerializeField] private float zRangeHigh2 = 25;
    [SerializeField] private float xRangeLow3 = -25;
    [SerializeField] private float xRangeHigh3 = 25;
    [SerializeField] private float zRangeLow3 = -25;
    [SerializeField] private float zRangeHigh3 = 25;
    void Start()
    {
        ScrambleTime();
    }
    private void ScrambleTime()   
        {
        Vector3 randPosition = transform.localPosition + new Vector3(Random.Range(xRangeLow, xRangeHigh), Random.Range(0, 0), Random.Range(zRangeLow, zRangeHigh));
        Vector3 randPosition2 = transform.localPosition + new Vector3(Random.Range(xRangeLow2, xRangeHigh2), Random.Range(0, 0), Random.Range(zRangeLow2, zRangeHigh2));
        Vector3 randPosition3 = transform.localPosition + new Vector3(Random.Range(xRangeLow3, xRangeHigh3), Random.Range(0, 0), Random.Range(zRangeLow3, zRangeHigh3));
        objectToScramble1.transform.localPosition = randPosition;
        objectToScramble2.transform.localPosition = randPosition;
        objectToScramble3.transform.localPosition = randPosition;
        }
    }


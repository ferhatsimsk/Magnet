using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float forceFactor = 20;

    List<Rigidbody>rgbBalls = new List<Rigidbody>();

    Transform magnetPoint;
    
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody rgbBal in rgbBalls)
        {
            rgbBal.AddForce((magnetPoint.position - rgbBal.position) * forceFactor * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            rgbBalls.Add(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            rgbBalls.Remove(other.GetComponent<Rigidbody>());
        }
    }

}

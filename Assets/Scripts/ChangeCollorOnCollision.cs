using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeCollorOnCollision : MonoBehaviour
{
    public Material material;
    private String prevCollidedObj;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    { 
        if (hit.gameObject.CompareTag("CollorChangers") && hit.gameObject.name != prevCollidedObj)
        {
            //Debug.Log("Collorized!");
            material.color = new Color(Random.Range(1, 255) / 255.0f, Random.Range(1, 255) / 255.0f, Random.Range(1, 255) / 255.0f);
            prevCollidedObj = hit.gameObject.name;
        }
    }
}

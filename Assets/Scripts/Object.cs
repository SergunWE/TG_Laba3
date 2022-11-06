using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private ObjectProperties objectProperties;

    private void Awake()
    {
        if (!objectProperties.IsRotate)
        {
            Destroy(GetComponent<RotateModule>());
        }

        if (!objectProperties.IsPhysical)
        {
            Destroy(GetComponent<PhysicalModule>());
        }

        GetComponent<MeshRenderer>().sharedMaterial = objectProperties.ObjectMaterial;
    }
}
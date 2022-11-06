using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PhysicalModule : MonoBehaviour
{
    [SerializeField] private int force;

    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private Vector3 _physicDir;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _physicDir = new Vector3(0f, force, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null) return;
        _rigidbody.AddForce(_physicDir, ForceMode.VelocityChange);
    }

    private void OnDestroy()
    {
        Destroy(_rigidbody);
        Destroy(_boxCollider);
    }
}
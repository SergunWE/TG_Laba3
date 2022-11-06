using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/New Object Properties")]
public class ObjectProperties : ScriptableObject
{
    public bool IsRotate;
    public bool IsPhysical;
    public Material ObjectMaterial;
    public int ObjectNumber;
}

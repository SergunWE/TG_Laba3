using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PropertiesManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown materialDropdown;
    [SerializeField] private TMP_InputField objectNumber;
    [SerializeField] private Toggle rotateToggle;
    [SerializeField] private Toggle physicToggle;
    
    [SerializeField] private ObjectProperties objectProperties;
    [SerializeField] private GameObject objectModel;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform xFinishPosition;
    [SerializeField] private Transform zFinishPosition;
    [SerializeField] private float xzStep;
    [SerializeField] private float yStep;

    [SerializeField] private List<Material> materials;

    private float _xStop;
    private float _zStop;
    private void Awake()
    {
        _xStop = xFinishPosition.position.x;
        _zStop = zFinishPosition.position.z;
        var currentPos = startPosition.position;
        for (int i = 0; i < objectProperties.ObjectNumber; i++)
        {
            var tv = Instantiate(objectModel, currentPos, Quaternion.Euler(0,0,90));
            currentPos += Vector3.right * xzStep;
            if (currentPos.x > _xStop)
            {
                currentPos = new Vector3(startPosition.position.x, currentPos.y, currentPos.z - xzStep);
            }

            if (currentPos.z < _zStop)
            {
                currentPos = new Vector3(startPosition.position.x, currentPos.y + yStep, startPosition.position.z);
            }
        }
    }

    private void Start()
    {
        rotateToggle.isOn = objectProperties.IsRotate;
        physicToggle.isOn = objectProperties.IsPhysical;
        materialDropdown.value = materials.IndexOf(objectProperties.ObjectMaterial);
        objectNumber.text = objectProperties.ObjectNumber.ToString();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void OnRotateChange(bool value)
    {
        objectProperties.IsRotate = value;
    }
    
    public void OnPhysicalChange(bool value)
    {
        objectProperties.IsPhysical = value;
    }

    public void OnMaterialChange(int index)
    {
        objectProperties.ObjectMaterial = materials[index];
    }

    public void OnObjectNumberChange(string value)
    {
        objectProperties.ObjectNumber = int.Parse(value);
    }
    
}

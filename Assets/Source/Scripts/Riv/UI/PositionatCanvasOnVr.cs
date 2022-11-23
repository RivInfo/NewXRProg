using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionatCanvasOnVr : MonoBehaviour
{
    [SerializeField] private Camera _trackCamera;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _addRotation;
    [SerializeField] private float _distance;

    public void PlaceCanvas()
    {
        Vector3 forvardV = _trackCamera.transform.forward;
        forvardV.y = 0;
        forvardV = forvardV.normalized;

        transform.position = _trackCamera.transform.position+forvardV*_distance+_offset;
        
        transform.LookAt(_trackCamera.transform);
        transform.rotation *= Quaternion.Euler(_addRotation);
        
        //Vector3 rO = transform.rotation.eulerAngles;
        //transform.rotation.eulerAngles.Set(rO.x+_addRotation.x,rO.y+_addRotation.y,rO.z+_addRotation.z);
    }
}

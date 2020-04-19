using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//credit to https://www.youtube.com/watch?v=wBol2xzxCOU
public class BackgroundParllax : MonoBehaviour{

    [SerializeField] private Vector2 parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0) ;
        lastCameraPosition = cameraTransform.position;
    }
}

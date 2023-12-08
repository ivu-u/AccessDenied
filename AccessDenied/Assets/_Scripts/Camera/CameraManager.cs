using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Calculates a point for the camera to look at that's between the player character and the mouse position
/// </summary>
public class CameraManager : MonoBehaviour
{
    // variables
    [SerializeField] Camera _camera = null;
    [SerializeField] CinemachineVirtualCamera _cinemachineCam = null;
    [SerializeField] private GameObject followPointer = null;   // where the camera is looking at

    [SerializeField] private GameObject player = null;

    Vector3 mousePosition = new Vector3();
    Vector3 followPointerPosition = new Vector3();

    void Update() {
        // calculate position for mouse tracker
        mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // calculate position for follow pointer
        followPointerPosition = (mousePosition + player.transform.position) / 2;    // midpoint calc
        followPointerPosition = (followPointerPosition + player.transform.position) / 2;    //quarterpoint calc
        followPointer.transform.position = followPointerPosition;
    }
}

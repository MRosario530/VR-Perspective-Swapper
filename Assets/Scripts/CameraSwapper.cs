using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwapper : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    public GameObject originPOV;

    private Vector3 headPosition;
    public Transform loweredPosition;
    public Transform head;

    private void Awake()
    {
        toggleReference.action.started += ToggleCamera;
        headPosition = head.transform.position;
        head.transform.position = loweredPosition.position;
    }

    private void OnDisable()
    {
        toggleReference.action.started -= ToggleCamera;
    }

    private void ToggleCamera(InputAction.CallbackContext context)
    {
        originPOV.SetActive(true);
        head.transform.position = headPosition;
        gameObject.SetActive(false);
    }
}

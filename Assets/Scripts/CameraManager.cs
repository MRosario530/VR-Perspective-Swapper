using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraManager : MonoBehaviour
{
    public Transform XRRig;

    public Transform cameraSwapPosition;
    public Transform positionToReturn;

    // Components to Disable/Re-enable:
    public GameObject[] cameraComponents;

    // Head adjustment values:
    private Vector3 headPosition;
    public Transform loweredPosition;
    public Transform head;


    // Boolean to allow for swap.
    public bool isSwapped = false;

    // Input to swap back to main
    [SerializeField] private InputActionReference triggerAction; // Reference to the input action
    public GameObject textDisplay;

    private void OnEnable()
    {
        if (triggerAction.action != null)
        {
            triggerAction.action.performed += OnTriggerPressed;
        }
    }
    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        if (isSwapped)
        {
            XRRig.parent = null;
            XRRig.position = positionToReturn.position;
            head.transform.localPosition = headPosition;
            foreach (GameObject component in cameraComponents)
            {
                component.SetActive(true);
            }
            isSwapped = false;
            textDisplay.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        XRRig = GameObject.Find("XR Origin (XR Rig)").GetComponent<Transform>();
        headPosition = head.transform.localPosition;
    }

    public void SwapToPOV()
    {
        head.transform.position = loweredPosition.position;
        XRRig.parent = cameraSwapPosition.parent;
        XRRig.position = cameraSwapPosition.position;
        foreach (GameObject component in cameraComponents)
        {
            component.SetActive(false);
        }
        isSwapped = true;
        textDisplay.SetActive(true);
    }
}

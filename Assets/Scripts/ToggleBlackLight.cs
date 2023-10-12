using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ToggleBlackLight: MonoBehaviour
{
    private PostProcessLayer postProcessLayer;
    private bool isPostProcessEnabled = true;
    private bool isFKeyPressed = false;

    [SerializeField]
    private GameObject enemy2;
    [SerializeField]
    private GameObject cube2;

    void Start()
    {
        // Get the PostProcessLayer component attached to the camera
        postProcessLayer = GetComponent<PostProcessLayer>();

        if (postProcessLayer == null)
        {
            Debug.LogError("PostProcessLayer component not found on the camera. Please add it to use this script.");
        }
    }

    void Update()
    {
        // Toggle Post-Process Layer and GameObjects when "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFKeyPressed = !isFKeyPressed; // Toggle the state

            // Toggle the Post-Process Layer
            isPostProcessEnabled = isFKeyPressed;
            TogglePostProcessLayer(isPostProcessEnabled);

            // Toggle the GameObjects
            cube2.SetActive(isFKeyPressed);
            enemy2.SetActive(isFKeyPressed);
        }
    }

    void TogglePostProcessLayer(bool isEnabled)
    {
        // Enable or disable the Post-Process Layer
        postProcessLayer.enabled = isEnabled;
        Debug.Log("Post-Process Layer " + (isEnabled ? "enabled" : "disabled"));
    }
}

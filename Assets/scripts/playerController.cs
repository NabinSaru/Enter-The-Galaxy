using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    float xThrow, yThrow;
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 4f;
    [Tooltip("In m")] [SerializeField] float yRange = 4f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f; //for rotation due to change in pos change
    [SerializeField] float positionYawFactor = -5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float controlPitchFactor = -24f; //for key pressed

    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }
    void OnPlayerDeath()
    {
        print("Control reached");
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitchDueToPosition = transform.localRotation.y * positionPitchFactor;
        float pitch = pitchDueToControlThrow+pitchDueToPosition;

        float yaw = transform.localRotation.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;

        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
    
}

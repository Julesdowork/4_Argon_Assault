using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float speed = 15f;
    [SerializeField] float xLimit = 3f;
    [SerializeField] float yUpperLimit = 2f;
    [SerializeField] float yLowerLimit = -2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xLimit, xLimit);
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yLowerLimit, yUpperLimit);

        transform.localPosition = new Vector3(clampedXPos,
            clampedYPos, transform.localPosition.z);
	}
}

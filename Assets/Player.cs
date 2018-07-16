using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    // Default position: (0, -1.4, 5.7)

    [Tooltip("In ms^-1")][SerializeField] float speed = 15f;
    [Tooltip("In m")] [SerializeField] float xLimit = 3f;
    [Tooltip("In m")] [SerializeField] float yLimit = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessTranslation();
        ProcessRotation();
	}

    void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xLimit, xLimit);
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yLimit, yLimit);

        transform.localPosition = new Vector3(clampedXPos,
            clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }
}

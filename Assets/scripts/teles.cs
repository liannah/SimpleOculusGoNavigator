using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teles : MonoBehaviour
{

    [SerializeField] private float m_DefaultDistance = 5f;      // The default distance away from the camera the reticle is placed.
    [SerializeField] private bool m_UseNormal;                  // Whether the reticle should be placed parallel to a surface.
    [SerializeField] private Transform m_Camera;                // The reticle is always placed relative to the camera.


    private Vector3 m_OriginalScale;                            // Since the scale of the reticle changes, the original scale needs to be stored.
    private Quaternion m_OriginalRotation;                      // Used to store the original rotation of the reticle.
    public GameObject centerEye;

    public bool UseNormal
    {
        get { return m_UseNormal; }
        set { m_UseNormal = value; }
    }

    private void Awake()
    {
        // Store the original scale and rotation.
        m_OriginalScale = transform.localScale;
        m_OriginalRotation = transform.localRotation;
    }


    public void Hide()
    {
     //   m_Image.enabled = false;
    }


    public void Show()
    {
      //  m_Image.enabled = true;
    }

    // This overload of SetPosition is used when the the VREyeRaycaster hasn't hit anything.
    public void SetPosition()
    {
        // Set the position of the reticle to the default distance in front of the camera.
        transform.position = m_Camera.position + m_Camera.forward * m_DefaultDistance;
        transform.rotation = centerEye.transform.rotation;

        // Set the scale based on the original and the distance from the camera.
        transform.localScale = m_OriginalScale * m_DefaultDistance;

        // The rotation should just be the default.
       // transform.localRotation = m_OriginalRotation;
    }


    // This overload of SetPosition is used when the VREyeRaycaster has hit something.
    public void SetPosition(RaycastHit hit)
    {
        transform.position = hit.point;
        transform.localScale = m_OriginalScale * hit.distance;
        transform.rotation = centerEye.transform.rotation;

        // If the reticle should use the normal of what has been hit...
        //if (m_UseNormal)
            // ... set it's rotation based on it's forward vector facing along the normal.
        //    transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
     //   else
            // However if it isn't using the normal then it's local rotation should be as it was originally.
           // transform.localRotation = m_OriginalRotation;
    }
}

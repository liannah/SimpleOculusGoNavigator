using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tele : MonoBehaviour
{

    public teleport bezier;
    public Transform go;
    public teles teleS;

    private void Start()
    {
        teleS.SetPosition();
    }

    void Update()
    {
        UpdateTeleportEnabled();
        RaycastHit hit;
        if(Physics.Raycast(go.position, go.forward, out hit))
        {
            if (hit.collider.gameObject)
            {
                teleS.SetPosition(hit);
            }
        }
        else
        {
            teleS.SetPosition();
        }
    }

    void UpdateTeleportEnabled()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            HandleTeleport();
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            RaycastHit hit;
            if (Physics.Raycast(go.position, go.forward, out hit))
            {
                if (hit.collider.gameObject.CompareTag("cube"))
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
    }

    void HandleTeleport()
    {
        if (bezier.endPointDetected)
        {
                TeleportToPosition(bezier.EndPoint);
        }
    }

    void TeleportToPosition(Vector3 teleportPos)
    {
        gameObject.transform.position = new Vector3(teleportPos.x, gameObject.transform.position.y, teleportPos.z);
    } 
}

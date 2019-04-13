using UnityEngine;
using System.Collections.Generic;

public class teleport : MonoBehaviour
{
    public bool endPointDetected;
     

    public Vector3 EndPoint
    {
        get { return endpoint; }
    }

    private Vector3 endpoint;
    
    private Vector3 startV;
    private Vector3 endV;

    private void Start()
    {
        startV = gameObject.transform.position;
        Endv();
    }

    void Update()
    {
        UpdateControlPoints();
        Endv();
    }

   
    void UpdateControlPoints()
    {
        startV = gameObject.transform.position; 
    }

    bool Endv()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Holo"))
            {
                endV = hit.collider.transform.position;
                return CheckColliderIntersection(startV, endV);
            }
        }
        return false;
    }
    

    bool CheckColliderIntersection(Vector3 start, Vector3 end)
    {
        Ray r = new Ray(start, end - start);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, Vector3.Distance(start, end)))
        {
            
                endpoint = hit.point;
                endPointDetected = true;
                return true;
            
        }
        endPointDetected = false;
        return false;
    }

  
}

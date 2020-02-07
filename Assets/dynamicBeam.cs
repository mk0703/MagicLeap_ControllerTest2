using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class dynamicBeam : MonoBehaviour
{
    public GameObject mContoroller; //controller object
    private LineRenderer lineRenderer; //beam

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>(); //get LineRenderer
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //set beam at controller
        transform.position = mContoroller.transform.position;
        transform.rotation = mContoroller.transform.rotation;

        RaycastHit hit;
        //hit beam to object
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, transform.position); //set startpoint a controller
            lineRenderer.SetPosition(1, hit.point); // end point set object hit point
        }
        else
        {
            lineRenderer.useWorldSpace = false;
            lineRenderer.SetPosition(0, transform.position); //set start point a controller
            lineRenderer.SetPosition(1, Vector3.forward * 3); //end point set 3[m]
        }
    }
}

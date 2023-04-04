using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlaceWall : MonoBehaviour
{
    private GridScript grid;
    public GameObject wall;

    private bool placingModeActive = true;
    // Start is called before the first frame update
    private void Awake()
    {
        grid = FindObjectOfType<GridScript>();
    }

    public void WallPlacing()
    {

        if (placingModeActive == true)
        {
            //Debug.Log("working 1");
            RaycastHit hitInfo;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceWallNear(hitInfo.point);
            }

            Debug.DrawRay(transform.position, transform.forward, Color.black, 1);
        }
    }

    private void PlaceWallNear(Vector3 placeSpot)
    {
        var spot = grid.GetNearestPointOnGrid(placeSpot);
        //instantiate wall here
        //line from video:
        //GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = spot;
        
        Instantiate(wall, spot, Quaternion.identity);
    }
}
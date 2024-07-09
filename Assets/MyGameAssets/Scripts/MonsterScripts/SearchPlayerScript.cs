using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayerScript : MonoBehaviour
{
    private float angle = 45.0f;

    public static bool IsDiscovery = false;

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Vector3 positionDelta = collider.transform.position - this.transform.position;
            float targetAngle = Vector3.Angle(this.transform.forward, positionDelta);

            if(targetAngle <angle)
            {
                if(Physics.Raycast(this.transform.position,positionDelta,out RaycastHit hit))
                {
                    if(hit.collider == collider)
                    {
                        IsDiscovery = true;
                    }
                }
            }
        }
    }
}

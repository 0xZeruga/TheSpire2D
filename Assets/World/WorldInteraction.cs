using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour {

    GameObject Player;

    private void Start()
    {
        Player = GetComponent<GameObject>();
    
    }

    void Update () {
		
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }

	}
	
    //3D RayCast interact
	void GetInteraction ()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay,out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable")
            {
                Debug.Log("Interactable interacted");
            }
            else
            {
               
        
            }
        }

    }
}

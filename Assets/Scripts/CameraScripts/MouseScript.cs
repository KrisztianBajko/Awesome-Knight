using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public Texture2D cursorTexture;
    public GameObject mousePoint;
    public GameObject instantiatedMouse;
    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;
    public PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if(playerMovement.IsDead == true)
        {
            enabled = false;
        }
        Cursor.SetCursor(cursorTexture, hotSpot, mode);
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    Vector3 pointerPos = hit.point;
                    pointerPos.y = 0.30f;

                    if(instantiatedMouse == null)
                    {
                        instantiatedMouse = Instantiate(mousePoint, pointerPos, Quaternion.identity);
                        instantiatedMouse.transform.position = pointerPos;
                    }
                    else
                    {
                        Destroy(instantiatedMouse);
                        instantiatedMouse = Instantiate(mousePoint, pointerPos, Quaternion.identity);
                        instantiatedMouse.transform.position = pointerPos;
                    }
                    
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    #region Public Fields


    #endregion

    #region Private Fields
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private GameObject mousePoint;
    private GameObject instantiatedMouse;
    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;
    private PlayerMovement playerMovement;

    #endregion


    #region MonoBehaviour Callbacks
    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        PointerIndicator();
    }

    #endregion



    #region Public Methods
    #endregion

    #region Private Methods
    private void PointerIndicator()
    {
        if (playerMovement.IsDead == true)
        {
            enabled = false;
        }
        //custom cursos
        Cursor.SetCursor(cursorTexture, hotSpot, mode);

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    Vector3 pointerPos = hit.point;
                    pointerPos.y = 0.30f;

                    if (instantiatedMouse == null)
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
    #endregion

}

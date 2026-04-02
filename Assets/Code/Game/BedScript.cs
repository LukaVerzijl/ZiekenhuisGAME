using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BedScript : MonoBehaviour, IDropHandler, IDragHandler
{
    public Transform transBed;
    public GameObject bear;
    [HideInInspector]public bool canBeDragged = true;
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        dropped.transform.position = transBed.position;
        dropped.GetComponent<BearScript>().ChangeToLayingImage();
        dropped.GetComponent<BearScript>().canBeDragged = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canBeDragged)
        {
            var vector3 = transform.position; 
            vector3.x = Mouse.current.position.ReadValue().x; 
            transform.position = vector3;
            if (bear.GetComponent<BearScript>().canBeDragged == false)
            {
                bear.transform.position = transBed.position;
            }
        }
    }
}

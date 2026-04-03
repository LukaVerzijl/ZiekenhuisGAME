using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BedScript : MonoBehaviour, IDropHandler
{
    public Transform transBed;
    public GameObject bear;
    public Transform ownTrans;
    [HideInInspector]public bool canBeDragged = true;
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        dropped.transform.position = transBed.position;
        dropped.GetComponent<KarakterScript>().ChangeToLayingImage();
        dropped.GetComponent<KarakterScript>().canBeDragged = false;
        Debug.Log(dropped.GetComponent<KarakterScript>().canBeDragged);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class BedScript : MonoBehaviour, IDropHandler
{
    public Transform transBed;
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        dropped.transform.position = transBed.position;
        dropped.GetComponent<Dragable>().ChangeToLayingImage();
    }
}

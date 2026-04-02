using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BearScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Sprite LayingSprite;
    public Sprite NormalSprite;
    [HideInInspector]public bool canBeDragged = true;   
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canBeDragged)
        {
            transform.position = Mouse.current.position.ReadValue();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
    }

    public void ChangeToLayingImage()
    {
        image.sprite = LayingSprite;
    }
}

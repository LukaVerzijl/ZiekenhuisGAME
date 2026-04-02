using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Sprite LayingSprite;
    public bool OnlyXAxis;
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnlyXAxis)
        {
            var vector3 = transform.position;
            vector3.x = Mouse.current.position.ReadValue().x;
            transform.position = vector3;
        }
        else
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

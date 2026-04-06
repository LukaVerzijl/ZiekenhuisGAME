using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class KarakterScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image image;
    public Sprite LayingSprite;
    public Sprite NormalSprite;
    public GameManager GameManager;
    public bool canBeDragged = true;   

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        image.raycastTarget = false;
        GameManager.KarakterScript = dropped.GetComponent<KarakterScript>();
        GameManager.TransKarakter = dropped.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canBeDragged)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(mousePos);
            positionInWorld.z = 0;
            transform.position = positionInWorld;
            
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

    public void ChangeToNormal()
    {
        image.sprite = NormalSprite;
    }
}

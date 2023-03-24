using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{

    private Image Trehold;
    private Image touch;

    [HideInInspector]
    public Vector3 InputDir;

    //IPointer"Down"
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(Trehold.rectTransform,
            eventData.position, 
            eventData.pressEventCamera,
            out position))
        {
            position.x = (position.x / Trehold.rectTransform.sizeDelta.x);
            position.y = (position.y / Trehold.rectTransform.sizeDelta.y);

            float x = (Trehold.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 + 1;
            float y = (Trehold.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 + 1;

            InputDir = new Vector3(x, y, 0);
            InputDir = (InputDir.magnitude > 1) ? InputDir.normalized : InputDir; //Set Controller to center when Do noting

            touch.rectTransform.anchoredPosition = new Vector3(InputDir.x * (Trehold.rectTransform.sizeDelta.x/2.5f),
                InputDir.y * (Trehold.rectTransform.sizeDelta.y / 2.5f));
        }
    }

    //IPointer"Up"
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    //IDragHandler
    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        Trehold = GetComponent<Image>();
        touch = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector3.zero;


    }
}

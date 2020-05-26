using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image _joystickBG;
    [SerializeField]
    private Image _joystickHendle;
    private Vector2 _inputVector;
    private void Start()
    {
        _joystickBG = GetComponent<Image>();
        _joystickHendle = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 _touchPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBG.rectTransform,
                                                                    eventData.position,
                                                                    eventData.pressEventCamera,
                                                                    out _touchPoint))

        {
            _touchPoint.x /= _joystickBG.rectTransform.sizeDelta.x;
            _touchPoint.y /= _joystickBG.rectTransform.sizeDelta.y;
            print(_touchPoint);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        print("OnPointerDown");
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        _joystickHendle.rectTransform.anchoredPosition = Vector2.zero;
    }
}

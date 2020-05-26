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

            //normalize touch point coordinates
            _inputVector = new Vector2(_touchPoint.x * 2 - 1, _touchPoint.y * 2 - 1);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            _joystickHendle.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystickBG.rectTransform.sizeDelta.x / 2),
                                                                         _inputVector.y * (_joystickBG.rectTransform.sizeDelta.y / 2));
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

    public float Horizontal()
    {
        if (_inputVector.x != 0) return _inputVector.x;
        else return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (_inputVector.y != 0) return _inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIButtonHoldGeneralized : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;
    public UnityEvent onButtonHold;

    void Update()
    {
        if (isHolding && onButtonHold != null)
        {
            onButtonHold.Invoke();
        }
    }

    private void OnEnable() {
        isHolding = false;
    }
    private void OnDisable() {
        isHolding = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }
}

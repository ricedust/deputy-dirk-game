using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ButtonClicker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
    [SerializeField] private InputReader input;
    [SerializeField] private UIData ui;
    private bool isHovering;
    public event Action onClick;

    public void OnPointerEnter(PointerEventData eventData) {
        isHovering = true;
        Debug.Log("hover");
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHovering = false;
        Debug.Log("unhover");
    }
    
    private void OnEnable() {
        input.click.performed += Click;
    }
    private void OnDisable() {
        input.click.performed -= Click;
    }

    private void Click(InputAction.CallbackContext context) {
        if (!isHovering) return;
        onClick?.Invoke();
    }
}
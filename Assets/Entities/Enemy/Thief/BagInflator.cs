using UnityEngine;

public class BagInflator : MonoBehaviour {
    [SerializeField] private Stealer stealer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite fullBag;
    [SerializeField] private Sprite emptyBag;

    private void OnEnable() {
        spriteRenderer.sprite = emptyBag;
        stealer.onStolen += Inflate;
    }

    private void OnDisable() {
        stealer.onStolen -= Inflate;
    }

    private void Inflate() {
        spriteRenderer.sprite = fullBag;
    }
}
using UnityEngine;

public class LivesIndicator : MonoBehaviour {
    [SerializeField] private LifeIcon lifeIconPrefab;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputReader input;
    [SerializeField] private int iconSpacing;
    private LifeIcon[] icons;

    private void Awake() {
        icons = new LifeIcon[playerSettings.lives];

        for (int i = 0; i < icons.Length; i++) {
            icons[i] = Instantiate(lifeIconPrefab, transform);
            icons[i].transform.localPosition = Vector2.right * iconSpacing * i;
        }
    }

    private void OnEnable() {
        playerData.onUpdateLives += UpdateIcons;
    }

    private void OnDisable() {
        playerData.onUpdateLives -= UpdateIcons;
    }

    private void UpdateIcons(int lives) {
        for (int i = 0; i < icons.Length; i++) {
            LifeIcon icon = icons[i];
            if (i < lives && !icon.isEnabled) icon.PopIn();
            else if (i >= lives && icon.isEnabled) icon.PopOut();
        }
    }
}
using DG.Tweening;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    [SerializeField] private WeaponFiring firing;
    [SerializeField] private WeaponData weaponData;

    private Tween recoilTween;
    
    private void Awake() {
        recoilTween = transform.DOLocalMoveX(0, weaponData.kickRecoverySeconds)
            .SetEase(Ease.OutExpo)
            .SetAutoKill(false);
    }

    private void OnEnable() {
        firing.onFire += KickBack;
    }

    private void OnDisable() {
        firing.onFire -= KickBack;
    }

    private void KickBack() {
        transform.localPosition += Vector3.left * weaponData.kickDistance;
        recoilTween.Restart();
    }
}
using DG.Tweening;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour {
    [SerializeField] private WeaponFiring firing;
    [SerializeField] private WeaponSettings settings;
    [SerializeField] private Transform weaponSprite;
    [SerializeField] private Rigidbody2D recoilRecipient;

    private Tween recoilTween;
    
    private void Awake() {
        recoilTween = weaponSprite.DOLocalMoveX(0, settings.kickRecoverySeconds)
            .SetEase(Ease.OutExpo)
            .SetAutoKill(false);
    }

    private void OnEnable() {
        firing.onFire += KickBack;
    }

    private void OnDisable() {
        firing.onFire -= KickBack;
    }

    private void OnDestroy() {
        recoilTween.Kill();
    }

    private void KickBack(WeaponAiming aiming) {
        // apply impulse to shooter
        recoilRecipient.AddForce(aiming.direction * -1 * settings.recoilImpulse, ForceMode2D.Impulse);
        // visually kick the gun back
        weaponSprite.localPosition += Vector3.left * settings.kickDistance;
        recoilTween.Restart();
    }
}
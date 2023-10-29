using System.Collections;
using UnityEngine;

public class WeaponCooldown : MonoBehaviour {
    [SerializeField] private WeaponFiring firing;
    [SerializeField] private WeaponSettings settings;

    private void OnEnable() {
        firing.SetLocked(false);
        firing.onFire += StartCooldown;
    }

    private void OnDisable() {
        firing.onFire -= StartCooldown;
    }

    private void StartCooldown(WeaponAiming aiming)
    {
        if (firing.isLocked) return;
        firing.SetLocked(true);
        StartCoroutine(WaitForCooldown());
    }

    private IEnumerator WaitForCooldown() {
        yield return new WaitForSeconds(settings.cooldownSeconds);
        firing.SetLocked(false);
    }
}
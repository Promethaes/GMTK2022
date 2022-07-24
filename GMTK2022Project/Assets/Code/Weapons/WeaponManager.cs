using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] float downtime = 0.25f;
    public UnityEvent OnChangeWeapon;
    public UnityEvent OnBeginAttack;
    public UnityEvent OnFinishAttack;

    [Header("References")]
    [SerializeField] Weapon currentWeapon = null;
    [SerializeField] List<Weapon> weapons = new List<Weapon>();
    [SerializeField] GameObject ownerEntity = null;

    [Header("Animator")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    [HideInInspector] public bool canAttack = true;

    float _internalDowntime = 0.0f;

    bool firing = false;

    private void Awake()
    {
#if UNITY_EDITOR
        SetCurrentWeapon(3);
#endif
    }

    private void Update()
    {
        if (!currentWeapon || !currentWeapon.gameObject.activeSelf)
        {
            animator.enabled = true;
            spriteRenderer.enabled = true;
            animator.SetInteger("current_weapon", 0);
        }
        else if (currentWeapon && currentWeapon.gameObject.activeSelf)
        {
            animator.enabled = false;
            spriteRenderer.enabled = false;
        }
        _internalDowntime += Time.deltaTime;
        if (_internalDowntime >= downtime)
            OnFinishAttack.Invoke();
        if (Input.GetButton("Fire1"))
            OnCurrentWeapon();
    }

    public void OnCurrentWeapon()
    {
        if (currentWeapon == null || !currentWeapon.CanAttack)
            return;
        _internalDowntime = 0.0f;
        OnBeginAttack.Invoke();
        currentWeapon.Attack();
    }

    public void OnFire(CallbackContext ctx)
    {
        firing = ctx.performed;
    }
    public bool CanCurrentWeaponAttack()
    {
        return currentWeapon.CanAttack;
    }
    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public void SetCurrentWeapon(int index)
    {
        currentWeapon = weapons[index];
        //animator.SetInteger("current_weapon", index + 1);
        currentWeapon.gameObject.SetActive(true);
        OnChangeWeapon.Invoke();
    }

    public void RollForWeapon()
    {
        currentWeapon?.gameObject.SetActive(false);
        int result = Random.Range(0, weapons.Count);
        while (currentWeapon == weapons[result])
            result = Random.Range(0, weapons.Count);
        SetCurrentWeapon(result);
    }

}

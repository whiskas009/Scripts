using UnityEngine;

public class AnimatorHash : MonoBehaviour
{
    public int IdInputX { get; private set; }
    public int IdInputZ { get; private set; }
    public int IdSpeed { get; private set; }
    public int IdIsAttack { get; private set; }
    public int IdIsDeath { get; private set; }
    public int IDIsStand { get; private set; }
    public int IDIsStartAnimation { get; private set; }
    public int IDIsWeaponStand { get; private set; }

    private void Start()
    {
        IdInputX = Animator.StringToHash("inputX");
        IdInputZ = Animator.StringToHash("inputZ");
        IdSpeed = Animator.StringToHash("Speed");
        IdIsAttack = Animator.StringToHash("IsAttack");
        IdIsDeath = Animator.StringToHash("IsDeath");
        IDIsStand = Animator.StringToHash("IsStand");
        IDIsStartAnimation = Animator.StringToHash("IsStartAnimation");
        IDIsWeaponStand = Animator.StringToHash("IsWeaponStand");
    }
}

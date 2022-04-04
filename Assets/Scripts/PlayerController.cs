using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator)) ]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    Rigidbody2D rb;
    Animator animator;   
    HashAnimationNames animBase = new HashAnimationNames();

    [SerializeField] UI gameCanvas;
    [Space]
    [SerializeField] float speed = 200;
    [Space]
    [SerializeField] float startTimeFire = 100;
    [SerializeField] float timeFire;
    [Space]
    [SerializeField] GameObject timlineDeath;
    [SerializeField] Light lightFire;
    float startIntensity = 2;
    
    int curentAnimation;
    Vector2 move;

    int currentKeys;
    public int CurrentKeys
    {
        get => currentKeys;
        set 
        {
            currentKeys = Mathf.Clamp(value, 0, 20);
            gameCanvas.TextKeyUpdate(currentKeys);
        }
    }
    public bool CanControl { get; set; } = true;


    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
            Instance = this;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
     void Start()
    {
        ResetTimeLifeFire();
    }
    void Update()
    {
        SwitchAnimation();
        TimeLifeFire();
    }
    void FixedUpdate() =>  Move();
    void Move()
    {
        if (!CanControl) return;
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = speed * Time.fixedDeltaTime * move;
    }
    #region Life Fire
    void TimeLifeFire()
    {
        timeFire -= Time.deltaTime;
        lightFire.intensity = Mathf.Lerp(startIntensity, 0.1f, (startTimeFire- timeFire) / startTimeFire);    


        if (timeFire <= 0)
            Death();
    }
    public void ResetTimeLifeFire()
    {
        timeFire = startTimeFire;
    }
    #endregion

    #region Animation
    void SwitchAnimation()
    {
        if (move.x > 0)
        {
            if (move.y > 0)
                CrossFadeAnimation(animBase.RightUp);
            else if (move.y < 0)
                CrossFadeAnimation(animBase.RightDown);
            else
                CrossFadeAnimation(animBase.Right);
        }
        else if (move.x < 0)
        {
            if (move.y > 0)
                CrossFadeAnimation(animBase.LeftUp);
            else if (move.y < 0)
                CrossFadeAnimation(animBase.LeftDown);
            else
                CrossFadeAnimation(animBase.Left);
        }
        else
        {
            if (move.y > 0)
                CrossFadeAnimation(animBase.Up);
            else if (move.y < 0)
                CrossFadeAnimation(animBase.Down);
            else
                CrossFadeAnimation(animBase.Idle);
        }
    }
    void CrossFadeAnimation(int animation, float time = 0.1f)
    {
        if (animation == curentAnimation) return;
        animator.StopPlayback();
        animator.CrossFade(animation, time);
        curentAnimation = animation;
    }
    #endregion
    void Death()
    {
        CanControl = false;
        timlineDeath.SetActive(true);
    }
}

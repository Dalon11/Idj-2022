using UnityEngine;

public class HashAnimationNames
{ 
    public int Idle => Animator.StringToHash("Idle");
    public int Left => Animator.StringToHash("Left");
    public int LeftDown => Animator.StringToHash("LeftDown");
    public int LeftUp => Animator.StringToHash("LeftUp");
    public int Right => Animator.StringToHash("Right");
    public int RightDown => Animator.StringToHash("RightDown");
    public int RightUp => Animator.StringToHash("RightUp");
    public int Down => Animator.StringToHash("Down");
    public int Up => Animator.StringToHash("Up");

}
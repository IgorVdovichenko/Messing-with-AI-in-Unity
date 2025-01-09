namespace MyFSM
{
    public interface IAnimator
    {
        void PlayAnimation(AnimationType anim);

        float GetCurrentAnimationDuration();
    }
}
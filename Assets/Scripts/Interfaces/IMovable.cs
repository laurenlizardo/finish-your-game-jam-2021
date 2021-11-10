namespace ggj
{
    /// <summary>
    /// Use for items that can be moved.
    /// Can be for items that can be moved a finite amoutn of times (hallway plant).
    /// Can also be for items that open or close (cabinet doors).
    /// </summary>
    public interface IMovable
    {
        void Move();
    }
}
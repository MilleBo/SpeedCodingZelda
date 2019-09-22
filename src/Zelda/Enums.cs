namespace Zelda
{
    public enum Input
    {
        Left,
        Right,
        Up,
        Down,
        None,
        Enter,
        A,
        S,
        Select,
        Start
    }

    public enum Direction
    {
        Down,
        Up,
        Left,
        Right,
    }

    public enum State
    {
        Standing,
        Walking,
        Special,
        Pushing
    }

    public enum ItemSlot
    {
        A,
        B
    }

    public enum WindowPosition
    {
        Up,
        Down
    }

    public enum GameEventType
    {
        Message,
        EventSwitch
    }

    public enum DeathAnimation
    {
        Link,
        Explosion
    }
}
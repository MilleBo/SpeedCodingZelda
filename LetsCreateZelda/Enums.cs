//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - https://www.youtube.com/user/Maloooon
//------------------------------------------------------
namespace LetsCreateZelda
{
    public enum ComponentType
    {
        Sprite,
        PlayerInput,
        Animation,
        Collision,
        AIMovement,
        EnemyOctorok,
        Camera,
        Equipment,
        GUI,
        Damage,
        Stats,
        DeathAnimation,
        Script,
        StatusEffects,
        EventTriggerDistance
    }

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
        Left, 
        Right,
        Up,
        Down
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

//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------



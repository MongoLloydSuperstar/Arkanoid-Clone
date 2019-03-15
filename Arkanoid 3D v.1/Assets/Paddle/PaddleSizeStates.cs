using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManaging;


public abstract class Size : State<PaddleController>
{
    /*Set Functions*/
    protected void SetSprite(PaddleController _paddleController)
    {
        SpriteRenderer spriteRenderer = _paddleController.SpriteRenderer;
        List<Sprite> spriteList = _paddleController.spriteList;

        if (_paddleController.StateMachine.CurrentState is SizeSmall) {
            spriteRenderer.sprite = spriteList[0];
        }
        if (_paddleController.StateMachine.CurrentState is SizeNormal) {
            spriteRenderer.sprite = spriteList[1];
        }
        if (_paddleController.StateMachine.CurrentState is SizeLarge) {
            spriteRenderer.sprite = spriteList[2];
        }
        if (_paddleController.StateMachine.CurrentState is SizeXLarge) {
            spriteRenderer.sprite = spriteList[3];
        }
        if (_paddleController.StateMachine.CurrentState is SizeXXLarge) {
            spriteRenderer.sprite = spriteList[4];
        }
    }

    protected void SetCollider(PaddleController _paddleController)
    {
        SpriteRenderer spriteRenderer = _paddleController.SpriteRenderer;
        BoxCollider boxCollider = _paddleController.BoxCollider;

        float paddleWidth = spriteRenderer.sprite.bounds.size.x;
        float paddleHeight = spriteRenderer.sprite.bounds.size.y;
        float paddleScaling = 0.5f;

        boxCollider.size = new Vector3(paddleWidth, 0.0f, paddleHeight * paddleScaling);

        _paddleController.BoxCollider = boxCollider;
    }

    protected void SetBoundary(PaddleController _paddleController)
    {
        float paddleWidth = _paddleController.SpriteRenderer.sprite.bounds.size.x;
        float cameraSize = Camera.main.orthographicSize;

        float xMin = -(cameraSize - (paddleWidth / 2));
        float xMax = cameraSize - (paddleWidth / 2);

        _paddleController.XMin = xMin;
        _paddleController.XMax = xMax;
    }
}


public class SizeSmall : Size
{
    private static SizeSmall instance;

    private SizeSmall()
    {
        if (instance != null) {
            return;
        }

        instance = this;
    }

    public static SizeSmall Instance
    {
        get
        {
            if (instance == null) {
                new SizeSmall();
            }

            return instance;
        }
    }

    public override void EnterState(PaddleController _owner)
    {
        SetSprite(_owner);
        SetCollider(_owner);
        SetBoundary(_owner);
    }

    public override void ExitState(PaddleController _owner)
    {
        Debug.Log("Exit State");
    }

    public override void UpdateState(PaddleController _owner)
    {
        if (_owner.SizeDown) {
            _owner.SizeDown = false;
        }
        else if (_owner.SizeUp) {
            _owner.StateMachine.ChangeState(SizeNormal.Instance);

            _owner.SizeUp = false;
        }
    }
}

public class SizeNormal : Size
{
    private static SizeNormal instance;

    private SizeNormal()
    {
        if (instance != null) {
            return;
        }

        instance = this;
    }

    public static SizeNormal Instance
    {
        get
        {
            if (instance == null) {
                new SizeNormal();
            }

            return instance;
        }
    }

    public override void EnterState(PaddleController _owner)
    {
        SetSprite(_owner);
        SetCollider(_owner);
        SetBoundary(_owner);
    }

    public override void ExitState(PaddleController _owner)
    {
        Debug.Log("Exit State");
    }

    public override void UpdateState(PaddleController _owner)
    {
        if (_owner.SizeDown) {
            _owner.StateMachine.ChangeState(SizeSmall.Instance);

            _owner.SizeDown = false;
        }
        else if (_owner.SizeUp) {
            _owner.StateMachine.ChangeState(SizeLarge.Instance);

            _owner.SizeUp = false;
        }
    }
}

public class SizeLarge : Size
{
    private static SizeLarge instance;

    private SizeLarge()
    {
        if (instance != null) {
            return;
        }

        instance = this;
    }

    public static SizeLarge Instance
    {
        get
        {
            if (instance == null) {
                new SizeLarge();
            }

            return instance;
        }
    }

    public override void EnterState(PaddleController _owner)
    {
        SetSprite(_owner);
        SetCollider(_owner);
        SetBoundary(_owner);
    }

    public override void ExitState(PaddleController _owner)
    {
        Debug.Log("Exit State");
    }

    public override void UpdateState(PaddleController _owner)
    {
        if (_owner.SizeDown) {
            _owner.StateMachine.ChangeState(SizeNormal.Instance);

            _owner.SizeDown = false;
        }
        else if (_owner.SizeUp) {
            _owner.StateMachine.ChangeState(SizeXLarge.Instance);

            _owner.SizeUp = false;
        }
    }
}

public class SizeXLarge : Size
{
    private static SizeXLarge instance;

    private SizeXLarge()
    {
        if (instance != null) {
            return;
        }

        instance = this;
    }

    public static SizeXLarge Instance
    {
        get
        {
            if (instance == null) {
                new SizeXLarge();
            }

            return instance;
        }
    }

    public override void EnterState(PaddleController _owner)
    {
        SetSprite(_owner);
        SetCollider(_owner);
        SetBoundary(_owner);
    }

    public override void ExitState(PaddleController _owner)
    {
        Debug.Log("Exit State");
    }

    public override void UpdateState(PaddleController _owner)
    {
        if (_owner.SizeDown) {
            _owner.StateMachine.ChangeState(SizeLarge.Instance);

            _owner.SizeDown = false;
        }
        else if (_owner.SizeUp) {
            _owner.StateMachine.ChangeState(SizeXXLarge.Instance);

            _owner.SizeUp = false;
        }
    }
}

public class SizeXXLarge : Size
{
    private static SizeXXLarge instance;

    private SizeXXLarge()
    {
        if (instance != null) {
            return;
        }

        instance = this;
    }

    public static SizeXXLarge Instance
    {
        get
        {
            if (instance == null) {
                new SizeXXLarge();
            }

            return instance;
        }
    }

    public override void EnterState(PaddleController _owner)
    {
        SetSprite(_owner);
        SetCollider(_owner);
        SetBoundary(_owner);
    }

    public override void ExitState(PaddleController _owner)
    {
        Debug.Log("Exit State");
    }

    public override void UpdateState(PaddleController _owner)
    {
        if (_owner.SizeDown) {
            _owner.StateMachine.ChangeState(SizeXLarge.Instance);

            _owner.SizeDown = false;
        }
        else if (_owner.SizeUp) {
            _owner.SizeUp = false;
        }
    }
}
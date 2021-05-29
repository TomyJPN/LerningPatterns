using UnityEngine;

public class Player : MonoBehaviour
{
    private static readonly StateStanding stateStanding = new StateStanding();
    private static readonly StateJumping stateJumping = new StateJumping();

    [SerializeField]
    private Rigidbody rigidbody;

    /// <summary>現在のState</summary>
    private PlayerStateBase _currentState;

    /// <summary>現在のState名</summary>
    public string CurrentStateName => _currentState.ToString();

    void Start()
    {
        _currentState = stateStanding;
    }

    void Update()
    {
        _currentState.OnUpdate(this);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // ここでは簡易的に何かに当たれば地面衝突とする
        ChangeState(stateStanding);
    }


    /// <summary>
    /// Stateの変更
    /// </summary>
    private void ChangeState(PlayerStateBase nextState)
    {
        _currentState.OnExit(this, nextState);
        _currentState = nextState;
        _currentState.OnEnter(this, _currentState);
    }

    /// <summary>
    /// 立ち状態
    /// </summary>
    private class StateStanding : PlayerStateBase
    {
        public override void OnUpdate(Player owner)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                owner.ChangeState(stateJumping);
            }
        }
    }

    /// <summary>
    /// ジャンプ状態
    /// </summary>
    private class StateJumping : PlayerStateBase
    {
        private const int jumpPower = 5;

        public override void OnEnter(Player owner, PlayerStateBase prevState)
        {
            owner.rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            base.OnEnter(owner, prevState);
        }
    }
}

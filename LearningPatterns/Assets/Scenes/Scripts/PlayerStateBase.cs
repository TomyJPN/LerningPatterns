/// <summary>
/// State抽象クラス
/// </summary>
public abstract class PlayerStateBase
{
    /// <summary>
    /// ステート開始時
    /// </summary>
    public virtual void OnEnter(Player owner, PlayerStateBase prevState)
    {
        UnityEngine.Debug.Log(owner.CurrentStateName + "を開始");
    }

    /// <summary>
    /// 毎フレーム
    /// </summary>
    public virtual void OnUpdate(Player owner){ }

    /// <summary>
    /// ステート終了時
    /// </summary>
    public virtual void OnExit(Player owner, PlayerStateBase nextState)
    {
        UnityEngine.Debug.Log(owner.CurrentStateName + "を終了");
    }
}
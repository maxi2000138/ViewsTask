using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class BasePopup<TResult> : BasePopup
{
    private UniTaskCompletionSource<TResult> _taskCompletionSource;

    public UniTask<TResult> Show(object args)
    {
        _taskCompletionSource = new UniTaskCompletionSource<TResult>();
        gameObject.SetActive(true);
        OnOpen(args);
        return _taskCompletionSource.Task;
    }

    protected void SetPopUpResult(TResult result) =>
        _taskCompletionSource.TrySetResult(result);
}

public abstract class BasePopup : MonoBehaviour
{
    
    public async UniTask Hide()
    {
        await OnHide();
        gameObject.SetActive(false);
    }
    
    protected virtual void OnOpen(object args)
    {
        
    }

    protected virtual UniTask OnHide()
    {
        return UniTask.CompletedTask;
    }
}

using System.Threading;
using UnityEngine;
using Yarn.Unity;

public class CustomDialoguePresenter : DialoguePresenterBase
{
    // You'll implement methods here
    public override YarnTask OnDialogueCompleteAsync()
    {
        throw new System.NotImplementedException();
    }

    public override YarnTask OnDialogueStartedAsync()
    {
        throw new System.NotImplementedException();
    }

    public override YarnTask RunLineAsync(LocalizedLine line, LineCancellationToken token)
    {
        throw new System.NotImplementedException();
    }

    public override YarnTask<DialogueOption> RunOptionsAsync(DialogueOption[] dialogueOptions, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
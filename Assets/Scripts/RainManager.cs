using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RainManager : MonoBehaviour
{
    [SerializeField] private RawImage rainImage;

    void Start()
    {
    
        rainImage.material.DOOffset(new Vector2(1, 1), 1f)
            .SetRelative(true)   // keep moving relative to current offset
            .SetLoops(-1, LoopType.Incremental) // infinite smooth scroll
            .SetEase(Ease.Linear);
    
    }
}

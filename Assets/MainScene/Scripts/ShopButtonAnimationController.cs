using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonAnimationController : MonoBehaviour
{
    [SerializeField] Button _openButton;
    [SerializeField] Button _closeButton;
    [SerializeField] float _duration;
    [SerializeField] AnimationCurve _buttonAnimationCurve;
    bool _isAnimating;
    RectTransform _openButtonRect;
    RectTransform _closeButtonRect;

    private void Awake()
    {
        _openButtonRect = _openButton.GetComponent<RectTransform>();
        _closeButtonRect = _closeButton.GetComponent<RectTransform>();

        _closeButtonRect.pivot = new Vector2(0.5f, 0.5f);
        _closeButtonRect.Rotate(Vector3.up, 180);
        _closeButtonRect.SetAsFirstSibling();
        _isAnimating = false;
    }

    public IEnumerator StartAnimation(ShopStateAction action)
    {
        if (_isAnimating) yield break;
        _isAnimating = true;
        _openButton.enabled = false;
        _closeButton.enabled = false;

        float journey = 0;
        RectTransform _buttonToHide = action == ShopStateAction.Open ? _openButtonRect : _closeButtonRect;
        Vector3 _openButtonOrigin = _openButtonRect.rotation.eulerAngles;
        Vector3 _closeButtonOrigin = _closeButtonRect.rotation.eulerAngles;
        Vector3 _openButtonTarget = _openButtonOrigin + new Vector3(0, 180, 0);
        Vector3 _closeButtonTarget = _closeButtonOrigin + new Vector3(0, 180, 0);
        while (journey <= _duration)
        {
            journey += Time.deltaTime;
            float percent = Mathf.Clamp01(journey / _duration);
            float curvePercent = _buttonAnimationCurve.Evaluate(percent);
            _openButtonRect.rotation = Quaternion.Euler(Vector3.LerpUnclamped(_openButtonOrigin, _openButtonTarget, curvePercent));
            _closeButtonRect.rotation = Quaternion.Euler(Vector3.LerpUnclamped(_closeButtonOrigin, _closeButtonTarget, curvePercent));
            if (journey >= _duration / 2 && _buttonToHide.GetSiblingIndex() != 0)
                _buttonToHide.SetAsFirstSibling();
            yield return null;
        }

        _isAnimating = false;
        _openButton.enabled = true;
        _closeButton.enabled = true;
    }
}

public enum ShopStateAction
{
    Open,
    Close
}

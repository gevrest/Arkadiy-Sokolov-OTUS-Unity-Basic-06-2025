using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class VictoryScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _victoryScreen;
        [SerializeField] private CanvasGroup _header;
        [SerializeField] private GameObject _rewards;
        [SerializeField] private GameObject _buttons;
        [SerializeField] private Button _claimButton;
        [SerializeField] private Button _getButton;
        [Space(10f)]
        [SerializeField] private float _showAnimationDuration = 1f;

        private IEnumerator Start()
        {
            _victoryScreen.gameObject.SetActive(true);
            _victoryScreen.DOFade(1, _showAnimationDuration);
            yield return new WaitForSeconds(_showAnimationDuration);
            _header.gameObject.SetActive(true);
            _header.DOFade(1, _showAnimationDuration);
            yield return new WaitForSeconds(_showAnimationDuration);
            _rewards.SetActive(true);
            _rewards.transform.localScale = new Vector2(3, 3);
            _rewards.transform.DOScale(1, _showAnimationDuration);
            yield return new WaitForSeconds(_showAnimationDuration);
            _buttons.SetActive(true);
            _buttons.transform.localScale = new Vector2(0.5f, 0.5f);
            _buttons.transform.DOScale(1, _showAnimationDuration);
        }

        private void OnEnable()
        {
            _claimButton.onClick.AddListener(ClaimRewards);
            _getButton.onClick.AddListener(GetDoubleRewards);
        }

        private void OnDisable()
        {
            _claimButton.onClick.RemoveListener(ClaimRewards);
            _getButton.onClick.RemoveListener(GetDoubleRewards);
        }

        private void GetDoubleRewards()
        {
            Debug.Log("Loading AD...");
        }

        private void ClaimRewards()
        {
            StartCoroutine(Close());
        }

        private IEnumerator Close()
        {
            _victoryScreen.DOFade(0, _showAnimationDuration);
            yield return new WaitForSeconds(_showAnimationDuration);
            _victoryScreen.gameObject.SetActive(false);
        }
    }
}
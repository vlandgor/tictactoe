using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.ConfigProvider;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.LoadingProvider
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private UIDocument _uiDocument;

        private LoadingConfig _loadingConfig;

        private VisualElement _root;
        private VisualElement _visual;
        private ProgressBar _progressBar;

        private float _targetProgress;
        private bool _isUpdating;

        public bool IsEnabled { get; protected set; }

        [Inject]
        public void Construct(IConfigProvider configProvider)
        {
            _loadingConfig = configProvider.GetConfig<LoadingConfig>();
        }

        private void Start()
        {
            InitializeVisual();
            HideCurtain().Forget();
        }

        public async UniTask ShowCurtain()
        {
            _visual.style.display = DisplayStyle.Flex;
            IsEnabled = true;

            if (!_isUpdating)
            {
                _isUpdating = true;
                UpdateProgressBar().Forget();
            }

            await UniTask.CompletedTask;
        }

        public async UniTask HideCurtain()
        {
            IsEnabled = false;
            _visual.style.display = DisplayStyle.None;

            ResetFill();

            await UniTask.CompletedTask;
        }

        public async UniTask Load(Queue<ILoadingOperation> loadingOperations)
        {
            await ShowCurtain();

            int totalOperations = loadingOperations.Count;
            float progressPerOperation = 100f / totalOperations;

            foreach (ILoadingOperation operation in loadingOperations)
            {
                float operationStartProgress = _targetProgress;

                await operation.Load(progress =>
                {
                    _targetProgress = operationStartProgress + (progress / 100f) * progressPerOperation;
                });

                await WaitForBarToFill();
            }

            await UniTask.Delay(_loadingConfig.DelayAfterLoad);
            await HideCurtain();
        }

        private void InitializeVisual()
        {
            _root = _uiDocument.rootVisualElement;
            _visual = _root.Q<VisualElement>("Visual");
            _progressBar = _visual.Q<ProgressBar>("ProgressBar");
        }

        private void ResetFill()
        {
            _targetProgress = 0;
            _progressBar.value = 0;
            _progressBar.title = "Loading...0%";
        }

        private async UniTask WaitForBarToFill()
        {
            while (_progressBar.value < _targetProgress)
            {
                await UniTask.DelayFrame(1);
            }
        }

        private async UniTask UpdateProgressBar()
        {
            while (IsEnabled)
            {
                if (_progressBar.value < _targetProgress)
                {
                    _progressBar.value = Mathf.MoveTowards(_progressBar.value, _targetProgress, Time.deltaTime * _loadingConfig.BarSpeed);
                    _progressBar.title = $"Loading...{(int)_progressBar.value}%";
                }

                await UniTask.Yield();
            }

            _isUpdating = false;
        }
    }
}

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
        private Label _loadingInfo;
        
        private float _targetProgress;
        
        public bool IsEnabled { get; protected set; }

        [Inject]
        public void Construct(IConfigProvider configProvider)
        {
            _loadingConfig = configProvider.GetConfig<LoadingConfig>();
        }
        
        private void Start()
        {
            InitializeVisual();
            HideCurtain();
        }

        public async UniTask ShowCurtain()
        { 
            _visual.style.display = DisplayStyle.Flex;
            IsEnabled = true;
        }

        public async UniTask HideCurtain()
        {
            _visual.style.display = DisplayStyle.None;
            IsEnabled = false;
        }
        
        public async UniTask Load(Queue<ILoadingOperation> loadingOperations)
        {
            UpdateProgressBar().Forget();
            
            foreach (ILoadingOperation operation in loadingOperations)
            {
                ResetFill();
                _loadingInfo.text = operation.Description;
                
                await operation.Load(OnProgress);
                await WaitForBarToFill();
            }
        }
        
        private void InitializeVisual()
        {
            _root = _uiDocument.rootVisualElement;
            _visual = _root.Q<VisualElement>("Visual");
            
            _progressBar = _visual.Q<ProgressBar>("ProgressBar");
            _loadingInfo = _visual.Q<Label>("LoadingInfo");
        }
        
        private void ResetFill()
        {
            _targetProgress = 0;
            _progressBar.value = _targetProgress;
        }
        
        private void OnProgress(float progress)
        {
            _targetProgress = progress;
        }
        
        private async UniTask WaitForBarToFill()
        {
            while (_progressBar.value < _targetProgress)
            {
                await UniTask.Delay(1);
            }

            await UniTask.Delay(_loadingConfig.DelayAfterLoad);
        }
        
        private async UniTask UpdateProgressBar()
        {
            while (IsEnabled)
            {
                if (_progressBar.value < _targetProgress)
                {
                    _progressBar.value += Time.deltaTime * _loadingConfig.BarSpeed;
                }

                await UniTask.Yield();
            }
        }
    }
}
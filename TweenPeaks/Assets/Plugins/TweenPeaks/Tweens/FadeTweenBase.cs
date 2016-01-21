using UnityEngine;
using UnityEngine.UI;

namespace Assets.Plugins.TweenPeaks.Tweens
{
	public abstract class FadeTweenBase : TweenBase
	{
	    private bool _isUIElement;
        private float _startAlpha;

        private CanvasGroup _canvasGroup;
        private bool _isTempCanvasGroup;
        private Graphic _graphic;

        private SpriteRenderer _spriteRenderer;
        private bool _hasChild;
        private SpriteRenderer[] _spriteRenderers;
	    private float[] _spriteRenderersAlpha;

        protected void Initialize()
	    {
	        _isUIElement = gameObject.GetComponent<RectTransform>() != null;
	        if (_isUIElement)
	            CacheUIRenderers();
	        else
	            CacheWorldRenderers();
	    }

	    private void CacheUIRenderers()
		{
	        if (IsUseCanvasGroup())
	            InitCanvasGroup();
	        else
	        {
	            _graphic = GetComponent<Graphic>();
                _startAlpha = _graphic.color.a;
	        }
		}

        private bool IsUseCanvasGroup()
        {
            Graphic[] uiItems = GetComponentsInChildren<Graphic>(true);
            Graphic rootUIItem = GetComponent<Graphic>();
            return uiItems.Length > (rootUIItem != null ? 1 : 0);
        }

        private void InitCanvasGroup()
        {
            _canvasGroup = gameObject.GetComponent<CanvasGroup>();
            if (_canvasGroup == null)
            {
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
                _isTempCanvasGroup = true;
            }
            _startAlpha = _canvasGroup.alpha;
        }

        private void CacheWorldRenderers()
	    {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);

            _hasChild = _spriteRenderers.Length > (_spriteRenderer == null ? 0 : 1);
            if (_hasChild)
            {
                _spriteRenderersAlpha = new float[_spriteRenderers.Length];
                for (int i = 0; i < _spriteRenderers.Length; i++)
                    _spriteRenderersAlpha[i] = _spriteRenderers[i].color.a;
            }
            else
            {
                _startAlpha = _spriteRenderer.color.a;
            }
	    }

	    protected abstract float GetAlpha(float startAlpha, float time);

	    protected override void UpdateValue(float time)
	    {
		    if (_isUIElement)
		    {
                float alpha = GetAlpha(_startAlpha, time);
		        if (_canvasGroup != null)
		        {
		            _canvasGroup.alpha = alpha;
		        }
		        else
		        {
		            _graphic.color = GetAlphaUpdated(_graphic.color, alpha);
		        }
		    }
		    else
		    {
		        if (_hasChild)
		        {
		            for (int i = 0; i < _spriteRenderers.Length; i++)
		            {
		                _spriteRenderers[i].color = GetAlphaUpdated(
                            _spriteRenderers[i].color, 
                            GetAlpha(_spriteRenderersAlpha[i], time));
		            }
		        }
		        else
		        {
                    float alpha = GetAlpha(_startAlpha, time);
                    _spriteRenderer.color = GetAlphaUpdated(_spriteRenderer.color, alpha);
		        }
            }
        }

        private Color GetAlphaUpdated(Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }

        protected override void OnFinish()
		{
            //I use DestroyImmediate instead Destroy as CanvasGroup will be destroyed after current frame in Destroy case,
            //but we can start new fade tween in current frame and in initialization process CanvasGropup still will be exist,
            //will not be created by new tween and when frame finish, CanvasGroup will be destroyed (but will need for new tween).
            if (_isTempCanvasGroup)
                DestroyImmediate(_canvasGroup);

            base.OnFinish();
		}
	}
}

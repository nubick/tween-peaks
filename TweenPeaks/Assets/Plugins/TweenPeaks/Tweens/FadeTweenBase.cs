﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Plugins.TweenPeaks.Tweens
{
	public abstract class FadeTweenBase : TweenBase
	{
		private CanvasGroup _canvasGroup;
		private bool _isTempCanvasGroup;

		private SpriteRenderer _spriteRenderer;
		private TextMesh _textMesh;
		private Graphic _graphic;

		protected void Initialize()
		{
			if (IsUseCanvasGroup())
				InitCanvasGroup();
			else
				CacheRenderers();
		}

		protected void CacheRenderers()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_textMesh = GetComponent<TextMesh>();
			_graphic = GetComponent<Graphic>();
		}

		private bool IsUseCanvasGroup()
		{
			List<Graphic> uiItems = gameObject.GetComponentsInChildren<Graphic>(true).ToList();
			Graphic rootUIItem = gameObject.GetComponent<Graphic>();
			if (rootUIItem != null)
				uiItems.Remove(rootUIItem);
			return uiItems.Count > 0;
		}

		private void InitCanvasGroup()
		{
			_canvasGroup = gameObject.GetComponent<CanvasGroup>();
			if (_canvasGroup == null)
			{
				_canvasGroup = gameObject.AddComponent<CanvasGroup>();
				_isTempCanvasGroup = true;
			}
		}

		protected void UpdateAlpha(float alpha)
		{
			if (_canvasGroup != null)
			{
				_canvasGroup.alpha = alpha;
			}
			else
			{
			    if (_spriteRenderer != null)
			        _spriteRenderer.color = GetAlphaUpdated(_spriteRenderer.color, alpha);

			    if (_textMesh != null)
			        _textMesh.color = GetAlphaUpdated(_textMesh.color, alpha);

			    if (_graphic != null)
			        _graphic.color = GetAlphaUpdated(_graphic.color, alpha);
			}
		}

		protected override void OnFinish()
		{
			if (_isTempCanvasGroup)
				Destroy(_canvasGroup);
			base.OnFinish();
		}

	    private Color GetAlphaUpdated(Color color, float alpha)
	    {
	        color.a = alpha;
	        return color;
	    }
	}
}

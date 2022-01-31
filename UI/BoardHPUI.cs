using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class BoardHPUI : MonoBehaviour
{
    [SerializeField]
        private Slider _mainSlider;//緑ゲージ
        [SerializeField]
        private Slider _subSlider;//赤ゲージ
        private float TweenTime=1.0f;

        [SerializeField]
        private BoardHP _boardHp;
        
    
        void Start()
        {
            //Sliderの初期化
            _mainSlider.maxValue = _mainSlider.value = _boardHp.BoardHp;

            _subSlider.maxValue = _subSlider.value = _boardHp.BoardHp;
    
            
            BoardHPUIUpdate();
    
        }
    
    
        private void BoardHPUIUpdate()
        {
            _boardHp.ObserveEveryValueChanged(x=>x.BoardHp)
                .Subscribe(_ =>
                {
                    _mainSlider.value = _boardHp.BoardHp;
                    SubSliderUpdate();
                })
                .AddTo(this);
    
        }
    
        private void SubSliderUpdate()
        {
            DOTween.To
            (
                () => _subSlider.value, //何に
                (x) => _subSlider.value = x, //何を
                _boardHp.BoardHp, //どこまで(最終的な値)
                TweenTime //どれくらいの時間
            );
        }
}

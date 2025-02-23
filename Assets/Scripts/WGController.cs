using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoI
{
    public class WGController : MonoBehaviour
    {
        [SerializeField]
        private int _maxWordsCount = 4;
        [SerializeField]
        private WGView _view;
        
        private WGModel _model;


        // private void Start()
        // {
        //     Init();
        // }

        public void Activate(List<string> dictList)
        {

            // Debug.Log(dictList.Count);
            //
            // for (int i = 0; i < _maxWordsCount; i++)
            // {
            //     Debug.Log(dictList[i]);
            // }
            
            _model = new WGModel(ref dictList, _maxWordsCount);
            
            _model.OnCurrentWordsChanged += OnCurrentWordsChanged;
            _model.OnInputFailed += OnInputFailed;
            _model.OnInputSuccess += OnInputSuccess;
            
            _model.FillWordsList();
            
            _view.OnInputValueChanged += OnInputValueChanged;
            _view.Activate();
        }

        public void Deactivate()
        {
            _model.OnCurrentWordsChanged -= OnCurrentWordsChanged;
            _model.OnInputFailed -= OnInputFailed;
            _model.OnInputSuccess -= OnInputSuccess;
            
            _view.OnInputValueChanged -= OnInputValueChanged;
            
            _view.Deactivate();
        }
        
        

        private void OnInputSuccess(string obj)
        {
            _model.RemoveWord(obj);
            _model.FillWordsList();
            _view.ClearInputField();
            
            LevelController.Instance.successesCount += 1;
            GameEvents.OnSuccessInput?.Invoke(obj.Length);
        }

        private void OnInputFailed()
        {
            if (_view.inputLength > 1)
                LevelController.Instance.failsCount += 1;
            _view.ClearInputField();
        }

        private void OnInputValueChanged(string obj)
        {
            _model.CheckWordPart(obj);
        }

        private void OnCurrentWordsChanged(List<string> obj)
        {
            _view.UpdateCurrentWords(obj);
        }

        // WGController(WGModel model, WGView view)
        // {
        //     _model = model;
        //     _view = view;
        // }

        public class Builder
        {
            // private readonly WGModel
        }


    }
    
}
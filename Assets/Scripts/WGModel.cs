// using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoI
{
    public class WGModel
    {
        public Action OnInputFailed;
        public Action<string> OnInputSuccess;
        public Action<List<string>> OnCurrentWordsChanged;

        
        private List<string> _dictionaryList;
        private List<string> _currentWordsList = new List<string>();
        // private string _currentInput = "";
        private int _maxWordsCount;

        
        public WGModel(ref List<string> dictionaryList, int maxWordsCount)
        {
            _dictionaryList = dictionaryList;
            _maxWordsCount = maxWordsCount;
        }

        public void FillWordsList()
        {
            while (_currentWordsList.Count < _maxWordsCount)
            {
                _currentWordsList.Add(PickRandomWord());
            }
            OnCurrentWordsChanged?.Invoke(_currentWordsList);
        }

        public void RemoveWord(string word)
        {
            _currentWordsList.Remove(word);
        }
        
        public void CheckWordPart(string part)
        {
            var prefixMatches = _currentWordsList
                .Where(word => word.StartsWith(part, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!prefixMatches.Any())
            {
                OnInputFailed?.Invoke();
                return;
            }
            
            // _currentInput = part;
            
            var completeMatch = _currentWordsList
                .Where(word => word.Equals(part, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            if (completeMatch.Any())
                OnInputSuccess?.Invoke(completeMatch[0]);
        }
        
        
        // ---
        
        private string PickRandomWord()
        {
            int randomIndex = UnityEngine.Random.Range(0, _dictionaryList.Count);
            var newWord = _dictionaryList[randomIndex];
            if (_currentWordsList.Contains(newWord))
            {
                return PickRandomWord();
            }

            return newWord;
        }
        
    }
}
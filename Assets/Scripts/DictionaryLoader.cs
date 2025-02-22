using System.Collections.Generic;
using UnityEngine;

namespace MoI
{
    public static class DictionaryLoader
    {
        public static void LoadDictionary(out List<string> dictionaryList)
        {
            TextAsset textAsset = Resources.Load<TextAsset>("dictionary");
            dictionaryList = new List<string>(textAsset.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
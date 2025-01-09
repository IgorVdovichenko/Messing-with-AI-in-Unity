
using UnityEngine;

namespace ScriptedDT.Parsing
{
    public class TextAssetReader: IJsonReader
    {
        private readonly TextAsset _textAsset;

        public TextAssetReader(TextAsset textAsset)
        {
            _textAsset = textAsset;
        }
        
        public string Read()
        {
            return _textAsset.text;
        }
    }
}
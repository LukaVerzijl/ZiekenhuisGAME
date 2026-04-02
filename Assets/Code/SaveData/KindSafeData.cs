using System;

namespace Code.Utils.SaveData
{
    /// <summary>
    /// JSON blueprint voor save file
    /// </summary>
    [Serializable]
    public struct KindSafeData
    {
        public string KindNaam;
        public bool hasReadPart1;
        public bool hasReadPart2;
        public bool hasReadPart3;
        public bool hasReadPart4;
        public int chosenCharacter;
    }
}
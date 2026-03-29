using Code.Utils;
using Code.Utils.SaveData;
using Pepersistence;

namespace Code.Managers
{
    /// <summary>
    /// Class heeft save waardes lokaal variables worden opgeslagen en geladen in de functies. Voeg nieuwe dingen in de save file toe door een var aan te maken in de KindSafeData en deze hier te defineren, voeg deze in de load en save fuctie te plaatsen.
    /// bassed op de Isaveable Interface met de uitleg van de JSON
    /// </summary>
    public class SaveDataManager : Singleton<SaveDataManager>, ISavable<SaveData>
    {
        public string KindNaam;
        public bool hasReadPart1;
        public bool hasReadPart2;
        public bool hasReadPart3;
        public bool hasReadPart4;


        public void Load(SaveData saveData)
        {
            KindNaam = saveData.KindSafeData.KindNaam;
            hasReadPart1 = saveData.KindSafeData.hasReadPart1;
            hasReadPart2 = saveData.KindSafeData.hasReadPart2;
            hasReadPart3 = saveData.KindSafeData.hasReadPart3;
            hasReadPart4 = saveData.KindSafeData.hasReadPart4;
        }

        public void Save(ref SaveData saveData)
        {
            saveData.KindSafeData.KindNaam = KindNaam;
            saveData.KindSafeData.hasReadPart1 = hasReadPart1;
            saveData.KindSafeData.hasReadPart2 = hasReadPart2;
            saveData.KindSafeData.hasReadPart3 = hasReadPart3;
            saveData.KindSafeData.hasReadPart4 = hasReadPart4;
        }
    }
}
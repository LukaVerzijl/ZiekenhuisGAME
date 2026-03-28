using Code.Utils;
using Pepersistence;

namespace Code.Managers
{
    public class SaveManager : Singleton<SaveManager>
    {
        public PersistenceManager persistenceManager { get; private set; }

        public void Start()
        {
            persistenceManager = new PersistenceManager(new LocalSaveSource());
            persistenceManager.Register(SaveDataManager.Instance);
            persistenceManager.Load();
            if (SaveDataManager.Instance.KindNaam != "" && SaveDataManager.Instance.KindNaam == null ){
                persistenceManager.Save();
            }
            
        }
    }
}
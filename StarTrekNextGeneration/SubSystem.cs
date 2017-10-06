using StarTrekNextGeneration;

namespace StarTrekNextGeneration
{
    public class SubSystem
    {
        public string systemName;
        public int starDateRecoveryCount;
        public bool isActive;

        public SubSystem()
        {
            isActive = true;
        }

        public void SetActive(bool active)
        {
            isActive = active;
        }
    }
}

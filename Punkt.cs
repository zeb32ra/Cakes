using PodPunkt;

namespace Punkt
{
    internal class Punkts
    {
        public string name_of_punkt;
        public int position;
        public List<PodPunkts> podPunkts;
        public Punkts(List<PodPunkts> podPunkts, string name_of_punkt, int position) 
        {
            this.podPunkts = podPunkts;
            this.name_of_punkt = name_of_punkt;
            this.position = position;
        }
    }
    
}

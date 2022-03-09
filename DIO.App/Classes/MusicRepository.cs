using DIO.App.Interfaces;

namespace DIO.App.Classes
{
    public class MusicRepository : IRepository<Musics>
    {
        private List<Musics> listMusics = new List<Musics>();
        public void Delete(int id)
        {
            listMusics[id].Delete();
        }

        public void Add(Musics obj)
        {
            listMusics.Add(obj);
        }

        public List<Musics> Lists()
        {
            return listMusics;
        }

        public int NextId()
        {
            return listMusics.Count;
        }

        public Musics ReturnId(int id)
        {
            return listMusics[id];
        }

        public void Update(int id, Musics obj)
        {
            listMusics[id] = obj;
        }
    }
}
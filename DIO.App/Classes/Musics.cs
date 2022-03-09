using DIO.App.Enum;

namespace DIO.App.Classes
{
    public class Musics : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Name { get; set; }
        private string Artist { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Musics(int id, Genre genre, string name, string artist, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Name = name;
            this.Artist = artist;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string regress = "";
            regress += "Genre: " + this.Genre + Environment.NewLine;
            regress += "Name: " + this.Name + Environment.NewLine;
            regress += "Artist: " + this.Artist + Environment.NewLine;
            regress += "Year: " + this.Year;
            return regress;
        }

        public string returnName()
        {
            return this.Name;
        }

        public int returnId()
        {
            return this.Id;
        }
        public bool returnDeleted()
        {
            return this.Deleted;
        }
        public void Delete()
        {
            this.Deleted = true;
        }

    }
}
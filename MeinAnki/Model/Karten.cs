using SQLite;

namespace MeinAnki.Model
{
    public class Karten
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public string Original { get; set; }
        public string Translate { get; set; }
        public int BlockId { get; set; }

        [Ignore]  // Это нужно, чтобы SQLite не пыталась сохранять объект Block в базу
        public Block Block { get; set; }
    }
}

using SQLite;

namespace MeinAnki.Model
{
    public class Block
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }


    }
}

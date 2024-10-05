using MeinAnki.Model;
using SQLite;

namespace MeinAnki.Service
{
    public static class DB
    {
        private static string dbPath = String.Empty;
        private static SQLiteAsyncConnection db;

        public static string GetDatabasePath()
        {

            var documentsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;

            if (!Directory.Exists(Path.Combine(documentsPath, "DB")))
            {
                Directory.CreateDirectory(Path.Combine(documentsPath, "DB"));
            }
            documentsPath = Path.Combine(documentsPath, "DB");
            // Указываем имя файла базы данных
            var databasePath = Path.Combine(documentsPath, "anki.db");

            return databasePath;
        }

        public static void CreateDatabase()
        {
            // Получаем путь к файлу базы данных
            dbPath = GetDatabasePath();

            // Проверяем, существует ли файл базы данных
            if (!File.Exists(dbPath))
            {
                // Создаем новое соединение SQLite с базой данных
                var db = new SQLiteConnection(dbPath);

                // Создаем таблицы в базе данных (например, таблицы Block и Karten)
                db.CreateTable<Block>();
                db.CreateTable<Karten>();
            }

            db = new SQLiteAsyncConnection(dbPath);
        }

        public static async Task SetDaten(string Block, string Original, string Translate)
        {

            // Добавляем блок
            var block = new Block { Name = $"{Block}" };
            await db.InsertAsync(block);

            //// Добавляем карточку, связанную с блоком
            //var karten = new Karten { Original = "or", Translate = "tr", BlockId = block.Id };
            //await db.InsertAsync(karten);

            await db.CloseAsync();
        }

        public static async Task SetDaten(string Block)
        {
            var block = new Block { Name = $"{Block}" };
            await db.InsertAsync(block);

            await db.CloseAsync();
        }

        public static async Task<List<Block>> GetAll()
        {
            var t = await db.Table<Block>().ToListAsync();

            await db.CloseAsync();

            return t;
        }

        public static async Task<List<Block>> GetDaten(string Block)
        {
            var t = await db.Table<Block>().ToListAsync();

            await db.CloseAsync();

            return t;
        }

        public static async Task DelDaten(string Block)
        {
            var block = await db.Table<Block>().FirstOrDefaultAsync(b => b.Name == Block);
            if (block != null)
            {
                await db.DeleteAsync(block);
            }

            await db.CloseAsync();
        }

        public static async Task DelDaten(string Block, string Original, string Translate)
        {
            var t = await db.Table<Block>().ToListAsync();

            await db.CloseAsync();
        }

        public static async Task UpDaten(string Block, string Original, string Translate)
        {
            var t = await db.Table<Block>().ToListAsync();

            await db.CloseAsync();
        }

        public static async Task UpDaten(string Block)
        {
            var block = await db.Table<Block>().FirstOrDefaultAsync(b => b.Name == Block);
            if (block != null)
            {
                block.Name = $"{Block}";
                await db.UpdateAsync(block);
            }

            await db.CloseAsync();
        }

        //public static async Task<List<Karten>> GetKartenByBlockId(int blockId)
        //{
        //    // Получаем карточки, связанные с определённым блоком
        //    var kartenList = await db.Table<Karten>().Where(k => k.BlockId == blockId).ToListAsync();

        //    return kartenList;
        //}

        //public static async Task ShowKartenForBlock()
        //{
        //    // Добавляем данные (тестовый блок и карточку)
        //    await DB.SetDaten();

        //    // Предположим, что мы знаем ID блока (например, ты можешь получить ID созданного блока)
        //    var block = await db.Table<Block>().FirstOrDefaultAsync(b => b.Name == "Test");
        //    var karten = await db.Table<Karten>().Take(10).ToListAsync();

        //}

    }
}


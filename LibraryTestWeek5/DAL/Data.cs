namespace LibraryTestWeek5.DAL
{
    // מחלקה לניהול הנתונים של החברים שלי
    public class Data
    {
        // משתנה סטטי לשמירת מופע יחיד של המחלקה
        static Data GetData;

        // מחזורת לחיבור לבסיס הנתונים
        string ConnectionString = "" +
        "server=DESKTOP-AI1M2JH\\SQLEXPRESS; " +
        "initial catalog=Library ; " +
        "user id=sa ; " +
        "password=1234; " +
        "TrustServerCertificate=Yes";

        // קונסטרטור פרטי למניעת יצירת מופעים מחוץ למחלקה
        private Data()
        {
            // יצירת מופע של שכבת הנתונים עם מחרוזת החיבור
            Layer = new DataLayer(ConnectionString);
        }

        // מאפיין סטטי לקבלת שכבת הנתונים
        public static DataLayer Get
        {
            get
            {
                // יצירת מופע חדש של המחלקה אם לא קיים
                if (GetData == null)
                {
                    GetData = new Data();

                }
                // החזרת שכבת הנתונים
                return GetData.Layer;
            }
        }


        // מאפיין לשמירת שכבת הנתונים
        public DataLayer Layer { get; set; }
    }
}

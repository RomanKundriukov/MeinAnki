namespace MeinAnki.Model
{
    public class ClosePopupMessage
    {
        public bool ShouldClose { get; }

        public ClosePopupMessage(bool shouldClose)
        {
            ShouldClose = shouldClose;
        }
    }
}

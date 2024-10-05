namespace MeinAnki.Model
{
    public class Mediator
    {
        private static Mediator _instance;

        public static Mediator Instance => _instance ??= new Mediator();

        public event EventHandler<string> DataChangedString;

        public event EventHandler<ClosePopupMessage> DataChangedMessage;

        public void Notify(string data)
        {
            DataChangedString?.Invoke(this, data);
        }
        public void Notify(ClosePopupMessage message)
        {
            DataChangedMessage?.Invoke(this, message);
        }
    }
}

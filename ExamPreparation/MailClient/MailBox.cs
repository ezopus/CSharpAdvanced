using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }
        public List<Mail> Inbox { get; private set; }
        public List<Mail> Archive { get; private set; }
        public int Capacity { get; set; }
        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
            {
                Inbox.Add(mail);
            }
        }
        public bool DeleteMail(string sender)
        {
            return Inbox.Remove(Inbox.FirstOrDefault(m => m.Sender == sender));
        }
        public int ArchiveInboxMessages()
        {
            int moved = Inbox.Count;
            foreach (Mail mail in Inbox)
            {
                Archive.Add(mail);
            }
            Inbox.Clear();
            return moved;
        }
        public string GetLongestMessage()
        {
            return Inbox.MaxBy(m => m.Body.Length).ToString();
        }
        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

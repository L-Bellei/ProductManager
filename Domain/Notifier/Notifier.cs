using ProductManager.Domain.Interfaces;

namespace ProductManager.Domain.Notifier;

public class Notifier : INotifier
{
    private readonly List<Notification> _notifications;

    public Notifier()
    {
        _notifications = [];
    }

    public void Handle(Notification notificacao)
    {
        _notifications.Add(notificacao);
    }

    public IEnumerable<Notification> GetNotifications()
    {
        return _notifications;
    }

    public bool HasNotification()
    {
        return _notifications.Count != 0;
    }
}

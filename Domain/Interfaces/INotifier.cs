using ProductManager.Domain.Notifier;

namespace ProductManager.Domain.Interfaces;

public interface INotifier
{
    void Handle(Notification notificacao);
    IEnumerable<Notification> GetNotifications();
    bool HasNotification();
}

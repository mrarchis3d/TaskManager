using TaskManager.Client.Enums;

namespace TaskManager.Client.Services;
public class AlertService
{
    public event Action<string, AlertType> OnShowAlert;

    public void ShowAlert(string message, AlertType type)
    {
        OnShowAlert?.Invoke(message, type);
    }
}
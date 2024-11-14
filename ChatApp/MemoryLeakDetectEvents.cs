using MemoryToolkit.Maui;

namespace Dorisoy.PeriodontalChat;

public class MemoryLeakDetectEvents
{
    public event EventHandler<CollectionTarget> OnCollected;
    public event EventHandler<CollectionTarget> OnLeaked;

    internal void InvokeOnCollected(CollectionTarget target) => OnCollected?.Invoke(this, target);
    internal void InvokeOnLeaked(CollectionTarget target) => OnLeaked?.Invoke(this, target);
}
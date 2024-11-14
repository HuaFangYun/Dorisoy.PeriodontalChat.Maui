using Dorisoy.PeriodontalChat.Converters;

namespace Dorisoy.PeriodontalChat;
public static class UraniumConverters
{
    public static BooleanInverter BooleanInverter { get; } = new();

    public static BoolToOpactityConverter BoolToOpactityConverter { get; } = new();
}

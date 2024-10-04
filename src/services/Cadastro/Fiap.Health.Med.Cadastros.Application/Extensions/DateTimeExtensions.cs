namespace Fiap.Health.Med.Cadastros.Application.Extensions;
public static class DateTimeExtensions
{
    public static long ToUnixEpochDate(this DateTime data)
    {
        var dataPadrao = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        return (long)Math.Round((data.ToUniversalTime() - dataPadrao).TotalSeconds);
    }
}
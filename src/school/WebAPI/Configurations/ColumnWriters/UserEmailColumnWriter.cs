using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace WebAPI.Configurations.ColumnWriters;

public class UserEmailColumnWriter : ColumnWriterBase
{
    public UserEmailColumnWriter() : base(NpgsqlDbType.Varchar)
    {
    }

    public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
    {
       var (email,value) = logEvent.Properties.FirstOrDefault(p => p.Key == "user_email");
        return value?.ToString() ?? null;
    }
}

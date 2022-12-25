using Microsoft.EntityFrameworkCore;

/*
 * For Tracking Data Changes Etity Framework 6.0 has TemporalTable support
 For more information:
    https://devblogs.microsoft.com/dotnet/prime-your-flux-capacitor-sql-server-temporal-tables-in-ef-core-6-0/
 */

StorageBroker broker = new();

Setting newSetting = new()
{
    SettingName = "ImportantSetting",
    SettingValue = "ImportantSettingValue"
};
broker.Settings.Add(newSetting);
broker.SaveChanges();

Setting? updateSetting = broker.Settings.FirstOrDefault(s => s.SettingName == newSetting.SettingName);
if (updateSetting is not null)
{
    updateSetting.SettingValue = "ImportantSettingValueChanged1";
    broker.Update(updateSetting);
}
broker.SaveChanges();

//You can get History Table's Data
IQueryable<Setting> settingList = broker.Settings.TemporalAll();

public class Setting
{
    public int Id { get; set; }
    public string SettingName { get; set; }
    public string SettingValue { get; set; }
}

public class StorageBroker : DbContext
{
    public StorageBroker() =>
        this.Database.Migrate();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TemporalTableExample;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setting>()
            .ToTable
            (
                name: "Settings",
                settingsTable => settingsTable.IsTemporal(s =>
                {
                    s.UseHistoryTable("SettingsHistory"); // <= If you want to Customize History Table's name
                })
            );
    }
    public DbSet<Setting> Settings { get; set; }
}
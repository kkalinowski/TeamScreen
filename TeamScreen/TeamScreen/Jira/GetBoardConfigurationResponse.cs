namespace TeamScreen.Jira
{
    public class GetBoardConfigurationResponse
    {
        public string Name { get; set; }
        public ColumnConfiguration ColumnConfig { get; set; }
    }

    public class ColumnConfiguration
    {
        public Column[] Columns { get; set; }
    }

    public class Column
    {
        public string Name { get; set; }
        public Status[] Statuses { get; set; }
    }
}
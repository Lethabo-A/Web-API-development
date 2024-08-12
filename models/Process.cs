public class Process
{
    public Guid ProcessID { get; set; }  // Use Guid for uniqueidentifier
    public string ProcessName { get; set; }
    public string ProcessType { get; set; }
    public bool IsFramework { get; set; }
    public bool RequiresDefaultConfig { get; set; }
    public string Submitter { get; set; }
    public DateTime DateSubmitted { get; set; }
    public string ProcessConfigURL { get; set; }
    public string ReportURL { get; set; }
    public Guid? ProjectID { get; set; }
    public string DefaultGeography { get; set; }
    public string DefaultBusinessFunction { get; set; }
    public string Platform { get; set; }
}

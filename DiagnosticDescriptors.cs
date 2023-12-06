using Microsoft.CodeAnalysis;

public static class DiagnosticDescriptors
{
    public static readonly DiagnosticDescriptor LogToEventLog = new DiagnosticDescriptor(
        id: "ACTANALYZER001",
        title: "Logging to Windows Event Log is not allowed",
        messageFormat: "Method '{0}' appears to log to Windows Event Log, which is not allowed in cloud environments",
        category: "Security",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor WriteToRegistry = new DiagnosticDescriptor(
        id: "ACTANALYZER002",
        title: "Writing to Windows Registry is not allowed",
        messageFormat: "Method '{0}' appears to write to Windows Registry, which is not allowed in cloud environments",
        category: "Security",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor UnauthorizedFileAccess = new DiagnosticDescriptor(
        id: "ACTANALYZER003",
        title: "Unauthorized file access",
        messageFormat: "Method '{0}' contains file path manipulation which might allow access to unauthorized directories",
        category: "Security",
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true);
}

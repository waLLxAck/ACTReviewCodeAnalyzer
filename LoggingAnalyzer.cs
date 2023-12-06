using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class LoggingAnalyzer : DiagnosticAnalyzer
{
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => ImmutableArray.Create(DiagnosticDescriptors.LogToEventLog,
                                 DiagnosticDescriptors.WriteToRegistry,
                                 DiagnosticDescriptors.UnauthorizedFileAccess);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
    }

    private void AnalyzeMethod(SyntaxNodeAnalysisContext context)
    {
        // very basic example. In a real-world scenario, you'd have more complex logic to, for example, analyze the method body for calls to specific APIs.
        var methodDeclaration = (MethodDeclarationSyntax)context.Node;

        // Check if the method name is "LogApplicationStarted"
        if (methodDeclaration.Identifier.Text == "LogApplicationStarted")
        {
            // Create a diagnostic at the method location
            var diagnostic = Diagnostic.Create(DiagnosticDescriptors.LogToEventLog,
                                               methodDeclaration.Identifier.GetLocation(),
                                               methodDeclaration.Identifier.Text);

            context.ReportDiagnostic(diagnostic);
        }
    }

}
